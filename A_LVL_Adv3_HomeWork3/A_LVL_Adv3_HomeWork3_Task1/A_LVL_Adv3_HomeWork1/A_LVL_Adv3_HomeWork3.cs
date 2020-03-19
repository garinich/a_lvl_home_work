using System;
using A_LVL_Adv3_HomeWork3_DLL;

namespace A_LVL_Adv3_HomeWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            FizzBuzz();
        }

        public static void FizzBuzz()
        {
            Console.Clear();

            // Get variables

            int start = GetVariable("Enter start number: ");
            int end = GetVariable("Enter end number: ");
            int primeFactors = GetVariable("Enter the number of prime factors: ");
            int[] primeFactorsArray = new int[primeFactors];

            for (int i = 0; i < primeFactors; i++)
            {
                primeFactorsArray[i] = GetVariable(String.Format("Enter the prime factor #{0}: ", i + 1), true);
            }

            // Show results

            for (int i = start; i <= end; i++)
            {
                if (CustomMath.CheckFizzBuzz(i, primeFactorsArray))
                {
                    Console.WriteLine("FizzBuzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }

            // Check more

            Console.Write("Do you want more? (\"y\" or \"n\"): ");
            string more = Console.ReadLine();
            while (!more.Equals("y") && !more.Equals("n"))
            {
                Console.Write("Only \"y\" or \"n\": ");
                more = Console.ReadLine();
            }

            if (more.Equals("y"))
            {
                FizzBuzz();
            }
        }

        public static int GetVariable(string text, bool checkPrime = false)
        {
            Console.Write(text);
            string variable = Console.ReadLine();
            int parsedVar;

            if(!int.TryParse(variable, out parsedVar))
            {
                Console.WriteLine("Only numbers are available for input!");
                return GetVariable(text, checkPrime);
            }

            if (checkPrime && !CustomMath.CheckPrime(parsedVar))
            {
                Console.WriteLine("{0} is not a prime!", parsedVar);
                return GetVariable(text, checkPrime);
            }

            return parsedVar;
        }
    }
}
