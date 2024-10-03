using System;

namespace libmas_task
{
    public static class ProizvedCalc
    {
        public static int CalculateProizved3(int[] nums)
        {
            int proizvedenie = 1;
            foreach (int num in nums)
            {
                if (num < 3)
                {
                    proizvedenie *= num;
                }
            }
            return proizvedenie;
        }
    }
}