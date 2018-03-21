using System;
using System.Collections.Generic;

namespace EvolirisCSharpTraining
{
    namespace Minesweeper
    {
        class Main
        {
            static public void Run()
            {
                Minesweeper MyMinesweeper = new Minesweeper();
                MyMinesweeper.Run();
            }
        }

        public class Position
        {
            public Position(int rowVal, int columnVal)
            {
                Row = rowVal;
                Column = columnVal;
            }

            public int Row { get; set; }
            public int Column { get; set; }
        }

        class Board
        {
            public Board(int nbMinesToPlace, int nbRowsVal, int nbColumnsVal)
            {
                NbRows = nbRowsVal;
                NbColumns = nbColumnsVal;

                AllocateBoardContent();

                Random randomNbGenerator = new Random();
                int nbMinesPlaced = 0;
                while (nbMinesPlaced < nbMinesToPlace)
                {
                    int mineRow = randomNbGenerator.Next(0, NbRows);
                    int mineColumn = randomNbGenerator.Next(0, NbColumns);
                    Position minePosition = new Position(mineRow, mineColumn);

                    bool isTileAlreadyMined = GetTile(minePosition).IsMined();
                    if (isTileAlreadyMined)
                    { continue; }

                    //Console.WriteLine($"Placed mine at {mineRow}, {mineColumn}");
                    GetTile(minePosition).PlaceMine();
                    nbMinesPlaced++;
                }
            }

            public void AllocateBoardContent()
            {
                //_Data is padded with one "ghost node" on each side of the board
                //This allows to safely search for tile neighbours anywhere whithin board
                _BoardContent = new Tile[NbRows + 2, NbColumns + 2];

                for (int row = -1; row < NbRows + 1; row++)
                {
                    for (int column = -1; column < NbColumns + 1; column++)
                    {
                        _BoardContent[row + 1, column + 1] = new Tile();
                    }
                }
            }

            public bool IsTileExplored(Position tilePosition)
            { return GetTile(tilePosition).IsExplored(); }

            public bool IsTileFlagged(Position tilePosition)
            { return GetTile(tilePosition).IsFlagged(); }

            public void ExploreTile(Position tilePosition)
            {
                GetTile(tilePosition).Explore();
                DisplayTile(tilePosition);
            }

            public void FlagTile(Position tilePosition)
            {
                GetTile(tilePosition).ToggleFlag();
                DisplayTile(tilePosition);
            }

            public bool hasNeighbourWithMines(Position tilePosition)
            {
                int nbNeighbouringMines = CountNeighbouringMines(tilePosition);
                return (nbNeighbouringMines > 0);
            }

            public List<Position> GetPosOfNeighbours(Position tilePos)
            {
                //At first list all neighbours without caring whether they 
                //are within the board or not
                List<Position> posOfNeighboursUnfiltered = new List<Position>();
                posOfNeighboursUnfiltered.Add(new Position(tilePos.Row - 1, tilePos.Column - 1));
                posOfNeighboursUnfiltered.Add(new Position(tilePos.Row - 1, tilePos.Column - 1));
                posOfNeighboursUnfiltered.Add(new Position(tilePos.Row - 1, tilePos.Column));
                posOfNeighboursUnfiltered.Add(new Position(tilePos.Row - 1, tilePos.Column + 1));
                posOfNeighboursUnfiltered.Add(new Position(tilePos.Row, tilePos.Column - 1));
                posOfNeighboursUnfiltered.Add(new Position(tilePos.Row, tilePos.Column + 1));
                posOfNeighboursUnfiltered.Add(new Position(tilePos.Row + 1, tilePos.Column - 1));
                posOfNeighboursUnfiltered.Add(new Position(tilePos.Row + 1, tilePos.Column));
                posOfNeighboursUnfiltered.Add(new Position(tilePos.Row + 1, tilePos.Column + 1));

                //Then filter out neighbours that are outside of board
                List<Position> posOfNeighbours = new List<Position>();
                foreach (Position eachPos in posOfNeighboursUnfiltered)
                {
                    if (this.ContainsTilePos(eachPos))
                    { posOfNeighbours.Add(eachPos); }
                }

                return posOfNeighbours;
            }

            public bool ContainsTilePos(Position tilePosition)
            {
                return (tilePosition.Row >= 0) && (tilePosition.Row < NbRows)
                    && (tilePosition.Column >= 0) && (tilePosition.Column < NbColumns);
            }

