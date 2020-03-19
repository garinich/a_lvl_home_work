using System;

namespace A_LVL_Adv3_HomeWork3_DLL
{
    public class SkierLib
    {
        public static string GetTable(int[][] skierTable)
        {
            string table = "";

            for (int i = 0; i < skierTable.Length; i++)
            {
                table += String.Format("Skier #{0} ", i + 1);
                for (int j = 0; j < skierTable[i].Length; j++)
                {
                    table += String.Format("\t{0}", skierTable[i][j]);
                }
                table += "\n";
            }

            return table;
        }

        public static int GetDays(int varX, int varY, int varZ)
        {
            double count = varX;
            int days = 1;

            while (count < varZ)
            {
                count += count * varY / 100;
                days += 2;
            }

            return days;
        }
    }
}
