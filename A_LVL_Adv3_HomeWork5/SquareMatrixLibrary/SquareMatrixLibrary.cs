using System;

namespace SquareMatrixLibrary
{
    public class MatrixLib
    {
        // get first matrixTable empty field

        public static int GetMatrixEmptyField(int[][,] matrixTable)
        {
            int MatrixEmptyFieldId = 0;
            for (int i = 0; i < matrixTable.Length; i++)
            {
                if (matrixTable[i] == null)
                {
                    MatrixEmptyFieldId = i;
                    break;
                }
            }
            return MatrixEmptyFieldId;
        }

        // Generate matrix with random values

        public static int[,] GenerateNewMatrix(int matrixDimension)
        {
            Random random = new Random();

            int[,] newMatrix = new int[matrixDimension, matrixDimension];
            for (int j = 0; j < matrixDimension; j++)
            {
                for (int k = 0; k < matrixDimension; k++)
                {
                    newMatrix[j, k] = random.Next(1, 100);
                }
            }

            return newMatrix;
        }

        // Generate transpose matrix

        public static int[,] GetTransposeMatrix(int[,] matrix)
        {
            int sideSize = (int)Math.Sqrt(matrix.Length);
            int[,] transposedMatrix = new int[sideSize, sideSize];

            for (int i = 0; i < sideSize; i++)
            {
                for (int j = 0; j < sideSize; j++)
                {
                    transposedMatrix[i, j] = matrix[j, i];
                }
            }

            return transposedMatrix;
        }

        // Get upper triangular matrix

        public static int[,] GetUpperTriangularMatrix(int[,] matrix)
        {
            int sideSize = (int)Math.Sqrt(matrix.Length);
            int[,] upperMatrix = new int[sideSize, sideSize];

            for (int i = 0; i < sideSize; i++)
            {
                for (int j = 0; j < sideSize; j++)
                {
                    if (j >= i)
                    {
                        upperMatrix[i, j] = matrix[i, j];
                    }
                    else
                    {
                        upperMatrix[i, j] = 0;
                    }
                }
            }

            return upperMatrix;
        }

        // Get lower triangular matrix

        public static int[,] GetLowerTriangularMatrix(int[,] matrix)
        {
            int sideSize = (int)Math.Sqrt(matrix.Length);
            int[,] lowerMatrix = new int[sideSize, sideSize];

            for (int i = 0; i < sideSize; i++)
            {
                for (int j = 0; j < sideSize; j++)
                {
                    if (j <= i)
                    {
                        lowerMatrix[i, j] = matrix[i, j];
                    }
                    else
                    {
                        lowerMatrix[i, j] = 0;
                    }
                }
            }

            return lowerMatrix;
        }
    }
}
