using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
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

        static bool isAPrimeNb(int numberToTest, int[] primeNumbers,
                               int nbOfPrimesFound)
        {
            //Prime number 1 is not in the table => "nbOfPrimesFound-1"
            for (int indexOfPrime=0; indexOfPrime < nbOfPrimesFound-1; indexOfPrime++)
            {
                int prime = primeNumbers[indexOfPrime];
                if((numberToTest % prime) == 0)
                {
                    return false;
                }
            }
            return true;
        }

        ///Formats iban string for human-friendly display by inserting spaces
        ///between numbers
        static string ibanToDisplayString(string iban)
        {
            return $"{iban.Substring(0, 4)} " + $"{iban.Substring(4, 4)} "
                + $"{iban.Substring(8, 4)}  " + $"{iban.Substring(12, 4)}";
        }

        static double computeWorstAbsoluteError(double argument, double worstRelativeError)
        {
            return Math.Max(1.0, argument)*worstRelativeError;
        }

        static void Main(string[] args)
        {
            Console.Title = "Ma Console Cherie";

            #region exo01
            ///Playing with *.Parse() and *.TryParse()
            //Console.Write("A =");
            //int a = int.Parse(Console.ReadLine());

            //Console.Write("B =");
            //int b;
            //bool isParse = int.TryParse(Console.ReadLine(), out b);

            //if (isParse)
            //{
            //    Console.WriteLine(string.Format($"a + b = {a + b}"));
            //}
            //else
            //{
            //    Console.WriteLine("Illegal input.");
            //}
            #endregion

            #region exo02
            /// Playing with C# branching instructions
            //Console.Write("A=");
            //int nb = int.Parse(Console.ReadLine());

            ////Most naive solution
            ////bool isEven = ((nb/2 + nb/2) == nb);
            ////if(isEven)
            ////{
            ////    Console.WriteLine("Le nombre est pair");
            ////}
            ////else
            ////{
            ////    Console.WriteLine("Le nombre est impair");
            ////}

            //bool isEven = ((nb / 2 + nb / 2) == nb);
            //string message = isEven ? "Le nombre est pair"
            //                        : "Le nombre est impair";
            //Console.WriteLine(message);

            //// Works as well
            ////bool isEven = ((nb / 2 + nb / 2) == nb);
            ////switch (isEven)
            ////{
            ////    case true:
            ////        Console.WriteLine("Le nombre est pair");
            ////        break;
            ////    case false:
            ////        Console.WriteLine("Le nombre est impair");
            ////        break;
            ////}

            //Console.ReadLine();
            #endregion

            #region exo02_questionA
            ///Playing with explicit conversions
            //Console.Write("A=");
            //int nbA = int.Parse(Console.ReadLine());
            //Console.Write("B=");
            //int nbB = int.Parse(Console.ReadLine());

            //Console.WriteLine($"A  /  B = {(double)(nbA)/(double)(nbB)}");
            //Console.WriteLine($"A Div B = {nbA / nbB}");
            //Console.WriteLine($"A  %  B = {nbA % nbB}");
            #endregion

            #region exo02_questionB
            ///Check that the checksum of a Belgian BBAN account number is correct
            ///First the checksum is computed from the inputted BBAN
            ///Then it is compared to the checksum specified in the inputted BBAN
            /// 
            ////732-0311849-45
            //Console.Write("BBAN=");
            //string bban = Console.ReadLine();

            //Console.WriteLine($"bban =\"{bban}\"");
            //long bbanNb = long.Parse(bban.Substring(0, 3) + bban.Substring(4, 7));
            //long bbanChecksum = long.Parse(bban.Substring(12));
            ////Console.WriteLine($"bbanNb =\"{bbanNb}\"");
            ////Console.WriteLine($"bbanChecksum =\"{bbanChecksum}\"");
            //bool isValidBban = ((bbanNb % 97) == bbanChecksum);
            //string message = isValidBban ? "OK" : "KO";
            //Console.WriteLine(message);
            #endregion
            #region exo02_questionC
            ///Converts a Belgian BBAN account number into an IBAN account number
            ////Input example: 732-0311849-45
            //Console.Write("BBAN=");
            //string bban = Console.ReadLine();
            //Console.WriteLine($"bban =\"{bban}\"");

            //const string IBAN_COUNTRY = "BE";
            //long bbanNb = long.Parse(bban.Substring(0, 3) + bban.Substring(4, 7));
            //long bbanChecksum = long.Parse(bban.Substring(12));
            ////Console.WriteLine($"bbanNb =\"{bbanNb}\"");
            ////Console.WriteLine($"bbanChecksum =\"{bbanChecksum}\"");

            //long ibanChecksum = computeIbanChecksum(IBAN_COUNTRY, bbanNb,
            //                                        bbanChecksum);

            //string iban = IBAN_COUNTRY + ibanChecksum.ToString()
            //              + bbanNb.ToString() + bbanChecksum.ToString();
            //Console.WriteLine($"IBAN=\"{ibanToDisplayString(iban)}\"");
            #endregion

            #region session02_exo01_A
            ///Computes n first terms of Fibonacci sequence
            //long element0 = 0;
            //long element1 = 1;
            //const int MAX_ITERATION = 25;
            //Console.Write($"Fibonacci sequence: {element0} {element1} ");
            //for (int iteration = 0; iteration < MAX_ITERATION; iteration++)
            //{
            //    long newElement = element0 + element1;
            //    element0 = element1;
            //    element1 = newElement;
            //    Console.Write($"{newElement} ");
            //}
            #endregion

            #region session02_exo01_B
            ///Computes factorial
            //Console.Write("Number:");
            //long argument = int.Parse(Console.ReadLine());
            //long numIterations = argument;
            //long factorial=1;
            //for (long iteration=1; iteration <= numIterations ; iteration++)
            //{
            //    factorial *= iteration;
            //}
            //Console.WriteLine($"{argument}!={factorial}");
            #endregion

            #region session02_exo01_C
            ///Find prime numbers
            //Console.Write("Number of prime numbers to find:");
            //int nbOfPrimesToFind = int.Parse(Console.ReadLine());

            //int[] primeNumbers = new int[nbOfPrimesToFind];
            //primeNumbers[0] = 2; //All numbers can be divided by 1 => skip it
            //int nbOfPrimesFound = 2; //Prime numbers 1 and 2 have been found already
            //int numberToTest = 3; //3 is the number following 2 i.e. the last prime found

            //Console.Write("Prime numbers:1 2 ");
            //while (nbOfPrimesFound < nbOfPrimesToFind)
            //{
            //    if(isAPrimeNb(numberToTest, primeNumbers, nbOfPrimesFound))
            //    {
            //        int indexOfLastPrime = nbOfPrimesFound - 2;
            //        primeNumbers[indexOfLastPrime + 1] = numberToTest;
            //        nbOfPrimesFound++;
            //        Console.Write($"{numberToTest} ");
            //    }
            //    //Even numbers can't possibly be prime numbers => skip them => +=2
            //    numberToTest += 2;
            //}
            #endregion

            #region session02_exo01_D
            ///Displays a multiplication table
            //const int MIN_MULTIPLICANT = 1;
            //const int MAX_MULTIPLICANT = 5;
            //const int MIN_MULTIPLIER   = 1;
            //const int MAX_MULTIPLIER   = 20;
            //for (int multiplicant = MIN_MULTIPLICANT;
            //    multiplicant <= MAX_MULTIPLICANT; multiplicant++)
            //{
            //    for (int multiplier = MIN_MULTIPLIER; multiplier <= MAX_MULTIPLIER; multiplier++)
            //    {
            //        Console.Write($"{multiplicant*multiplier}\t");
            //    }
            //    Console.Write("\n");
            //}
            #endregion

            #region session02_exo01_E
            ///Count from 0 to 20 stepping by 0.1 and using a double type
            //for(double counter=0; counter < 20.0 + 0.05; counter+=0.1)
            //{
            //    Console.Write($"{counter} ");
            //}
            #endregion

            #region session02_exo01_F
            ///Computes an approximation of the square root
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
                guess = 0.5 * (guess + argument/guess);

                //Compute relative error from errorExponent
                worstRelativeError = 0.25;
                for (int index = 0; index < -errorExponent; index++)
                {
                    worstRelativeError = 0.5*worstRelativeError;
                }
                worstAbsoluteError = computeWorstAbsoluteError(argument, worstRelativeError);
                errorExponent = 2 * errorExponent - 1;

                Console.Write(".");
                //Console.Write($"guess = {guess} ");
                //Console.Write($"errorExponent = {errorExponent} ");
                //Console.WriteLine($"Max absolute error = {worstAbsoluteError}");
                //Console.ReadLine();
            }
            Console.WriteLine($"sqrt({argument}) = {guess}");
            Console.WriteLine($"Max absolute error = {worstAbsoluteError}");
            #endregion

            Console.ReadLine();
        }
    }
}
