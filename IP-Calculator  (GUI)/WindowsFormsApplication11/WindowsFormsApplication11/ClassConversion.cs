using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication11
{
    class ClassConversion
    {
        int sum = 0;
        public int DecimalToBinary(int num, int i)
        {

            int binary = 0;


            int num2 = 1;
            for (int j = 0; j < i; j++)
            {
                num2 = num2 * 2;

            }

            sum = sum + num2;
            if (sum <= num)
            {

                binary = 1;
            }
            else
            {
                binary = 0;
                sum = sum - num2;
            }


            return binary;
        }
    }
}
