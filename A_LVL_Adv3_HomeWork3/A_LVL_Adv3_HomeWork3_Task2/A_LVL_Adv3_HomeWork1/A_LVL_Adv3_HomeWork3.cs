using System;
using A_LVL_Adv3_HomeWork3_DLL;

namespace A_LVL_Adv3_HomeWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] skierTable = new int[0][];
            Skier(skierTable);
        }

        public static void Skier(int[][] skierTable)
        {
            Console.Clear();

            // Show skier table

            if (skierTable.Length > 0)
            {
                Console.WriteLine("         \tX\tY\tZ\tDays ");
                Console.WriteLine(SkierLib.GetTable(skierTable));
            }

            // Get variables

            int varX = GetVariable("Enter variable \"X\": ");
            int varY = GetVariable("Enter variable \"Y\": ");
            int varZ = GetVariable("Enter variable \"Z\": ");

            int days = SkierLib.GetDays(varX, varY, varZ);

            // Add new skier to skierTable

            Array.Resize(ref skierTable, skierTable.Length + 1);
            skierTable[skierTable.Length - 1] = new int[4] { varX, varY, varZ, days };

            // Show result

            Console.WriteLine("On day {0}, the total mileage for all days will exceed {1} km.\n", days, varZ);

            // More?

            Console.Write("Do you want more? (\"y\" or \"n\"): ");
            string more = Console.ReadLine();

            while (!more.Equals("y") && !more.Equals("n"))
            {
                Console.Write("Only \"y\" or \"n\": ");
                more = Console.ReadLine();
            }

            if (more.Equals("y"))
            {
                Skier(skierTable);
            }
        }

        public static int GetVariable(string text)
        {
            Console.Write(text);
            string variable = Console.ReadLine();
            int parsedVar;

            // Number check

            if (!int.TryParse(variable, out parsedVar))
            {
                Console.WriteLine("Only numbers are available for input!");
                return GetVariable(text);
            }

            // Checking a number for 0 and for a sign

            if (parsedVar <= 0)
            {
                Console.WriteLine("The value cannot be less than 0 or equal to 0!");
                return GetVariable(text);
            }

            return parsedVar;
        }
    }
}
