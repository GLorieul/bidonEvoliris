using System;
using System.Collections.Generic;

namespace EvolirisCSharpTraining
{
    public enum TypeErrorCode { GENERIC_ERROR=1 }

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

        public class TilePosition
        {
            public TilePosition(int rowVal, int columnVal)
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

                //_Data is padded with one "ghost node" on each side of the board
                //This allows to safely search for tile neighbours anywhere whithin board
                Tile bidon = new Tile();
                Tile[] bidonArray = new Tile[2];
                bidonArray[0] = new Tile();
                _Data = new Tile[NbRows + 2, NbColumns + 2];
                //foreach(Tile tile in _Data)
                //{ tile = new Tile(); }
                for (int row = -1; row < NbRows + 1; row++)
                {
                    for (int column = -1; column < NbColumns + 1; column++)
                    {
                        _Data[row + 1, column + 1] = new Tile();
                    }
                }
                //for (int row = -1; row < NB_ROWS; row++)
                //{
                //    for (int column = -1; column < NB_COLUMNS; column++)
                //    {
                //        GetTile(row, column) = new Tile();
                //    }
                //}

                Random randomNbGenerator = new Random();
                int nbMinesPlaced = 0;
                while (nbMinesPlaced < nbMinesToPlace)
                {
                    int mineRow = randomNbGenerator.Next(0, NbRows);
                    int mineColumn = randomNbGenerator.Next(0, NbColumns);
                    TilePosition minePosition = new TilePosition(mineRow, mineColumn);

                    bool isTileAlreadyMined = GetTile(minePosition).IsMined();
                    if (isTileAlreadyMined)
                    { continue; }

                    //Console.WriteLine($"Placed mine at {mineRow}, {mineColumn}");
                    GetTile(minePosition).PlaceMine();
                    nbMinesPlaced++;
                }
            }

            public List<TilePosition> GetPosOfNeighbours(TilePosition tilePos)
            {
                //At first do not care whether the neighbour is within the board or not
                List<TilePosition> posOfNeighboursUnfiltered = new List<TilePosition>();
                posOfNeighboursUnfiltered.Add(new TilePosition(tilePos.Row - 1, tilePos.Column - 1));
                posOfNeighboursUnfiltered.Add(new TilePosition(tilePos.Row - 1, tilePos.Column - 1));
                posOfNeighboursUnfiltered.Add(new TilePosition(tilePos.Row - 1, tilePos.Column));
                posOfNeighboursUnfiltered.Add(new TilePosition(tilePos.Row - 1, tilePos.Column + 1));
                posOfNeighboursUnfiltered.Add(new TilePosition(tilePos.Row, tilePos.Column - 1));
                posOfNeighboursUnfiltered.Add(new TilePosition(tilePos.Row, tilePos.Column + 1));
                posOfNeighboursUnfiltered.Add(new TilePosition(tilePos.Row + 1, tilePos.Column - 1));
                posOfNeighboursUnfiltered.Add(new TilePosition(tilePos.Row + 1, tilePos.Column));
                posOfNeighboursUnfiltered.Add(new TilePosition(tilePos.Row + 1, tilePos.Column + 1));

                //Then filter out the neighbours that are outside of board
                List<TilePosition> posOfNeighbours = new List<TilePosition>();
                foreach (TilePosition eachPos in posOfNeighboursUnfiltered)
                {
                    if (this.ContainsTilePos(eachPos))
                    { posOfNeighbours.Add(eachPos); }
                }

                return posOfNeighbours;
            }

            public bool ContainsTilePos(TilePosition tilePosition)
            {
                return (tilePosition.Row >= 0) && (tilePosition.Row < NbRows)
                    && (tilePosition.Column >= 0) && (tilePosition.Column < NbColumns);
            }

            public Tile GetTile(int row, int column)
            { return _Data[row + 1, column + 1]; }

            public Tile GetTile(TilePosition tilePosition)
            { return GetTile(tilePosition.Row, tilePosition.Column); }

            public Tile GetTileTmp(TilePosition minePosition)
            { return _Data[minePosition.Row, minePosition.Column]; }

            /// <summary>
            /// Displays board on screen
            /// </summary>
            public void Display()
            {
                //Put cursor back at console's (0,0) so that new array rewrites old array.
                //Better than Console.Clear() because the latter makes the display blink.
                Console.SetCursorPosition(0, 0);

                //Display is written from top to bottom
                //I.e. start with last row and move down to first row
                int lastRow = NbRows - 1;
                for (int numRow = lastRow; numRow >= 0; numRow--)
                {
                    for (int numColumn = 0; numColumn < NbColumns; numColumn++)
                    {
                        Tile currentTile = GetTile(new TilePosition(numRow, numColumn));
                        TilePosition currentPos = new TilePosition(numRow, numColumn);
                        Console.Write(this.DisplayTile(currentTile, currentPos));
                    }
                    Console.WriteLine();
                }
            }

