using System;
using A_LVL_Adv3_HomeWork1_DLL;

namespace A_LVL_Adv3_HomeWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (QuadraticEquation()) { }
        }

        public static bool QuadraticEquation()
        {
            Console.Clear();
            Console.WriteLine("ax² + bx + c = 0\n");

            // Get variables a, b, c

            double varA = CustomMath.GetVariable('a');
            double varB = CustomMath.GetVariable('b');
            double varC = CustomMath.GetVariable('c');

            // Calculate discriminant and roots

            double discriminant = CustomMath.GetDiscriminant(varA, varB, varC);
            double[] roots = CustomMath.GetRoots(discriminant, varA, varB);

            // Show results

            if (discriminant < 0)
            {
                Console.WriteLine("D < 0 - The equation has no roots!");
            }
            else
            {
                Console.WriteLine("Discriminant D = {0}\n", discriminant);
                if (discriminant == 0)
                {
                    Console.WriteLine("The equation has one root: x1 = x2 = {0}\n", roots[0]);
                }
                else
                {
                    Console.WriteLine($"The equation has two roots: x1 = {roots[0]}, x2 = {roots[1]}\n");
                }

                // Checking signs

                char signB = CustomMath.GetSign(varB);
                char signC = CustomMath.GetSign(varC);
                char signX1 = CustomMath.GetSign(roots[0], true);
                char signX2 = CustomMath.GetSign(roots[1], true);

                Console.WriteLine("Linear Factorization:");
                Console.WriteLine($"{varA}x² {signB} {Math.Abs(varB)}x {signC} {Math.Abs(varC)} = {varA}(x {signX1} {Math.Abs(roots[0])})(x {signX2} {Math.Abs(roots[1])})\n");
            }

            // Check more

            Console.Write("Do you want more? (\"yes\" or \"no\"): ");
            string more = Console.ReadLine();
            while (!more.Equals("yes") && !more.Equals("no"))
            {
                Console.Write("Only \"yes\" or \"no\": ");
                more = Console.ReadLine();
            }

            return more.Equals("yes");
        }
    }
}
