using System;

namespace A_LVL_Adv3_HomeWork1_DLL
{
    public class CustomMath
    {
        public static double GetVariable(char variableName)
        {
            Console.Write("Enter variable \"{0}\": ", variableName);
            string variable = Console.ReadLine();
            double parsedVar;

            while (!Double.TryParse(variable, out parsedVar))
            {
                Console.WriteLine("Only numbers are available for input!");
                Console.Write("Enter variable \"{0}\": ", variableName);
                variable = Console.ReadLine();
            }

            return parsedVar;
        }

        public static double GetDiscriminant(double varA, double varB, double varC)
        {
            return Math.Pow(varB, 2) - 4 * varA * varC;
        }

        public static double[] GetRoots(double discriminant, double varA, double varB)
        {
            double x1 = (-varB + Math.Sqrt(discriminant)) / (2 * varA);
            double x2 = (-varB - Math.Sqrt(discriminant)) / (2 * varA);

            return new double[2] { x1, x2 };
        }

        public static char GetSign(double variable, bool reverse = false)
        {
            if(!reverse)
            {
                return variable >= 0 ? '+' : '-';
            }
            else
            {
                return variable >= 0 ? '-' : '+';
            }
        }
    }
}
