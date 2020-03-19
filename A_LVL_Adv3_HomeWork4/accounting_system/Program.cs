using System;
using LaptopLibrary;

namespace accounting_system
{
    class Program
    {
        public const int idShift = 2;
        public const int nameShift = 20;
        public const int diagonalShift = 8;
        public const int cpuShift = 5;
        public const int ramShift = 5;

        static void Main(string[] args)
        {
            LaptopTable laptopTable = new LaptopTable();

            // Add 5 laptops for testeng

            var random = new Random();

            for (int i = 0; i < 5; i++)
            {
                laptopTable.Add(new Laptop(string.Format("qwe {0}", i + 1), random.Next(11, 17), random.Next(2, 8), random.Next(4, 128)));
            }

            AccountingSystem(laptopTable);
        }

        public static void AccountingSystem(LaptopTable laptopTable)
        {
            Console.Clear();

            // navigation

            Console.WriteLine("Laptop accounting system: \n");
            Console.WriteLine("1) View all laptops.");
            Console.WriteLine("2) Add a laptop.");
            Console.WriteLine("3) Remove the laptop.");
            Console.WriteLine("4) Exit.");

            char key = Console.ReadKey(true).KeyChar;

            switch (key)
            {
                case '1':
                    // View all laptops

                    Console.Clear();
                    ShowLaptopsTable(laptopTable);
                    Console.WriteLine("Press any key.");
                    Console.ReadKey();
                    AccountingSystem(laptopTable);
                    break;
                case '2':
                    // Add a laptop

                    Console.Clear();
                    AddNewLaptop(laptopTable);
                    Console.WriteLine("Press any key.");
                    Console.ReadKey();
                    AccountingSystem(laptopTable);
                    break;
                case '3':
                    // Remove the laptop

                    Console.Clear();
                    RemoveLaptopFromTable(laptopTable);
                    Console.WriteLine("Press any key.");
                    Console.ReadKey();
                    AccountingSystem(laptopTable);
                    break;
                case '4':
                    // Exit

                    break;
                default:
                    AccountingSystem(laptopTable);
                    break;
            }
        }

        public static int GetNumericVariable(string text, bool negativeCheck = false, int? maxNumber = null)
        {
            Console.Write(text);
            string variable = Console.ReadLine();
            int parsedVar;

            if (!int.TryParse(variable, out parsedVar))
            {
                Console.WriteLine("Only numbers are available for input!");
                return GetNumericVariable(text, negativeCheck, maxNumber);
            }

            if (negativeCheck && parsedVar <= 0)
            {
                Console.WriteLine("The entered number cannot be less than zero and cannot be zero!");
                return GetNumericVariable(text, negativeCheck, maxNumber);
            }

            if (maxNumber != null && parsedVar > maxNumber)
            {
                Console.WriteLine("The maximum allowed number for input is {0}!", maxNumber);
                return GetNumericVariable(text, negativeCheck, maxNumber);
            }

            return parsedVar;
        }

        public static string GetStringVariable(string text)
        {
            Console.Write(text);
            string variable = Console.ReadLine();

            if (variable.Length == 0)
            {
                Console.WriteLine("The field cannot be empty!");
                return GetStringVariable(text);
            }

            return variable;
        }

        public static void AddNewLaptop(LaptopTable laptopTable)
        {
            // Get all data

            string laptopName = GetStringVariable("Enter the name of the manufacturer company: ");
            int laptopDiagonal = GetNumericVariable("Enter the diagonal (numbers only): ", true);
            int laptopAmountOfCPU = GetNumericVariable("Enter the amount of CPU (numbers only): ", true);
            int laptopAmountOfRAM = GetNumericVariable("Enter the amount of RAM (numbers only): ", true);

            // Add new laptop

            laptopTable.Add(new Laptop(laptopName, laptopDiagonal, laptopAmountOfCPU, laptopAmountOfRAM));

            ShowLaptopsTable(laptopTable);
            Console.WriteLine("A new laptop has been added.\n");
        }

        public static void ShowLaptopsTable(LaptopTable laptopTable)
        {
            if (laptopTable.GetLength == 0)
            {
                Console.WriteLine("There are no laptops in the table.\n");
            }
            else
            {
                Console.WriteLine("|{0}|{1}|{2}|{3}|{4}|",
                    new String('-', idShift + 2),
                    new String('-', nameShift + 2),
                    new String('-', diagonalShift + 2),
                    new String('-', cpuShift + 2),
                    new String('-', ramShift + 2));
                Console.WriteLine($"| {"ID", -idShift} | {"Name", -nameShift} | {"Diagonal", -diagonalShift} | {"CPU", -cpuShift} | {"RAM", -ramShift} |");
                Console.WriteLine("|{0}|{1}|{2}|{3}|{4}|",
                    new String('-', idShift + 2),
                    new String('-', nameShift + 2),
                    new String('-', diagonalShift + 2),
                    new String('-', cpuShift + 2),
                    new String('-', ramShift + 2));
                foreach (Laptop laptop in laptopTable)
                {
                    Console.WriteLine($"| {laptopTable.GetLaptopIndexByHash(laptop.GetHashCode()), -idShift} | {laptop.ManufacturerName, -nameShift} | {laptop.Diagonal, -diagonalShift} | {laptop.AmountOfCPU, -cpuShift} | {laptop.AmountOfRAM, -ramShift} |");
                }
                Console.WriteLine("|{0}|{1}|{2}|{3}|{4}|\n",
                    new String('-', idShift + 2),
                    new String('-', nameShift + 2),
                    new String('-', diagonalShift + 2),
                    new String('-', cpuShift + 2),
                    new String('-', ramShift + 2));
            }
        }

        public static void RemoveLaptopFromTable(LaptopTable laptopTable)
        {
            ShowLaptopsTable(laptopTable);
            if (laptopTable.GetLength != 0)
            {
                // Get laptop Id

                int laptopId = GetNumericVariable("Enter the ID of the laptop you want to delete: ", true, laptopTable.GetLength);

                // Remove laptop by Id

                laptopTable.RemoveById(laptopId - 1);

                ShowLaptopsTable(laptopTable);
                Console.WriteLine("Laptop with ID = {0} was deleted successfully.\n", laptopId);
            }
        }

    }
}