            /// <summary>
            /// Returns the one-character string to dispaly for a given tile
            /// </summary>
            /// <returns>One-character string to display</returns>
            private string DisplayTile(Tile tile, TilePosition tilePosition)
            {
                string tileString = tile.toString();

                if (tileString != "#")
                { return tileString; }

                //Determine which number to display
                int nbNeighbouringMines = CountNeighbouringMines(tilePosition);
                if (nbNeighbouringMines == 0)
                { return "-"; }
                else
                { return nbNeighbouringMines.ToString("0"); }
            }

            /// <summary>
            /// Returns a List<Tile> of the 8 Tile neighbours of a give Tile
            /// </summary>
            /// <param name="currentPos">Position of tile whose neighbours must be found</param>
            /// <returns>A List<Tile> of all neighbours of tile</param></returns>
            private List<Tile> GetTileNeighbours(TilePosition currentPos)
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

            public int CountNeighbouringMines(TilePosition tilePosition)
            {
                int nbMines = 0;
                foreach (Tile neighbour in GetTileNeighbours(tilePosition))
                {
                    if (neighbour.IsMined())
                    { nbMines++; }
                }
                return nbMines;
            }

            private Tile[,] _Data;
            public int NbRows { get; }
            public int NbColumns { get; }
            public enum TypeTileType { Clear, Mine };
            public enum TypeTileStatus { Unexplored, Explored, Flagged };

            /// <summary>
            /// One of the tiles of the board.
            /// A tile can contain a mine or not.
            /// A tile can be flagged, explored or unexplored.
            /// </summary>
            public class Tile
            {
                public Tile()
                { /*Do nothing*/ }

                public bool IsMined()
                { return (TileType == TypeTileType.Mine); }

                public bool IsExplored()
                { return (TileStatus == TypeTileStatus.Explored); }

                public void Explore()
                { TileStatus = TypeTileStatus.Explored; }

                /// <summary>
                /// Returns one-character string corresponding to what must be displayed
                /// </summary>
                /// <returns>Returns one-character string if not a number, returns "#" if is a number</returns>
                public string toString()
                {
                    switch (TileStatus)
                    {
                        case TypeTileStatus.Unexplored:
                            return "O";
                        case TypeTileStatus.Flagged:
                            return "F";
                        case TypeTileStatus.Explored:
                            switch (TileType)
                            {
                                case TypeTileType.Mine:
                                    return "*";
                                case TypeTileType.Clear:
                                    return "#";
                                default: Environment.Exit((int)TypeErrorCode.GENERIC_ERROR); return "";
                            }
                        default: Environment.Exit((int)TypeErrorCode.GENERIC_ERROR); return "";
                    }
                }

                public void PlaceMine()
                { TileType = TypeTileType.Mine; }

                private TypeTileType TileType = TypeTileType.Clear;
                private TypeTileStatus TileStatus = TypeTileStatus.Unexplored;
            }
        }

        class Cursor : TilePosition
        {
            public Cursor() :base(0,0)
            { /*Do nothing*/ }

            public void Refresh(Board board)
            { PlaceOnTile(this, board); }

            public void PlaceOnTile(TilePosition tilePosition, Board board)
            {
                int cursorX = tilePosition.Column;
                int cursorY = board.NbRows - 1 - tilePosition.Row;
                Console.SetCursorPosition(cursorX, cursorY);
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

                TilePosition startingTile = new TilePosition(0, 0);
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
                        case ConsoleKey.Enter: ExploreCurrentTile(isGameContinuing); break;
                        //Del = reset
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

                //_Board.GetTile(_Cursor).Explore();

                PropagateSafeZone(_Cursor);

                _Board.Display();
                _Cursor.Refresh(_Board);
            }

            public void PropagateSafeZone(TilePosition centerOfPropagation)
            {
                //Explore the current tile
                _Board.GetTile(centerOfPropagation).Explore();

                //Propagation stops when one of the cell's neighbour is a mine
                int nbNeighbouringMines = _Board.CountNeighbouringMines(centerOfPropagation);
                bool isNeighbourWithMine = (nbNeighbouringMines > 0);
                if (isNeighbourWithMine)
                { return; }

                //Propagate to all neighbours
                List<TilePosition> posOfNeighbours = _Board.GetPosOfNeighbours(centerOfPropagation);
                foreach (TilePosition posOfNeighbour in posOfNeighbours)
                {
                    bool isNeighbourAlreadyExplored = _Board.GetTile(posOfNeighbour).IsExplored();
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
