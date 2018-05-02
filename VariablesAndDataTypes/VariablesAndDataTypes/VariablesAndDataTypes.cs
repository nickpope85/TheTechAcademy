using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariablesAndDataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("What is your name?"); // this is a simple program
            //string yourName = Console.ReadLine();
            //Console.WriteLine("Your name is " + yourName + "!");
            //Console.ReadLine(); // comments are CTL + K + C

            //Console.WriteLine("What is your favorite number?");
            //string favoriteNumber = Console.ReadLine();
            //int favNum = Convert.ToInt32(favoriteNumber);
            //int total = favNum + 5;
            //Console.WriteLine("Your favorite number plus 5 is " + total);
            //Console.ReadLine();

            bool isStudying = false;
            byte hoursWorked = 42;
            sbyte curentTemp = -23;
            char questionMark = '\u2103'; // <-- unicode for question mark
            decimal monies = 100.5m; // <-- decimel needs "m" at end
            double heightInCM = 30.6785;
            float secLeft = 2.62f; // <-- Float requires and "f" at end

            int currentAge = 40;
            string yearsOld = currentAge.ToString();

            bool isRaining = true;
            string rainingStatus = Convert.ToString(isRaining);
            Console.WriteLine(rainingStatus);
            Console.ReadLine();

        }
    }
}
