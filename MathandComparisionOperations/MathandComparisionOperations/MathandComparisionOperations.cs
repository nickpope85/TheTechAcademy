using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathandComparisionOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            //int total = 5 + 10;
            //int otherTotal = 12 + 22;
            //int combined = total + otherTotal;
            //Console.WriteLine(combined);
            //Console.ReadLine();

            //int difference = 10 - 5;
            //Console.WriteLine("Ten minus five = " + difference.ToString());
            //Console.ReadLine();

            //int product = 10 * 5;
            //Console.WriteLine("Ten times five  = " + product.ToString());
            //Console.ReadLine();

            //int quotient = 100 / 5; // <-- rounds to nearest
            //Console.WriteLine(quotient);
            //Console.ReadLine();

            //double quotient2 = 100.0 / 17.0;
            //Console.WriteLine(quotient2);
            //Console.ReadLine();

            //int remainder = 11 % 2;
            //Console.WriteLine(remainder);
            //Console.ReadLine();

            // **********COMPARISON OPERATORS************

            //bool trueOrFalse = 12 < 5;
            //Console.WriteLine(trueOrFalse.ToString());
            //Console.ReadLine();

            int roomTemp = 70;
            int currentTemp = 70;

            //bool isWarm = currentTemp >= roomTemp;
            bool isWarm = currentTemp == roomTemp; // <-- operator needs to be "==" for equals of a value in bool

            Console.WriteLine(isWarm);
            Console.ReadLine();







        }
    }
}
