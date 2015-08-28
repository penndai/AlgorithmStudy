using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	public class MatrixRotation
	{
		public int RowNumber { get; set; }
		public int ColumnNumber { get; set;}
		public int RotationNumer { get; set; }

		public void PrintMatrixRotation()
		{
			if (RowNumber > 0 && ColumnNumber > 0 && RotationNumer > 0)
			{
				// calculate the each rotation index
 				// for example
				// row =10, colunn =10
				// first round is (row=0, column=9)
				// second round is (row =1, column=8)
				// .... etc (row = 4, column =5)
				for (int rowIdx = 0, columnIdx = ColumnNumber; rowIdx < columnIdx; rowIdx++, columnIdx--)
				{
					// deal with each round, starting from (e.g. row =0 column =9)
					var startCoords = Tuple.Create<int, int>(rowIdx, rowIdx);
					bool currentRoundDone = false;
					for (; ; )
					{
						if(currentRoundDone && )
						break;
					}
				}
			}
		}
	}
}
