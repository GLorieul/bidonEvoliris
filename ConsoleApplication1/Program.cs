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

        ///Formats iban string for human-friendly display by inserting spaces
        ///between numbers
        static string ibanToDisplayString(string iban)
        {
            return $"{iban.Substring(0, 4)} " + $"{iban.Substring(4, 4)} "
                + $"{iban.Substring(8, 4)}  " + $"{iban.Substring(12, 4)}";
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
            //Input example: 732-0311849-45
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
            #endregion

            Console.ReadLine();
        }
    }
}
