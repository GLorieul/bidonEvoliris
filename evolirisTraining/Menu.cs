using System;
using System.Collections.Generic;

namespace EvolirisCSharpTraining
{
    /// Bonus exercise: make a menu to select exercises
    ///
    ///The Menu class is a framework
    ///Client code must define a MyMenu class such that:
    ///  - MyMenu inherits from Menu
    ///  - MyMenu constructor:
    ///     - typically doesn't require arguments
    ///     - but calls Menu constructor with the proper parameters
    ///       that specify the names of the menu entries
    ///  - MyMenu implements the action00() to action09() member functions
    ///     - action00() is called when the first menu entry is selected,
    ///       action01() when second menu entry is selected, etc.
    ///     - If a menu only has three items then only action00() to
    ///       action02() need to be implemented
    class Menu
    {
        public Menu(params string[] menuEntriesVal)
        {
            if (menuEntriesVal.Length > 10)
            { Console.WriteLine("Menu objects can have at most 10 items"); }

            menuEntries = new List<string>();
            menuEntries.AddRange(menuEntriesVal);
        }

        private bool isMenuAlive = true;
        private int selectedEntry = 0;
        private List<string> menuEntries;

        public void Run()
        {
            ResetMenu();

            while (isMenuAlive)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        selectedEntry++;
                        if (selectedEntry >= menuEntries.Count)
                        { selectedEntry = 0; }
                        Console.SetCursorPosition(0, selectedEntry);
                        System.Threading.Thread.Sleep(100);
                        break;
                    case ConsoleKey.UpArrow:
                        selectedEntry--;
                        if (selectedEntry < 0)
                        { selectedEntry = menuEntries.Count - 1; }
                        Console.SetCursorPosition(0, selectedEntry);
                        System.Threading.Thread.Sleep(100);
                        break;
                    case ConsoleKey.Enter:
                        ExecuteAction(selectedEntry);
                        ResetMenu();
                        break;
                }
            }
        }

        public void DisplayMenuItems()
        {
            foreach (string entry in menuEntries)
            {
                Console.WriteLine($"  {entry}");
            }
        }

        public void ResetMenu()
        {
            selectedEntry = 0;
            Console.Clear();
            DisplayMenuItems();
            Console.SetCursorPosition(0, 0);
        }

        //The action*() functions are the framework's hotspots
        //They must be overridden by the child class so that
        //the selecting a menu entry triggers the expected action
        //By default the action*() functions trigger ActionDefault()
        protected virtual void action00() { ActionDefault(); }
        protected virtual void action01() { ActionDefault(); }
        protected virtual void action02() { ActionDefault(); }
        protected virtual void action03() { ActionDefault(); }
        protected virtual void action04() { ActionDefault(); }
        protected virtual void action05() { ActionDefault(); }
        protected virtual void action06() { ActionDefault(); }
        protected virtual void action07() { ActionDefault(); }
        protected virtual void action08() { ActionDefault(); }
        protected virtual void action09() { ActionDefault(); }

        ///Default action is an error message
        protected void ActionDefault()
        {
            Console.Clear();
            Console.WriteLine("No action implemented for that menu entry.");
            Console.ReadLine();
            Run();
        }

        private void ExecuteAction(int selectedEntry)
        {
            Console.Clear();
            switch (selectedEntry)
            {
                case 0: action00(); break;
                case 1: action01(); break;
                case 2: action02(); break;
                case 3: action03(); break;
                case 4: action04(); break;
                case 5: action05(); break;
                case 6: action06(); break;
                case 7: action07(); break;
                case 8: action08(); break;
                case 9: action09(); break;
            }
        }

        protected void GoToParentMenu()
        { isMenuAlive = false; }

        protected void RunSubmenu<MenuT>()
            where MenuT : Menu, new()
        {
            MenuT menu = new MenuT();
            menu.Run();
        }
    }

    class MainMenu : Menu
    {
        public MainMenu()
            : base("Session01: Type conversion and branching (Fri 16 March)",
                  "Session02: Loops, arrays and collections (Mon 19 March)",
                  "Session03: Functions, structs and enumerations (Tue 20 March)")
        { /*Do nothing*/ }

        protected override void action00() { RunSubmenu<MenuSession01>(); }
        protected override void action01() { RunSubmenu<MenuSession02>(); }
        protected override void action02() { RunSubmenu<MenuSession03>(); }
    }

    class MenuSession01 : Menu
    {
        public MenuSession01()
            : base("..",
                  "Exercise01: Parsing from console input with *.Parse() and *.TryParse()",
                  "Exercise02: Telling whether number is odd or even",
                  "Exercise03: Conversions and playing with BBAN & IBAN numbers")
        { /*Do nothing*/ }

        protected override void action00() { GoToParentMenu(); }
        protected override void action01() { Session01.Exercise01.Run(); }
        protected override void action02() { Session01.Exercise02.Run(); }
        protected override void action03() { RunSubmenu<MenuSess01Exo03>(); }
    }

    class MenuSess01Exo03 : Menu
    {
        public MenuSess01Exo03()
            : base("..",
                  "QuestionA: Explicit conversions",
                  "QuestionB: Check that checksum of Belgian BBAN account number is correct",
                  "QuestionC: Converts Belgian BBAN into IBAN account number")
        { /*Do nothing*/ }

        protected override void action00() { GoToParentMenu(); }
        protected override void action01() { Session01.Exercise03.QuestionA.Run(); }
        protected override void action02() { Session01.Exercise03.QuestionB.Run(); }
        protected override void action03() { Session01.Exercise03.QuestionC.Run(); }
    }

    class MenuSession02 : Menu
    {
        public MenuSession02()
            : base("..",
                  "Exercise01: Loops",
                  "Exercise02: Collections")
        { /*Do nothing*/ }

        protected override void action00() { GoToParentMenu(); }
        protected override void action01() { RunSubmenu<MenuSess02Exo01>(); }
        protected override void action02() { RunSubmenu<MenuSess02Exo02>(); }
    }

    class MenuSess02Exo01 : Menu
    {
        public MenuSess02Exo01()
            : base("..",
                  "QuestionA: Computes n first terms of Fibonacci sequence",
                  "QuestionB: Computes factorial of a number",
                  "QuestionC: Find n first prime numbers",
                  "QuestionD: Displays a multiplication table",
                  "QuestionE: Count from 0 to 20 stepping by 0.1 and using a double type",
                  "QuestionF: Computes an approximation of the square root")
        { /*Do nothing*/ }

        protected override void action00() { GoToParentMenu(); }
        protected override void action01() { Session02.Exercise01.QuestionA.Run(); }
        protected override void action02() { Session02.Exercise01.QuestionB.Run(); }
        protected override void action03() { Session02.Exercise01.QuestionC.Run(); }
        protected override void action04() { Session02.Exercise01.QuestionD.Run(); }
        protected override void action05() { Session02.Exercise01.QuestionE.Run(); }
        protected override void action06() { Session02.Exercise01.QuestionF.Run(); }
    }

    class MenuSess02Exo02 : Menu
    {
        public MenuSess02Exo02()
            : base("..",
                  "QuestionA: Find prime numbers below nbMax",
                  "QuestionB: Find n first prime numbers",
                  "QuestionC: Add two numbers digit by digit")
        { /*Do nothing*/ }

        protected override void action00() { GoToParentMenu(); }
        protected override void action01() { Session02.Exercise02.QuestionA.Run(); }
        protected override void action02() { Session02.Exercise02.QuestionB.Run(); }
        protected override void action03() { Session02.Exercise02.QuestionC.Run(); }
    }

    class MenuSession03 : Menu
    {
        public MenuSession03()
            : base("..",
                 "Exercise01: Solve quadratic equation using a struct type")
        { /*Do nothing*/ }

        protected override void action00() { GoToParentMenu(); }
        protected override void action01() { Session03.Exercise01.Main.Run(); }
    }
}
