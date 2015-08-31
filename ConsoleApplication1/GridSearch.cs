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

	    public List<bool> Result = new List<bool>(); 
		public void PrintResult()
		{
		    foreach (var VARIABLE in Result)
		    {
		        Console.WriteLine("{0}", VARIABLE?"YES":"NO");
		    }
		}

		public void IsPatternInLargeGrid()
		{
		    var find = false;

			if (LargerGrid.Count > 0 && PatternGrid.Count > 0 && TestCaseNumber > 0)
			{
				for (int i = 0; i <= LargerGridRows - PatternGridRows; i++)
				{
					string patternString = PatternGrid[0].ToString();
					
					var startIdx = LargerGrid[i].IndexOf(patternString, StringComparison.Ordinal);
				    if (startIdx < 0) continue;
				    find = true;

				    // if first pattern string find, continue finding other pattern line string
				    for (var j = 1; j < PatternGrid.Count; j++)
				    {
				        if (LargerGrid[i + j].Substring(startIdx, patternString.Length) == PatternGrid[j]) continue;
				        //set find to false as far as one pattern line string cannot find
				        find = false;
				        break;
				    }

				    if (find)
				        break;
				}

				Result.Add(find);
			}
			else
			{
                Result.Add(false);
			}
		}
	}
}
