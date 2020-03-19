using System;
using SquareMatrixLibrary;

namespace SquareMatrix
{
    class Program
    {
        public const int idShift = 2;
        public const int sizeShift = 7;
        public const int matrixShift = 3;
        public const int MinMatrixSize = 2;

        static void Main(string[] args)
        {
            int[][,] matrixTable = new int[100][,];

            // Generate few matrices for test

            for (int i = 2; i < 7; i++)
            {
                matrixTable[i - 2] = MatrixLib.GenerateNewMatrix(i);
            }

            SquareMatrix(matrixTable);
        }

        public static void SquareMatrix(int[][,] matrixTable)
        {
            Console.Clear();

            // navigation

            Console.WriteLine("Square Matrix Navigation: \n");
            Console.WriteLine("1) View matrix.");
            Console.WriteLine("2) Generate new matrix.");
            Console.WriteLine("3) Matrix Transpose.");
            Console.WriteLine("4) Output the upper/lower triangular matrix.");
            Console.WriteLine("5) Exit.");

            char key = Console.ReadKey(true).KeyChar;

            switch (key)
            {
                case '1':
                    // View matrix table

                    Console.Clear();
                    ViewMatrix(matrixTable);
                    Console.WriteLine("Press any key.");
                    Console.ReadKey();
                    SquareMatrix(matrixTable);
                    break;
                case '2':
                    // Generate new matrix

                    Console.Clear();
                    AddNewMatrix(matrixTable);
                    Console.WriteLine("Press any key.");
                    Console.ReadKey();
                    SquareMatrix(matrixTable);
                    break;
                case '3':
                    // Matrix Transpose

                    Console.Clear();
                    ShowTransposeMatrix(matrixTable);
                    Console.WriteLine("Press any key.");
                    Console.ReadKey();
                    SquareMatrix(matrixTable);
                    break;
                case '4':
                    // Output the upper/lower triangular matrix

                    Console.Clear();
                    OutputTriangularMatrix(matrixTable);
                    Console.WriteLine("Press any key.");
                    Console.ReadKey();
                    SquareMatrix(matrixTable);
                    break;
                case '5':
                    // Exit

                    break;
                default:
                    SquareMatrix(matrixTable);
                    break;
            }
        }

        public static int GetNumericVariable(string text, bool checkMinSize = false, bool negativeCheck = false, int? maxNumber = null)
        {
            Console.Write(text);
            string variable = Console.ReadLine();
            int parsedVar;

            // validation

            if (!int.TryParse(variable, out parsedVar))
            {
                Console.WriteLine("Only numbers are available for input!");
                return GetNumericVariable(text, checkMinSize, negativeCheck, maxNumber);
            }

            if (checkMinSize && parsedVar < MinMatrixSize)
            {
                Console.WriteLine("The minimum size of a square matrix is {0}x{0}!", MinMatrixSize);
                return GetNumericVariable(text, checkMinSize, negativeCheck, maxNumber);
            }

            if (negativeCheck && parsedVar <= 0)
            {
                Console.WriteLine("The entered number cannot be less than zero and cannot be zero!");
                return GetNumericVariable(text, checkMinSize, negativeCheck, maxNumber);
            }

            if (maxNumber != null && parsedVar > maxNumber)
            {
                Console.WriteLine("The maximum allowed number for input is {0}!", maxNumber);
                return GetNumericVariable(text, checkMinSize, negativeCheck, maxNumber);
            }

            return parsedVar;
        }

        public static void ViewMatrix(int[][,] matrixTable)
        {
            ShowMatrixTable(matrixTable);
            int matrixId = GetNumericVariable("Enter the ID of the matrix you want to show: ", false, true, MatrixLib.GetMatrixEmptyField(matrixTable)) - 1;
            ShowMatrix(matrixTable[matrixId]);
        }

        public static void AddNewMatrix(int[][,] matrixTable)
        {
            ShowMatrixTable(matrixTable);
            int matrixDimension = GetNumericVariable("Enter the dimension of the square matrix: ", true, true);

            int matrixEmptyFieldId = MatrixLib.GetMatrixEmptyField(matrixTable);

            matrixTable[matrixEmptyFieldId] = MatrixLib.GenerateNewMatrix(matrixDimension);
            
            Console.Write("\n");
            ShowMatrix(matrixTable[matrixEmptyFieldId]);
            Console.WriteLine("\nA new matrix has been generated.\n");
        }

        public static void ShowTransposeMatrix(int[][,] matrixTable)
        {
            ShowMatrixTable(matrixTable);
            int matrixID = GetNumericVariable("Select the matrix ID you want to transpose: ", false, true, MatrixLib.GetMatrixEmptyField(matrixTable)) - 1;

            ShowMatrix(matrixTable[matrixID]);

            Console.WriteLine("Transposed matrix:");
            ShowMatrix(MatrixLib.GetTransposeMatrix(matrixTable[matrixID]));
        }

        public static void OutputTriangularMatrix(int[][,] matrixTable)
        {
            ShowMatrixTable(matrixTable);
            int matrixID = GetNumericVariable("Select the matrix ID you want to output: ", false, true, MatrixLib.GetMatrixEmptyField(matrixTable)) - 1;

            Console.WriteLine("Original matrix:");
            ShowMatrix(matrixTable[matrixID]);

            Console.WriteLine("Upper triangular matrix:");
            ShowMatrix(MatrixLib.GetUpperTriangularMatrix(matrixTable[matrixID]));

            Console.WriteLine("Lower triangular matrix:");
            ShowMatrix(MatrixLib.GetLowerTriangularMatrix(matrixTable[matrixID]));
        }

        public static void ShowMatrix(int[,] matrix)
        {
            // Show matrix with formatting

            double sideSize = Math.Sqrt(matrix.Length);
            Console.Write("\n");

            for (int i = 0; i < sideSize; i++)
            {
                for (int j = 0; j < sideSize; j++)
                {
                    Console.Write("|{0}", new String('-', matrixShift + 2));
                }
                Console.WriteLine("|");

                for (int j = 0; j < sideSize; j++)
                {
                    Console.Write($"| {matrix[i,j], -matrixShift} ");
                }
                Console.WriteLine("|");
            }

            for (int j = 0; j < sideSize; j++)
            {
                Console.Write("|{0}", new String('-', matrixShift + 2));
            }
            Console.WriteLine("|\n");
        }

        public static void ShowMatrixTable(int[][,] matrixTable)
        {
            // Show matrix table with formatting

            if (matrixTable.Length == 0)
            {
                Console.WriteLine("There are no matrices in the table.\n");
            }
            else
            {
                string matrixLength;
                Console.WriteLine("|{0}|{1}|",
                    new String('-', idShift + 2),
                    new String('-', sizeShift + 2));
                Console.WriteLine($"| {"ID",-idShift} | {"Size",-sizeShift} |");
                Console.WriteLine("|{0}|{1}|",
                    new String('-', idShift + 2),
                    new String('-', sizeShift + 2));
                for (int i = 0; i < matrixTable.Length; i++)
                {
                    if (matrixTable[i] != null)
                    {
                        matrixLength = Math.Sqrt(matrixTable[i].Length).ToString() + "x" + Math.Sqrt(matrixTable[i].Length).ToString();
                        Console.WriteLine($"| {i + 1,-idShift} | {matrixLength, -sizeShift} |");
                    }
                }
                Console.WriteLine("|{0}|{1}|\n",
                    new String('-', idShift + 2),
                    new String('-', sizeShift + 2));
            }
        }
    }
}
