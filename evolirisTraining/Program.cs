using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolirisCSharpTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ma Console Cherie";

            MainMenu menuSession = new MainMenu();
            menuSession.Run();

            Session03.Exercise01.Main.Run();

            Console.ReadLine();
        }

    }

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
                            { selectedEntry  = 0; }
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
            foreach(string entry in menuEntries)
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
        public MainMenu() : base("Session01", "Session02", "Session03")
        { /*Do nothing*/ }

        protected override void action00() { RunSubmenu<MenuSession01>(); }
        protected override void action01() { RunSubmenu<MenuSession02>(); }
        protected override void action02() { RunSubmenu<MenuSession03>(); }
    }

    class MenuSession01 : Menu
    {
        public MenuSession01() : base("..", "Exercise01", "Exercise02", "Exercise03") { /*Do nothing*/ }
        protected override void action00() { GoToParentMenu(); }
        protected override void action01() { Session01.Exercise01.Run(); }
        protected override void action02() { Session01.Exercise02.Run(); }
        protected override void action03() { RunSubmenu<MenuSess01Exo03>(); }
    }

    class MenuSess01Exo03 : Menu
    {
        public MenuSess01Exo03() : base("..", "QuestionA", "QuestionB", "QuestionC") { /*Do nothing*/ }
        protected override void action00() { GoToParentMenu(); }
        protected override void action01() { Session01.Exercise03.QuestionA.Run(); }
        protected override void action02() { Session01.Exercise03.QuestionB.Run(); }
        protected override void action03() { Session01.Exercise03.QuestionC.Run(); }
    }

    class MenuSession02 : Menu
    {
        public MenuSession02() : base("..", "Exercise01", "Exercise02") { /*Do nothing*/ }
        protected override void action00() { GoToParentMenu(); }
        protected override void action01() { RunSubmenu<MenuSess02Exo01>(); }
        protected override void action02() { RunSubmenu<MenuSess02Exo02>(); }
    }

    class MenuSess02Exo01 : Menu
    {
        public MenuSess02Exo01()
            : base("..", "QuestionA", "QuestionB", "QuestionC", "QuestionD",
                   "QuestionE", "QuestionF") { /*Do nothing*/ }
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
            : base("..", "QuestionA", "QuestionB", "QuestionC")
        { /*Do nothing*/ }
        protected override void action00() { GoToParentMenu(); }
        protected override void action01() { Session02.Exercise02.QuestionA.Run(); }
        protected override void action02() { Session02.Exercise02.QuestionB.Run(); }
        protected override void action03() { Session02.Exercise02.QuestionC.Run(); }
    }

    class MenuSession03 : Menu
    {
        public MenuSession03() : base("..", "Exercise01") { /*Do nothing*/ }
        protected override void action00() { GoToParentMenu(); }
        protected override void action01() { Session03.Exercise01.Main.Run(); }
    }

    ///Session01 covers type conversion and branching
    ///Fri 16 March
    namespace Session01
    {
        ///Playing with *.Parse() and *.TryParse()
        ///Slide #87
        class Exercise01
        {
            static public void Run()
            {
                Console.Write("A =");
                int a = int.Parse(Console.ReadLine());

                Console.Write("B =");
                int b;
                bool isParse = int.TryParse(Console.ReadLine(), out b);

                if (isParse)
                {
                    Console.WriteLine(string.Format($"a + b = {a + b}"));
                }
                else
                {
                    Console.WriteLine("Illegal input.");
                }
            }
        }

        ///Playing with C# branching instructions
        ///Slide #97
        class Exercise02
        {
            static public void Run()
            {
                Console.Write("A=");
                int nb = int.Parse(Console.ReadLine());

                //Most naive solution
                //bool isEven = ((nb/2 + nb/2) == nb);
                //if(isEven)
                //{
                //    Console.WriteLine("Le nombre est pair");
                //}
                //else
                //{
                //    Console.WriteLine("Le nombre est impair");
                //}

                bool isEven = ((nb / 2 + nb / 2) == nb);
                string message = isEven ? "Le nombre est pair"
                                        : "Le nombre est impair";
                Console.WriteLine(message);

                // Works as well
                //bool isEven = ((nb / 2 + nb / 2) == nb);
                //switch (isEven)
                //{
                //    case true:
                //        Console.WriteLine("Le nombre est pair");
                //        break;
                //    case false:
                //        Console.WriteLine("Le nombre est impair");
                //        break;
                //}

                Console.ReadLine();
            }
        }

        ///Slide #114
        namespace Exercise03
        {
            ///Playing with explicit conversions
            class QuestionA
            {
                static public void Run()
                {
                    Console.Write("A=");
                    int nbA = int.Parse(Console.ReadLine());
                    Console.Write("B=");
                    int nbB = int.Parse(Console.ReadLine());

                    Console.WriteLine($"A  /  B = {(double)(nbA) / (double)(nbB)}");
                    Console.WriteLine($"A Div B = {nbA / nbB}");
                    Console.WriteLine($"A  %  B = {nbA % nbB}");
                }
            }

            ///Check that the checksum of a Belgian BBAN account number is correct
            ///First the checksum is computed from the inputted BBAN
            ///Then it is compared to the checksum specified in the inputted BBAN
            ///Input example: 732-0311849-45
            class QuestionB
            {
                static public void Run()
                {
                    Console.Write("BBAN=");
                    string bban = Console.ReadLine();

                    Console.WriteLine($"bban =\"{bban}\"");
                    long bbanNb = long.Parse(bban.Substring(0, 3) + bban.Substring(4, 7));
                    long bbanChecksum = long.Parse(bban.Substring(12));
                    //Console.WriteLine($"bbanNb =\"{bbanNb}\"");
                    //Console.WriteLine($"bbanChecksum =\"{bbanChecksum}\"");
                    bool isValidBban = ((bbanNb % 97) == bbanChecksum);
                    string message = isValidBban ? "OK" : "KO";
                    Console.WriteLine(message);
                }
            }

            ///Converts a Belgian BBAN account number into an IBAN account number
            ///Input example: 732-0311849-45
            class QuestionC
            {
                static public void Run()
                {
                    Console.Write("BBAN=");
                    string bban = Console.ReadLine();
                    Console.WriteLine($"bban =\"{bban}\"");

                    const string IBAN_COUNTRY = "BE";
                    long bbanNb = long.Parse(bban.Substring(0, 3) + bban.Substring(4, 7));
                    long bbanChecksum = long.Parse(bban.Substring(12));
                    //Console.WriteLine($"bbanNb =\"{bbanNb}\"");
                    //Console.WriteLine($"bbanChecksum =\"{bbanChecksum}\"");

                    long ibanChecksum = computeIbanChecksum(IBAN_COUNTRY, bbanNb,
                                                            bbanChecksum);

                    string iban = IBAN_COUNTRY + ibanChecksum.ToString()
                                  + bbanNb.ToString() + bbanChecksum.ToString();
                    Console.WriteLine($"IBAN=\"{ibanToDisplayString(iban)}\"");
                }

                static long computeIbanChecksum(string ibanCountry, long bbanNb, long bbanChecksum)
                {
                    long code = bbanNb * 100 + bbanChecksum;
                    code = code * 100 + (ibanCountry[0] - 'A' + 10);
                    code = code * 100 + (ibanCountry[1] - 'A' + 10);
                    code *= 100;
                    long ibanChecksum = code % 97 - 10;
                    //Console.WriteLine($"code=\"{code}\"");
                    //Console.WriteLine($"ibanChecksum=\"{ibanChecksum}\"");
                    return ibanChecksum;
                }

                ///Formats iban string for human-friendly display by inserting spaces
                ///between numbers
                static string ibanToDisplayString(string iban)
                {
                    return $"{iban.Substring(0, 4)} " + $"{iban.Substring(4, 4)} "
                        + $"{iban.Substring(8, 4)}  " + $"{iban.Substring(12, 4)}";
                }
            }
        }
    }

    ///Session02 covers loops, arrays and collections
    namespace Session02
    {
        ///Exercises on loops
        ///Slide #124
        namespace Exercise01
        {
            ///Computes n first terms of Fibonacci sequence
            class QuestionA
            {
                static public void Run()
                {
                    long element0 = 0;
                    long element1 = 1;
                    const int MAX_ITERATION = 25;
                    Console.Write($"Fibonacci sequence: {element0} {element1} ");
                    for (int iteration = 0; iteration < MAX_ITERATION; iteration++)
                    {
                        long newElement = element0 + element1;
                        element0 = element1;
                        element1 = newElement;
                        Console.Write($"{newElement} ");
                    }
                }
            }

            ///Computes factorial
            class QuestionB
            {
                static public void Run()
                {
                    Console.Write("Number:");
                    long argument = int.Parse(Console.ReadLine());
                    long numIterations = argument;
                    long factorial = 1;
                    for (long iteration = 1; iteration <= numIterations; iteration++)
                    {
                        factorial *= iteration;
                    }
                    Console.WriteLine($"{argument}!={factorial}");
                }
            }

            ///Find prime numbers
            class QuestionC
            {
                static public void Run()
                {
                    Console.Write("Number of prime numbers to find:");
                    int nbOfPrimesToFind = int.Parse(Console.ReadLine());

                    int[] primeNumbers = new int[nbOfPrimesToFind];
                    primeNumbers[0] = 2; //All numbers can be divided by 1 => skip it
                    int nbOfPrimesFound = 2; //Prime numbers 1 and 2 have been found already
                    int numberToTest = 3; //3 is the number following 2 i.e. the last prime found

                    Console.Write("Prime numbers:1 2 ");
                    while (nbOfPrimesFound < nbOfPrimesToFind)
                    {
                        if (isAPrimeNb(numberToTest, primeNumbers, nbOfPrimesFound))
                        {
                            int indexOfLastPrime = nbOfPrimesFound - 2;
                            primeNumbers[indexOfLastPrime + 1] = numberToTest;
                            nbOfPrimesFound++;
                            Console.Write($"{numberToTest} ");
                        }
                        //Even numbers can't possibly be prime numbers => skip them => +=2
                        numberToTest += 2;
                    }
                }

                static bool isAPrimeNb(int numberToTest, int[] primeNumbers,
                                       int nbOfPrimesFound)
                {
                    //1 must not be in primeNumbers[] because numberToTest % 1 is always 0
                    //Prime number 1 is not in primeNumbers[] => "nbOfPrimesFound-1"
                    for (int indexOfPrime = 0; indexOfPrime < nbOfPrimesFound - 1; indexOfPrime++)
                    {
                        int prime = primeNumbers[indexOfPrime];
                        if ((numberToTest % prime) == 0)
                        {
                            return false;
                        }
                    }
                    return true;
                }

            }

            ///Displays a multiplication table
            class QuestionD
            {
                static public void Run()
                {
                    const int MIN_MULTIPLICANT = 1;
                    const int MAX_MULTIPLICANT = 5;
                    const int MIN_MULTIPLIER = 1;
                    const int MAX_MULTIPLIER = 20;
                    for (int multiplicant = MIN_MULTIPLICANT;
                        multiplicant <= MAX_MULTIPLICANT; multiplicant++)
                    {
                        for (int multiplier = MIN_MULTIPLIER; multiplier <= MAX_MULTIPLIER; multiplier++)
                        {
                            Console.Write($"{multiplicant * multiplier}\t");
                        }
                        Console.Write("\n");
                    }
                }
            }

            ///Count from 0 to 20 stepping by 0.1 and using a double type
            class QuestionE
            {
                static public void Run()
                {
                    for (double counter = 0; counter < 20.0 + 0.05; counter += 0.1)
                    {
                        Console.Write($"{counter} ");
                    }
                }
            }

            ///Computes an approximation of the square root
            class QuestionF
            {
                static public void Run()
                {
                    Console.Write("Number whose square root must be computed:");
                    double argument = double.Parse(Console.ReadLine());
                    const double START_GUESS = 1.0; //Could be any positive number
                    const double TOLERANCE = 1e-10;
                    double guess = START_GUESS;
                    int errorExponent = -2; // 0.25 = 2^-2
                    double worstRelativeError = 0.25;
                    double worstAbsoluteError = 1.0; //Dummy value

                    //Absolute error = sqrt(argument)*relativeError
                    //Yet: worstRelativeError > relativeError
                    //also: if argument > 1.0 : argument > sqrt(argument)
                    //and:  if argument < 1.0 : 1.0      > sqrt(argument)
                    //Hence absoluteError < max(1.0,argument)*worstRelativeError
                    while (worstAbsoluteError > TOLERANCE)
                    {
                        guess = 0.5 * (guess + argument / guess);

                        //Compute relative error from errorExponent
                        worstRelativeError = 0.25;
                        for (int index = 0; index < -errorExponent; index++)
                        {
                            worstRelativeError = 0.5 * worstRelativeError;
                        }
                        worstAbsoluteError = computeWorstAbsoluteError(argument, worstRelativeError);
                        errorExponent = 2 * errorExponent - 1;

                        //Console.Write(".");
                        //Console.Write($"guess = {guess} ");
                        //Console.Write($"errorExponent = {errorExponent} ");
                        //Console.WriteLine($"Max absolute error = {worstAbsoluteError}");
                        //Console.ReadLine();
                    }
                    Console.WriteLine($"sqrt({argument}) = {guess}");
                    Console.WriteLine($"Max absolute error = {worstAbsoluteError}");
                }

                static double computeWorstAbsoluteError(double argument, double worstRelativeError)
                {
                    return Math.Max(1.0, argument) * worstRelativeError;
                }
            }
        }

        /// Exercises on collections
        /// Slide #140
        namespace Exercise02
        {
            /// Find prime numbers below nbMax
            /// Same as Exercise01.QuestionC but using a List<> object
            class QuestionA
            {
                static public void Run()
                {
                    Console.Write("Find prime number lesser than:");
                    int nbMax = int.Parse(Console.ReadLine());

                    List<int> primeNumbers = new List<int>();
                    primeNumbers.Add(2); //All numbers can be divided by 1 => skip it
                    int numberToTest = 3; //3 is the number following 2 i.e. the last prime found

                    Console.Write("Prime numbers:1 2 ");
                    while (numberToTest < nbMax)
                    {
                        if (isAPrimeNb(numberToTest, primeNumbers))
                        {
                            primeNumbers.Add(numberToTest);
                            Console.Write($"{numberToTest} ");
                        }
                        //Even numbers can't possibly be prime numbers => skip them => +=2
                        numberToTest += 2;
                    }
                }

                static bool isAPrimeNb(int numberToTest, List<int> primeNumbers)
                {
                    //1 must not be in primeNumbers[] because numberToTest % 1 is always 0
                    foreach (int prime in primeNumbers)
                    {
                        if ((numberToTest % prime) == 0)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }

            ///Almost identical to Exercise02.QuestionB => I'm not doing it
            class QuestionB
            {
                static public void Run()
                { /*Do nothing*/ }
            }

            /// Add two numbers digit by digit
            /// (serves no purpose, merely done as an exercise)
            class QuestionC
            {
                static public void Run()
                {
                    Console.Write("A=");
                    List<char> argA = new List<char>();
                    argA.AddRange(Console.ReadLine().ToCharArray());
                    Console.Write("B=");
                    List<char> argB = new List<char>();
                    argB.AddRange(Console.ReadLine().ToCharArray());

                    //Append zeroes to shortest array such that both arrays have same size
                    //For instance, argA = 1234 and argB = 89
                    //outputs       argA = 1234 and argB = 0089
                    int countDifference = argA.Count - argB.Count;
                    //This loop runs when capacityDifference > 0
                    //i.e. when argB is shorter than argA
                    for (int zeroNum = 0; zeroNum < +countDifference; zeroNum++)
                    {
                        argB.Insert(0, '0');
                    }
                    //This loop runs when capacityDifference < 0
                    //i.e. when argA is shorter than argB
                    //Note that final zeroNum value is *minus* countDifference
                    for (int zeroNum = 0; zeroNum < -countDifference; zeroNum++)
                    {
                        argA.Insert(0, '0');
                    }
                    //Also append a zero in front
                    //This is required by the final carry
                    //E.g. in 92 + 12 = 104 we need three digits to write the final number
                    //Hence we need to add an additional '0' i.e. argA=092 and argB=012
                    argA.Insert(0, '0');
                    argB.Insert(0, '0');

                    List<char> result = new List<char>();
                    result.AddRange(new char[argA.Count]);
                    int carry = 0;

                    //For each digit compute sum and take carry, then move to next digit
                    //Start from unit, then move to decimals, then hundreds, etc
                    int indexOfUnits = argA.Count - 1;
                    for (int digitIndex = indexOfUnits; digitIndex >= 0; digitIndex--)
                    {
                        int digitA = argA[digitIndex] - '0';
                        int digitB = argB[digitIndex] - '0';
                        int sum = digitA + digitB;
                        int digitSum = sum % 10;
                        result[digitIndex] = (char)(digitSum + carry + '0');
                        carry = sum / 10;
                    }

                    foreach (char digit in result)
                    {
                        Console.Write($"{digit}");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
    
    namespace Session03
    {
        /// Solve quadratic equation using a struct type
        /// Slide #161
        namespace Exercise01
        {
            class Main
            {
                public static void Run()
                {
                    QuadraticSolver quadraticSolver = new QuadraticSolver();

                    Console.Write("a:");
                    quadraticSolver.a = double.Parse(Console.ReadLine());
                    Console.Write("b:");
                    quadraticSolver.b = double.Parse(Console.ReadLine());
                    Console.Write("c:");
                    quadraticSolver.c = double.Parse(Console.ReadLine());

                    double? rootA, rootB; //Equivalent to "Nullable<double> rootA, rootB;"
                    bool areRootsFound = quadraticSolver.Solve(out rootA, out rootB);
                    //Usage of "var.Value" instead of "var" is recommended
                    //for nullable types (does not give access to same methods)
                    string message = (areRootsFound ?
                                      $"roots = {rootA.Value:0.000}, {rootB.Value:0.000}"
                                     : "No real root found");
                    Console.WriteLine(message);
                    Console.ReadLine();
                }
            }

            /// Solve quadratic equation
            /// a.x^2 + b.x + c = 0
            public struct QuadraticSolver
            {
                //Solves quadratic equation in the real space
                //Returns true if at least one real root has been found
                public bool Solve(out double? rootA, out double? rootB)
                {
                    double discriminant = b * b - 4.0 * a * c;

                    bool areRootsComplex = discriminant < 0.0;
                    if (areRootsComplex)
                    {
                        rootA = rootB = null;
                        return false;
                    }

                    //Works both for discriminant > 0 and =0
                    rootA = (-b - Math.Sqrt(discriminant)) * 0.5 / a;
                    rootB = (-b + Math.Sqrt(discriminant)) * 0.5 / a;
                    return true;
                }

                public double a, b, c;
            }
        }
    }
}
