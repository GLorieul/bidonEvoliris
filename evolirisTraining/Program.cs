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

            //Session01.exercice01();
            //Session01.exercice02();
            //Session01.exercice02_questionA();
            //Session01.exercice02_questionB();
            //Session01.exercice02_questionC();

            //Session02.exercice01_questionA();
            //Session02.exercice01_questionB();
            //Session02.exercice01_questionC();
            //Session02.exercice01_questionD();
            //Session02.exercice01_questionE();
            //Session02.exercice01_questionF();

            //Session02.exercice02_questionA();
            //Session02.exercice02_questionB();
            Session02.exercice02_questionC();

            Console.ReadLine();
        }
    }

    ///Session01 covers type conversion and branching
    class Session01
    {
        ///Playing with *.Parse() and *.TryParse()
        static public void exercice01()
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

        ///Playing with C# branching instructions
        static public void exercice02()
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

        ///Playing with explicit conversions
        static public void exercice02_questionA()
        {
            Console.Write("A=");
            int nbA = int.Parse(Console.ReadLine());
            Console.Write("B=");
            int nbB = int.Parse(Console.ReadLine());

            Console.WriteLine($"A  /  B = {(double)(nbA) / (double)(nbB)}");
            Console.WriteLine($"A Div B = {nbA / nbB}");
            Console.WriteLine($"A  %  B = {nbA % nbB}");
        }

        ///Check that the checksum of a Belgian BBAN account number is correct
        ///First the checksum is computed from the inputted BBAN
        ///Then it is compared to the checksum specified in the inputted BBAN
        ///Input example: 732-0311849-45
        static public void exercice02_questionB()
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

        ///Converts a Belgian BBAN account number into an IBAN account number
        ///Input example: 732-0311849-45
        static public void exercice02_questionC()
        {
            //Input example: 732-0311849-45
            Console.Write("BBAN=");
            string bban = Console.ReadLine();
            Console.WriteLine($"bban =\"{bban}\"");

            const string IBAN_COUNTRY = "BE";
            long bbanNb       = long.Parse(bban.Substring(0, 3) + bban.Substring(4, 7));
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

    ///Session02 covers loops, arrays and collections
    class Session02
    {
        ///Computes n first terms of Fibonacci sequence
        static public void exercice01_questionA()
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

        ///Computes factorial
        static public void exercice01_questionB()
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

        ///Find prime numbers
        static public void exercice01_questionC()
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

        ///Displays a multiplication table
        static public void exercice01_questionD()
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

        ///Count from 0 to 20 stepping by 0.1 and using a double type
        static public void exercice01_questionE()
        {
            for (double counter = 0; counter < 20.0 + 0.05; counter += 0.1)
            {
                Console.Write($"{counter} ");
            }
        }

        ///Computes an approximation of the square root
        static public void exercice01_questionF()
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

        ///Find prime numbers below nbMax
        ///Same as exercice01_questionC() but using a List<> object
        static public void exercice02_questionA()
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

        ///Almost identical to exercice02_questionB() => I'm not doing it
        static public void exercice02_questionB()
        { /*Do nothing*/ }

        /// Add two numbers digit by digit
        /// (serves no purpose, merely done as an exercice)
        static public void exercice02_questionC()
        {
            Console.Write("A=");
            List<char> argA = new List<char>();
            argA.AddRange(Console.ReadLine().ToCharArray());
            Console.Write("B=");
            List<char> argB = new List<char>();
            argB.AddRange( Console.ReadLine().ToCharArray() );

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

        static double computeWorstAbsoluteError(double argument, double worstRelativeError)
        {
            return Math.Max(1.0, argument) * worstRelativeError;
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

    class Session03
    {
        static public void exercice01()
        {
            //To do
        }
    }
}
