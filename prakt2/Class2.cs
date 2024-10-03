using System;

namespace libmas_task
{
    public static class ProductCalculator
    {
        public static int CalculateProductLessThan3(int[] numbers)
        {
            int product = 1;
            foreach (int number in numbers)
            {
                if (number < 3)
                {
                    product *= number;
                }
            }
            return product;
        }
    }
}