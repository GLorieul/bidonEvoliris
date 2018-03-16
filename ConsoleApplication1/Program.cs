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
            Console.WriteLine($"code=\"{code}\"");
            Console.WriteLine($"ibanChecksum=\"{ibanChecksum}\"");
            return ibanChecksum;
        }

        static void Main(string[] args)
        {
            Console.Title = "Ma Console Cherie";

            #region QuestionA
            //Console.Write("A=");
            //int nbA = int.Parse(Console.ReadLine());
            //Console.Write("B=");
            //int nbB = int.Parse(Console.ReadLine());

            //Console.WriteLine($"A  /  B = {(double)(nbA)/(double)(nbB)}");
            //Console.WriteLine($"A Div B = {nbA / nbB}");
            //Console.WriteLine($"A  %  B = {nbA % nbB}");
            #endregion

            #region QuestionB
            //Console.Write("BBAN=");
            //string bban = Console.ReadLine();

            //Console.WriteLine($"bban =\"{bban}\"");
            //long bbanNb       = long.Parse(bban.Substring(0,10));
            //int  bbanChecksum = int.Parse(bban.Substring(10));
            ////Console.WriteLine($"bbanNb =\"{bbanNb}\"");
            ////Console.WriteLine($"bbanChecksum =\"{bbanChecksum}\"");
            //bool isValidBban = ((bbanNb % 97) == bbanChecksum);
            //string message = isValidBban ? "OK" : "KO";
            //Console.WriteLine(message);
            #endregion

            #region QuestionC
            /*
            Console.Write("BBAN=");
            string bban = Console.ReadLine();
            Console.WriteLine($"bban =\"{bban}\"");

            const string ibanCountry = "BE";
            long bbanNb       = long.Parse(bban.Substring(0, 10));
            long bbanChecksum = long.Parse(bban.Substring(10));
            //Console.WriteLine($"bbanNb =\"{bbanNb}\"");
            //Console.WriteLine($"bbanChecksum =\"{bbanChecksum}\"");
            
            long ibanChecksum = computeIbanChecksum(ibanCountry, bbanNb,
                                                    bbanChecksum);

            string iban = ibanCountry + ibanChecksum.ToString()
                          + bbanNb.ToString() + bbanChecksum.ToString();
            Console.WriteLine($"IBAN=\"{iban}\"");
            */
            #endregion

            Console.ReadLine();
        }
    }
}
