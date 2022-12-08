using System;
using System.Linq;
					
public class Program
{	
	public static void Main()
	{
		var s = @"
30373
25512
65332
33549
35390";
		var s0 = @"
111
121
111";
		var s1 = @"
111
111
121
111";
		var s12 = @"
111
111
112
111";
		var s13 = @"
111
111
111
112";
		var s2 = @"
111
121
121
111";
		var s3 = @"
1111
1211
1231
1141";
		var s4 = @"
1111
1221
1231
1141";
		var s41 = @"
1111
1221
1232
1141";
		var s42 = @"
1111
1221
1222
1141";
		var s5 = @"
1111
1211
2211
1211";
		
		var sBug1 = @"
3373
6332
1111
";
		
		Console.WriteLine("{0} actual {1} expected {2}", CountVisible(s0) == 9  , CountVisible(s0), 9);
		Console.WriteLine("{0} actual {1} expected {2}", CountVisible(s1) == 11 , CountVisible(s1), 11);
		Console.WriteLine("{0} actual {1} expected {2}", CountVisible(s12) == 10, CountVisible(s12), 10);
		Console.WriteLine("{0} actual {1} expected {2}", CountVisible(s13) == 10, CountVisible(s13), 10);
		Console.WriteLine("{0} actual {1} expected {2}", CountVisible(s2) == 12 , CountVisible(s2), 12);
		Console.WriteLine("{0} actual {1} expected {2}", CountVisible(s3) == 15 , CountVisible(s3), 15);
		Console.WriteLine("{0} actual {1} expected {2}", CountVisible(s4) == 16 , CountVisible(s4), 16);
		Console.WriteLine("{0} actual {1} expected {2}", CountVisible(s41) == 16, CountVisible(s41), 16);
		Console.WriteLine("{0} actual {1} expected {2}", CountVisible(s42) == 15, CountVisible(s42), 15);
		Console.WriteLine("{0} actual {1} expected {2}", CountVisible(s5) == 14, CountVisible(s5), 14);
		Console.WriteLine("{0} actual {1} expected {2}", CountVisible(sBug1) == 12, CountVisible(sBug1), 12);
		Console.WriteLine("{0} actual {1} expected {2}", CountVisible(s) == 21  , CountVisible(s), 21);
	}
	
	private static int[][] ParseMatrix(string source) =>
		source
			.Trim()
			.Split("\n")
			.Select(xr => xr.Select(s => s - '0').ToArray())
			.ToArray();
	
	private static bool IsVisibleFromTheLeft(int[][] matrix, int col, int row) =>
		Enumerable.Range(0, col).All(x => matrix[row][x] < matrix[row][col]);
	
	private static bool IsVisibleFromTheTop(int[][] matrix, int col, int row) =>
		Enumerable.Range(0, row).All(x => matrix[x][col] < matrix[row][col]);
	
	private static bool IsVisibleFromTheRight(int[][] matrix, int col, int row, int matrixWidth) =>
		Enumerable.Range(col + 1, matrixWidth - col - 1).All(x => matrix[row][x] < matrix[row][col]);
	
	private static bool IsVisibleFromTheBottom(int[][] matrix, int col, int row, int matrixHeight) =>
		Enumerable.Range(row + 1, matrixHeight - row - 1).All(x => matrix[x][col] < matrix[row][col]);
		
	private static int CountVisible(string source)
	{
		var matrix = ParseMatrix(source);
		var matrixWidth = matrix[0].Length;
		var matrixHeight = matrix.Length;
		var visibleQuantity = (matrix.Length + matrixWidth - 2) * 2;
		for (var row = 1; row < matrixHeight - 1; row++)
		{
			for (var col = 1; col < matrixWidth - 1; col++)
			{
					var isVisible =
						   IsVisibleFromTheLeft(matrix, col, row)
						|| IsVisibleFromTheTop(matrix, col, row)
						|| IsVisibleFromTheRight(matrix, col, row, matrixWidth)
						|| IsVisibleFromTheBottom(matrix, col, row, matrixHeight);
					if (isVisible)
					{
						visibleQuantity++;
					}
			}
		}
		return visibleQuantity;

	}
}