            public Tile GetTile(int row, int column)
            { return _BoardContent[row + 1, column + 1]; }

            public Tile GetTile(Position tilePosition)
            { return GetTile(tilePosition.Row, tilePosition.Column); }

            public void Display()
            {
                //Put cursor back at console's (0,0) so that new array
                //overwrites old array.
                //Better than Console.Clear() because the latter makes
                //display blink.
                Console.SetCursorPosition(0, 0);

                //Display is written from top to bottom
                //I.e. start with last row and move down to first row
                int lastRow = NbRows - 1;
                for (int numRow = lastRow; numRow >= 0; numRow--)
                {
                    for (int numColumn = 0; numColumn < NbColumns; numColumn++)
                    {
                        WriteTileAtCursor(new Cursor(numRow, numColumn));
                    }
                    Console.WriteLine();
                }
            }

            public void DisplayTile(Position posOfTile)
            {
                int oldCursorLeft = Console.CursorLeft;
                int oldCursorTop = Console.CursorTop;
                SetConsoleCursorPosition(posOfTile);
                WriteTileAtCursor(posOfTile); //Also moves cursor by one
                Console.SetCursorPosition(oldCursorLeft, oldCursorTop);
            }

            //Moves the console cursor without altering Cursor objects
            private void SetConsoleCursorPosition(Position posOfTile)
            {
                Cursor newCursor = new Cursor();
                newCursor.PlaceOnTile(posOfTile, this);
            }

            //Because the cursor is being moved after each write, this function
            //would be dangerous to be called by code outside the Board class
            private void WriteTileAtCursor(Position posOfTile)
            {
                Tile currentTile = GetTile(posOfTile);
                int nbNeighbouringMines = CountNeighbouringMines(posOfTile);
                Console.Write(currentTile.ToString(nbNeighbouringMines));
            }

            private List<Tile> GetTileNeighbours(Position currentPos)
            {
                List<Tile> neighbours = new List<Tile>();
                neighbours.Add(GetTile(currentPos.Row - 1, currentPos.Column - 1));
                neighbours.Add(GetTile(currentPos.Row - 1, currentPos.Column));
                neighbours.Add(GetTile(currentPos.Row - 1, currentPos.Column + 1));
                neighbours.Add(GetTile(currentPos.Row, currentPos.Column - 1));
                neighbours.Add(GetTile(currentPos.Row, currentPos.Column + 1));
                neighbours.Add(GetTile(currentPos.Row + 1, currentPos.Column - 1));
                neighbours.Add(GetTile(currentPos.Row + 1, currentPos.Column));
                neighbours.Add(GetTile(currentPos.Row + 1, currentPos.Column + 1));
                return neighbours;
            }

            public int CountNeighbouringMines(Position posOfTile)
            {
                int nbMines = 0;
                foreach (Tile neighbour in GetTileNeighbours(posOfTile))
                {
                    if (neighbour.IsMined())
                    { nbMines++; }
                }
                return nbMines;
            }

            private Tile[,] _BoardContent;
            public int NbRows { get; }
            public int NbColumns { get; }
            public enum TypeTileType { Clear, Mine };
            public enum TypeTileStatus { Unexplored, Explored, Flagged };

            /// One of the tiles of the board.
            /// A tile can contain a mine or not.
            /// A tile can be flagged, explored or unexplored.
            public class Tile
            {
                public bool IsMined() { return (TileType == TypeTileType.Mine); }
                public bool IsExplored() { return (TileStatus == TypeTileStatus.Explored); }
                public bool IsFlagged() { return (TileStatus == TypeTileStatus.Flagged); }

                public void Explore() { TileStatus = TypeTileStatus.Explored; }
                public void PlaceMine() { TileType = TypeTileType.Mine; }

                public void ToggleFlag()
                {
                    TileStatus = (TileStatus == TypeTileStatus.Flagged) ?
                                 TypeTileStatus.Unexplored : TypeTileStatus.Flagged;
                }

                /// Returns the one-character string that must be displayed
                /// on the tile when Board.Display() is called.

                /// Returns either the exact character to display
                /// or "#" which will have to be replaced with the number of mines around
                public override string ToString()
                {
                    switch (TileStatus)
                    {
                        case TypeTileStatus.Unexplored: return "O";
                        case TypeTileStatus.Flagged: return "F";
                        case TypeTileStatus.Explored:
                            switch (TileType)
                            {
                                case TypeTileType.Mine: return "*";
                                case TypeTileType.Clear: return "#";
                                default: return "?";
                            }
                        default: return "?";
                    }
                }

