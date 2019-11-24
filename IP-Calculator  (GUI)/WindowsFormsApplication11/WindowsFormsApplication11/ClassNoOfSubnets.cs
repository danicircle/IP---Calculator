using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication11
{
    class ClassNoOfSubnets
    {
        public int getSubnets(int num)
        {
            int NoOfSubnets;
            if (num == 128)
            {
                NoOfSubnets = 2;
            }
            else if (num == 192)
            {
                NoOfSubnets = 4;
            }
            else if (num == 224)
            {
                NoOfSubnets = 8;
            }
            else if (num == 240)
            {
                NoOfSubnets = 16;
            }
            else if (num == 248)
            {
                NoOfSubnets = 32;
            }
            else if (num == 252)
            {
                NoOfSubnets = 64;
            }
            else if (num == 254)
            {
                NoOfSubnets = 128;
            }
            else if (num == 255)
            {
                NoOfSubnets = 256;
            }
            else
            {
                NoOfSubnets = 1;
            }
            return NoOfSubnets;
        }
    }
}
