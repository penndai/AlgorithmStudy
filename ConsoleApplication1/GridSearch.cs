using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	public class GridSearch
	{
		public int TestCaseNumber { get; set; }
		public int LargerGridRows { get; set; }
		public int LargerGridColumns { get; set; }
		public int PatternGridRows { get; set; }
		public int PatternGridColumns { get; set; }

		public List<string> LargerGrid;
		public List<string> PatternGrid;

		public void BuildGrids()
		{

		}

		public void IsPatternInLargeGrid()
		{			
			int startIdx = -1;

			if (LargerGrid.Count > 0 && PatternGrid.Count > 0 && TestCaseNumber > 0)
			{
				for (int i = 0; i <= LargerGridRows - PatternGridRows; i++)
				{
					string patternString = PatternGrid[0].ToString();
					
					startIdx = LargerGrid[i].IndexOf(patternString);
					if (startIdx > 0)
					{
						for (int j = 1; j < PatternGrid.Count; j++)
						{
							if (LargerGrid[i+j].Substring(startIdx, patternString.Length) != PatternGrid[j])
							{
								startIdx = -1;
								break;
							}
						}
					}					
				}

				if (startIdx>0)
					Console.WriteLine("Yes".ToUpper());
				else
					Console.WriteLine("No".ToUpper());
			}
			else
			{
				Console.WriteLine("No".ToUpper());
			}
		}
	}
}
