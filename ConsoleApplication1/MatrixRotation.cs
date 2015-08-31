using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	public class MatrixRotation
	{
		public Int32 RowNumber { get; set; }
		public Int32 ColumnNumber { get; set; }
		public Int32 RotationNumer { get; set; }

		public Int32[,] Matrix;
		public Int32[,] Matrix_Rotation;
		/// <summary>
		/// cross line position, [0,0],[1,1]...[n,n]
		/// </summary>
		public List<Tuple<Int32, Int32>> DiagonalNumber { get; set; }

		public void PrintMatrix(Int32[,] matrix)
		{
			Int32 lengthX = matrix.GetLength(1);
			Int32 lengthY = matrix.GetLength(0);
			for (Int32 y = 0; y < lengthY; y++)
			{
				for (Int32 x = 0; x < lengthX; x++)
				{
					if (x == lengthX - 1)
						Console.Write(matrix[y, x]);
					else
					{
						Console.Write(matrix[y, x] + " ");
					}

				}
				Console.WriteLine();
			}
		}

		public Int32[,] RotateRight(Int32[,] matrix)
		{
			Int32 lengthY = matrix.GetLength(0);
			Int32 lengthX = matrix.GetLength(1);
			Int32[,] result = new Int32[lengthX, lengthY];
			for (Int32 y = 0; y < lengthY; y++)
				for (Int32 x = 0; x < lengthX; x++)
					result[x, y] = matrix[lengthY - 1 - y, x];
			return result;
		}

		public void Test()
		{
			TestRotation(new Int32[4, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } });
			Console.WriteLine();
			TestRotation(new Int32[2, 3] { { 0, 1, 2 }, { 3, 4, 5 } });
		}

		public void TestRotation(Int32[,] matrix)
		{
			Console.WriteLine("the original matrix:");
			PrintMatrix(matrix);
			Console.WriteLine();
			Console.WriteLine("the right rotated matrix:");
			PrintMatrix(RotateRight(matrix));
			Console.WriteLine();
			//Console.WriteLine("the left rotated matrix:");
			//PrInt32Matrix(RotateLeft(matrix));
		}

		public void CreateEmptyMatrix()
		{
			Matrix = new Int32[RowNumber, ColumnNumber];
			Matrix_Rotation = new Int32[RowNumber, ColumnNumber];
		}
		public void CreateMatrix(Int32 rowIdx, string s)
		{
			string[] rowStringList = s.Split(' ');
			for (Int32 i = 0; i < ColumnNumber; i++)
			{
				Matrix[rowIdx, i] = Convert.ToInt32(rowStringList[i]);
				Matrix_Rotation[rowIdx, i] = Convert.ToInt32(rowStringList[i]);
			}
		}

		public void PrintMatrixRotation()
		{
			if (Matrix.Length > 0 && RowNumber > 0 && ColumnNumber > 0)
			{
				DiagonalNumber = new List<Tuple<Int32, Int32>>();
				// calculate the each rotation index
				// for example
				// row =10, colunn =10
				// first round is (row=0, column=9)
				// second round is (row =1, column=8)
				// .... etc (row = 4, column =5)
				for (Int32 rowIdx = 0, colIdx = 0; rowIdx < RowNumber && colIdx < ColumnNumber; rowIdx++, colIdx++)
				{
					if (DiagonalNumber.Count(x => x.Item1 == rowIdx && x.Item2 == colIdx) == 0)
					{
						DiagonalNumber.Add(new Tuple<int,int>(rowIdx,colIdx));
						List<Tuple<Int32, Int32>> currentRotation = new List<Tuple<Int32, Int32>>();
						int ColNumberInCurrentRoation = ColumnNumber - 2*colIdx;
						int RowNumberInCurrentRotation = RowNumber - 2*rowIdx;
						//Move Right
						for (Int32 col = colIdx; col <= ColumnNumber - colIdx - 1; col++)
						{
							if (col == rowIdx && DiagonalNumber.Count(x => x.Item1 == rowIdx && x.Item2 == colIdx) == 0)
								DiagonalNumber.Add(new Tuple<Int32, Int32>(rowIdx, col));
							currentRotation.Add(new Tuple<Int32, Int32>(rowIdx, col));
						}

						//Move Down
						for (Int32 row = rowIdx + 1; row <= RowNumber - rowIdx - 1; row++)
						{
							if (!currentRotation.Any(x => x.Item1 == row &&
									x.Item2 == ColumnNumber - colIdx - 1))
							{
								currentRotation.Add(new Tuple<Int32, Int32>(row, ColumnNumber - colIdx - 1));
								if (ColumnNumber - colIdx - 1 == row &&
									DiagonalNumber.Count(x => x.Item1 == rowIdx && x.Item2 == ColumnNumber - colIdx - 1) == 0)
									DiagonalNumber.Add(new Tuple<Int32, Int32>(row, ColumnNumber - colIdx - 1));

							}
						}

						//Move Left
						for (Int32 col = ColumnNumber - colIdx - 1 - 1; col >= colIdx; col--)
						{
							if (!currentRotation.Any(x => x.Item1 == RowNumber - rowIdx - 1 &&
														  x.Item2 == col))
							{
								currentRotation.Add(new Tuple<Int32, Int32>(RowNumber - rowIdx - 1, col));
								if (RowNumber - rowIdx - 1 == col &&
									DiagonalNumber.Count(x => x.Item1 == RowNumber - rowIdx - 1 && x.Item2 == col) == 0)
									DiagonalNumber.Add(new Tuple<Int32, Int32>(RowNumber - rowIdx - 1, col));
							}
						}

						//Move Up
						for (Int32 row = RowNumber - rowIdx - 1 - 1; row >= rowIdx; row--)
						{
							if (!currentRotation.Any(x => x.Item1 == row &&
														  x.Item2 == colIdx))
							{
								if (row == colIdx &&
									DiagonalNumber.Count(x => x.Item1 == row && x.Item2 == colIdx)==0)
								{
									DiagonalNumber.Add(new Tuple<Int32, Int32>(row, colIdx));
								}
								currentRotation.Add(new Tuple<Int32, Int32>(row, colIdx));
							}
						}

						// shift matrix based on current rotation position list
						for (int shiftIdx = 0; shiftIdx < RotationNumer % ((ColNumberInCurrentRoation+RowNumberInCurrentRotation - 2) * 2); shiftIdx++)
								ShiftMatrix(currentRotation);
					}
					else
					{
						break;
					}
				}
			}


			//PrInt32Matrix(Matrix);
			//PrInt32Matrix(Matrix_Rotation);
		}

		//private void PrInt32Matrix(Int32[,] Matrix_Rotation)
		//{
		//    if (Matrix_Rotation.Length > 0)
		//    {
		//        for (Int32 i = 0; i < Matrix_Rotation.Length; i++)
		//        {
		//            for (Int32 j = 0; j < Matrix_Rotation.Rank; j++)
		//            {
		//                Console.Write("{0} ", Matrix_Rotation[i, j]);
		//            }

		//            Console.WriteLine();
		//        }
		//    }
		//}

		private void ShiftMatrix(List<Tuple<Int32, Int32>> rotationList)
		{
			if (rotationList.Count > 0)
			{
				Int32 firstNumber = 0;
				for (Int32 i = 0; i <= rotationList.Count; i++)
				{
					if (i == 0)
					{
						Int32 item1 = rotationList[i].Item1;
						Int32 item2 = rotationList[i].Item2;

						Int32 v = Matrix_Rotation[item1, item2];

						firstNumber = Matrix_Rotation[rotationList[i].Item1, rotationList[i].Item2];
					}
					else if (i == rotationList.Count)
					{
						Int32 item1 = rotationList[i - 1].Item1;
						Int32 item2 = rotationList[i - 1].Item2;

						Int32 v = Matrix_Rotation[item1, item2];

						Matrix_Rotation[rotationList[i - 1].Item1, rotationList[i - 1].Item2] = firstNumber;
					}
					else
					{
						Int32 item1 = rotationList[i].Item1;
						Int32 item2 = rotationList[i].Item2;

						Int32 v_pre = Matrix_Rotation[rotationList[i - 1].Item1, rotationList[i - 1].Item2];
						Int32 v = Matrix_Rotation[rotationList[i].Item1, rotationList[i].Item2];

						Matrix_Rotation[rotationList[i - 1].Item1, rotationList[i - 1].Item2] =
							Matrix_Rotation[rotationList[i].Item1, rotationList[i].Item2];
					}
				}
			}
		}
	}
}
