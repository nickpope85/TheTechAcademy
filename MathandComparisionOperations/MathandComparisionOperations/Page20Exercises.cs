using System;

namespace MathandComparisionOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number: ");
            string userNumber = Console.ReadLine();
            int userNum = Convert.ToInt32(userNumber);
            int total = userNum * 50;
            Console.WriteLine("Your number mulitplied by 50 is " + total);
            Console.ReadLine();

            Console.WriteLine("Please enter a number: ");
            string addNumber = Console.ReadLine();
            int addNum = Convert.ToInt32(addNumber);
            int addTotal = addNum + 25;
            Console.WriteLine("Your number plus 25 is " + addTotal);
            Console.ReadLine();

            Console.WriteLine("Please enter a number: ");
            string divNumber = Console.ReadLine();
            double divNum = Convert.ToDouble(divNumber);
            double divTotal = divNum / 12.5;
            Console.WriteLine("Your number divided by 12.5 is " + divTotal);
            Console.ReadLine();

            Console.WriteLine("Please enter a number: ");
            string nextNumber = Console.ReadLine();
            int nextNum = Convert.ToInt32(nextNumber);
            bool nextStatus = nextNum > 50;
            Console.WriteLine("Is your number greater than 50?: " + nextStatus);
            Console.ReadLine();

            Console.WriteLine("Please enter a number: ");
            string remNumber = Console.ReadLine();
            double remNum = Convert.ToDouble(remNumber);
            double remTotal = remNum % 7;
            Console.WriteLine("The remainder of your number divided by 7 is " + remTotal);
            Console.ReadLine();

            ////////////////////////////////////////////////////////////////////////////////


            bool first = 3 > 2;
            bool second = 5 > 4;
            if (first & second)
                Console.WriteLine("The AND evaluation is True");
            else
                Console.WriteLine("The AND evaluation is false");
            Console.ReadLine();

            if (first | second)
                Console.WriteLine("The OR evaluation is True");
            else
                Console.WriteLine("The OR evaluation is false");
            Console.ReadLine();

            int third = 2 + 2;
            bool fourth = third != 5;
            Console.Write(fourth);
            Console.ReadLine();
 
        }
    }
}