                public string ToString(int nbNeighbouringMines)
                {
                    string output = this.ToString();
                    if(output == "#")
                    {
                        return ((nbNeighbouringMines == 0) ? "-"
                            : nbNeighbouringMines.ToString("0") );
                    }
                    return output;
                }

                private TypeTileType TileType = TypeTileType.Clear;
                private TypeTileStatus TileStatus = TypeTileStatus.Unexplored;
            }
        }

        class Cursor : Position
        {
            public Cursor() :base(0,0)
            { /*Do nothing*/ }

            public Cursor(int row, int column) : base(row, column)
            { /*Do nothing*/ }

            public Cursor(Cursor other) : base(other.Row, other.Column)
            { /*Do nothing*/ }

            public void Refresh(Board board)
            { PlaceOnTile(this, board); }

            public void PlaceOnTile(Position tilePosition, Board board)
            {
                int cursorX = tilePosition.Column;
                int cursorY = board.NbRows - 1 - tilePosition.Row;
                Console.SetCursorPosition(cursorX, cursorY);
                Row = tilePosition.Row;
                Column = tilePosition.Column;
            }

            public void MoveLeftwards(Board board)
            {
                Column--;
                if (Column < 0)
                { Column = 0; }
                PlaceOnTile(this, board);
            }

            public void MoveRightwards(Board board)
            {
                Column++;
                if (Column >= board.NbColumns)
                { Column = board.NbColumns - 1; }
                PlaceOnTile(this, board);
            }

            public void MoveDownwards(Board board)
            {
                Row--;
                if (Row < 0)
                { Row = 0; }
                PlaceOnTile(this, board);
            }

            public void MoveUpwards(Board board)
            {
                Row++;
                if (Row >= board.NbRows)
                { Row = board.NbRows - 1; }
                PlaceOnTile(this, board);
            }
        }

        class Minesweeper
        {
            public Minesweeper()
            {
                const int NB_MINES = 10;
                const int NB_ROWS = 10;
                const int NB_COLUMNS = 10;
                _Board = new Board(NB_MINES, NB_ROWS, NB_COLUMNS);
                _Cursor = new Cursor();
            }

            public void Run()
            {
                _Board.Display();

                Position startingTile = new Position(0, 0);
                _Cursor.PlaceOnTile(startingTile, _Board);

                bool isGameContinuing = true;
                while (isGameContinuing)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.LeftArrow: _Cursor.MoveLeftwards(_Board); break;
                        case ConsoleKey.RightArrow: _Cursor.MoveRightwards(_Board); break;
                        case ConsoleKey.DownArrow: _Cursor.MoveDownwards(_Board); break;
                        case ConsoleKey.UpArrow: _Cursor.MoveUpwards(_Board); break;
                        case ConsoleKey.Enter:
                            if (!_Board.IsTileFlagged(_Cursor))
                            { ExploreCurrentTile(isGameContinuing); }
                            break;
                        case ConsoleKey.Delete:
                            if (!_Board.IsTileExplored(_Cursor))
                            { _Board.FlagTile(_Cursor); }
                            break;
                        case ConsoleKey.Escape: isGameContinuing = false; continue;
                    }
                    System.Threading.Thread.Sleep(100);
                }
            }

            private void ExploreCurrentTile(bool isGameContinuing)
            {
                if (_Board.GetTile(_Cursor).IsMined())
                {
                    Console.Write("Game over!");
                    isGameContinuing = false;
                    return;
                }

                PropagateSafeZone(_Cursor);
            }

            public void PropagateSafeZone(Position centerOfPropagation)
            {
                _Board.ExploreTile(centerOfPropagation);

                if (_Board.hasNeighbourWithMines(centerOfPropagation))
                { return; }

                //Propagate to all neighbours
                foreach (Position posOfNeighbour
                    in _Board.GetPosOfNeighbours(centerOfPropagation))
                {
                    bool isNeighbourAlreadyExplored = _Board.IsTileExplored(posOfNeighbour);
                    if (!isNeighbourAlreadyExplored)
                    { PropagateSafeZone(posOfNeighbour); }
                }

                return;
            }

            private Cursor _Cursor;
            private Board _Board;
        }
    }
}
