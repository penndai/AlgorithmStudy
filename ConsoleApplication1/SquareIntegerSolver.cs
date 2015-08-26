using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class SquareIntegerSolver
    {
        public int MaxSquareInt { get; set; }

        public bool HavMaxSquareInt(int number)
        {
            bool flag = false;

            if (number == 0)
                return false;

            int n = number/2 + 1;
            int n1 = (number/n + n)/2;

            while (n1 < n)
            {
                n = n1;
                n1 = (number/n + n)/2;
            }

            if (n >= 1)
            {
                MaxSquareInt = n;
                flag = true;
            }

            return flag;
        }
    }
}
