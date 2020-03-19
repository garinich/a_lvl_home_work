using System;

namespace A_LVL_Adv3_HomeWork3_DLL
{
    public class CustomMath
    {
        public static bool CheckPrime(int parsedVar)
        {
            bool flagPrime = true;

            for (double i = 2; i < parsedVar; i++)
            {
                if (parsedVar % i == 0)
                {
                    flagPrime = false;
                }
            }
            return flagPrime;
        }
        public static bool CheckFizzBuzz(int count, int[] primeFactorsArray)
        {
            bool flagFizzBuzz = false;

            for (int i = 0; i < primeFactorsArray.Length; i++)
            {
                if (count % primeFactorsArray[i] == 0)
                {
                    flagFizzBuzz = true;
                }
            }

            return flagFizzBuzz;
        }
    }
}
