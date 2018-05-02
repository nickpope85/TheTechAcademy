using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page35Drill
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter a number: ");
            int numInput = Convert.ToInt32(Console.ReadLine());
            int addReturn;
            int subReturn;
            int timesReturn;


            Methods n = new Methods();

            addReturn = n.Added(numInput);
            Console.WriteLine(numInput + " + 5 equals " + addReturn);

            subReturn = n.Subtracted(numInput);
            Console.WriteLine("100 - " + numInput + " equals " + subReturn);

            timesReturn = n.Times(numInput);
            Console.WriteLine(numInput + " x 1000 equals " + timesReturn);

            Console.ReadLine();

        }
    }
}
