using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication11
{
    class ClassBits
    {
        public int generateBits(int num)
        {
            int noOfBits;
            if (num == 128)
            {
                noOfBits = 1;
            }
            else if (num == 192)
            {
                noOfBits = 2;
            }
            else if (num == 224)
            {
                noOfBits = 3;
            }
            else if (num == 240)
            {
                noOfBits = 4;
            }
            else if (num == 248)
            {
                noOfBits = 5;
            }
            else if (num == 252)
            {
                noOfBits = 6;
            }
            else if (num == 254)
            {
                noOfBits = 7;
            }
            else if (num == 255)
            {
                noOfBits = 8;
            }
            else
            {
                noOfBits = 0;
            }
            return noOfBits;
        }
    }
}
