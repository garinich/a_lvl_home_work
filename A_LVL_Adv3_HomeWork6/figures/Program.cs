using System;
using System.Collections.Generic;

namespace shapes
{
    class Program
    {
        public enum Navigation
        {
            ShowShape = '1',
            AddShape = '2',
            Exit = '3'
        };

        public const int idShift = 2;
        public const int nameShift = 15;
        public const int MinShapeCorners = 3;
        public const int MinSideLength = 1;

        public interface IShape
        {
            static int sideLength;
            static int anglesCount;
            static readonly string name;

            void ShowInfo();
        }

        public struct Shape : IShape
        {
            public readonly string name;
            public int sideLength;
            public int anglesCount;

            public Shape(string name, int sideLength, int anglesCount)
            {
                this.name = name;
                this.sideLength = sideLength;
                this.anglesCount = anglesCount;
            }

            public void ShowInfo()
            {
                Console.WriteLine($"Name: {name}; Side Length: {sideLength}; Angles Count: {anglesCount}");
            }
        }

        static void Main(string[] args)
        {
            List<Shape> shapesTable = new List<Shape>();
            Shapes(shapesTable);
        }

        public static void Shapes(List<Shape> shapesTable)
        {
            Console.Clear();
            bool exit = false;

            // navigation

            Console.WriteLine("Shapes Navigation: \n");
            Console.WriteLine("1) Show shape.");
            Console.WriteLine("2) Add shape.");
            Console.WriteLine("3) Exit.");

            char key = Console.ReadKey(true).KeyChar;

            Console.Clear();
            switch (key)
            {
                case (char)Navigation.ShowShape:
                    // Show shapes table

                    ShowShape(shapesTable);
                    break;

                case (char)Navigation.AddShape:
                    // Add new shape

                    AddNewShape(shapesTable);
                    break;

                case (char)Navigation.Exit:
                    // Exit

                    exit = true;
                    break;

                default:
                    Shapes(shapesTable);
                    break;
            }

            if (!exit)
            {
                Console.WriteLine("Press any key.");
                Console.ReadKey();
                Shapes(shapesTable);
            }
        }

        public static int GetNumericVariable(string text, int? minValue = null, int? maxNumber = null)
        {
            Console.Write(text);
            string variable = Console.ReadLine();
            int parsedVar;

            // validation

            if (!int.TryParse(variable, out parsedVar))
            {
                Console.WriteLine("Only numbers are available for input!");
                return GetNumericVariable(text, minValue, maxNumber);
            }

            if (minValue != null && parsedVar < minValue)
            {
                Console.WriteLine("The minimum value is {0}!", minValue);
                return GetNumericVariable(text, minValue, maxNumber);
            }

            if (maxNumber != null && parsedVar > maxNumber)
            {
                Console.WriteLine("The maximum allowed number for input is {0}!", maxNumber);
                return GetNumericVariable(text, minValue, maxNumber);
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

        public static void AddNewShape(List<Shape> shapesTable)
        {
            ShowShapesTable(shapesTable);
            string shapeName = GetStringVariable("Enter the name of the shape: ");
            int shapeCorners = GetNumericVariable(string.Format("Enter the corners of the shape (min = {0}): ", MinShapeCorners), MinShapeCorners);
            int sideLength = GetNumericVariable(string.Format("Enter the side length of the shape (min = {0}): ", MinSideLength), MinSideLength);

            shapesTable.Add(new Shape(shapeName, sideLength, shapeCorners));

            Console.Write("\n");
            ShowShapesTable(shapesTable);
            Console.WriteLine("\nA new shape add successful.\n");
        }

        public static void ShowShape(List<Shape> shapesTable)
        {
            ShowShapesTable(shapesTable);
            if (shapesTable.Count > 0)
            {
                int shapeId = GetNumericVariable("Enter the ID of the shape you want to show: ", 1, shapesTable.Count) - 1;
                Console.Write("\n");
                shapesTable[shapeId].ShowInfo();
                Console.Write("\n");
            }
        }

        public static void ShowShapesTable(List<Shape> shapesTable)
        {
            // Show shapes table with formatting

            if (shapesTable.Count == 0)
            {
                Console.WriteLine("There are no shapes in the table.\n");
            }
            else
            {
                Console.WriteLine("|{0}|{1}|",
                    new String('-', idShift + 2),
                    new String('-', nameShift + 2));
                Console.WriteLine($"| {"ID",-idShift} | {"Name",-nameShift} |");
                Console.WriteLine("|{0}|{1}|",
                    new String('-', idShift + 2),
                    new String('-', nameShift + 2));
                for (int i = 0; i < shapesTable.Count; i++)
                {
                    Console.WriteLine($"| {i + 1,-idShift} | {shapesTable[i].name,-nameShift} |");
                }
                Console.WriteLine("|{0}|{1}|\n",
                    new String('-', idShift + 2),
                    new String('-', nameShift + 2));
            }
        }
    }
}
