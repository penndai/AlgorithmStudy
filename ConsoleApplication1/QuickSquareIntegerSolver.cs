using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
   
    public class QuickSquareIntegerSolver
    {       
        public int NumberOfSquares(int left, int right)
        {
            int squareLeft = (int)Math.Ceiling(Math.Sqrt(left));
            int squareRight = (int)Math.Floor(Math.Sqrt(right));
            return squareRight - squareLeft + 1;
        }
    }
}
