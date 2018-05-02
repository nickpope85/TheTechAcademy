using System;
using System.Collections.Generic;

namespace ExceptionHandling // when something goes wrong in your code
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<int> numList = new List<int>() { 42, 18, 7, 89, 123, 5 };

                Console.Write("Please pick a number to divide by: ");
                int divisor = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Dividing...");

                foreach (float num in numList)
                {
                    Console.WriteLine(num + " divided by " + divisor + " is approximately " + num / divisor);
                }

            }
            catch (FormatException forEx)
            {
                Console.WriteLine(forEx.Message);
            }
            catch (DivideByZeroException zeroEx)
            {
                Console.WriteLine(zeroEx.Message);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }



            //--------Exception handling exercise ------------


            //try
            //{
            //    Console.WriteLine("Pick a number: ");
            //    int num1 = Convert.ToInt32(Console.ReadLine());
            //    Console.WriteLine("Pick another number: ");
            //    int num2 = Convert.ToInt32(Console.ReadLine());
            //    Console.WriteLine("Dividing the two...");
            //    int num3 = num1 / num2;
            //    Console.WriteLine(num1 + " divided by " + num2 + " equals " + num3);   
            //}
            //catch (FormatException ex)
            //{
            //    Console.WriteLine("Please type a whole number.");
            //    return;
            //}
            //catch (DivideByZeroException ex)
            //{
            //    Console.WriteLine("Please don't divide by Zero."); 
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    Console.ReadLine();
            //}

        }
    }
}
