using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
	private static void Assert<T>(T actual, T expected, string message)
	{
		if (!actual.Equals(expected))
		{
			Console.WriteLine("actual {0:N0} expected {1:N0} on {2}", actual, expected, message);
		}
		else
		{
			Console.WriteLine("both {0:N0} on {1}", actual, message);
		}
	}

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
		/*Console.WriteLine("{0} actual {1} expected {2}", CountVisible(s0) == 9  , CountVisible(s0), 9);
		Console.WriteLine("{0} actual {1} expected {2}", CountVisible(s1) == 11 , CountVisible(s1), 11);
		Console.WriteLine("{0} actual {1} expected {2}", CountVisible(s12) == 10, CountVisible(s12), 10);
		Console.WriteLine("{0} actual {1} expected {2}", CountVisible(s13) == 10, CountVisible(s13), 10);
		Console.WriteLine("{0} actual {1} expected {2}", CountVisible(s2) == 12 , CountVisible(s2), 12);
		Console.WriteLine("{0} actual {1} expected {2}", CountVisible(s3) == 15 , CountVisible(s3), 15);
		Console.WriteLine("{0} actual {1} expected {2}", CountVisible(s4) == 16 , CountVisible(s4), 16);
		Console.WriteLine("{0} actual {1} expected {2}", CountVisible(s41) == 16, CountVisible(s41), 16);
		Console.WriteLine("{0} actual {1} expected {2}", CountVisible(s42) == 15, CountVisible(s42), 15);
		Console.WriteLine("{0} actual {1} expected {2}", CountVisible(s5) == 14, CountVisible(s5), 14);
		Console.WriteLine("{0} actual {1} expected {2}", CountVisible(sBug1) == 12, CountVisible(sBug1), 12);*/
		Assert<int>(CountVisible(s), 8, "test");
		var matrix = ParseMatrix(s);
		var matrixWidth = matrix[0].Length;
		var matrixHeight = matrix.Length;
		{
			var row = 1;
			var col = 2;
			Assert<int>(LookUp(matrix, col, row), 1, "up");
			Assert<int>(LookLeft(matrix, col, row), 1, "left");
			Assert<int>(LookRight(matrix, col, row, matrixWidth), 2, "right");
			Assert<int>(LookDown(matrix, col, row, matrixHeight), 2, "down");
		}

		{
			var row = 3;
			var col = 2;
			Assert<int>(LookLeft(matrix, col, row), 2, "left");
			Assert<int>(LookDown(matrix, col, row, matrixHeight), 1, "down");
			Assert<int>(LookUp(matrix, col, row), 2, "up");
			Assert<int>(LookRight(matrix, col, row, matrixWidth), 2, "right");
		}
	}

	private static int[][] ParseMatrix(string source) => source.Trim().Split("\n").Select(xr => xr.Select(s => s - '0').ToArray()).ToArray();
	
	private static int LookLeft(int[][] matrix, int col, int row) =>
		Enumerable.Range(0, col)
			.Reverse()
			.TakeWhileInclusive(x => matrix[row][x] < matrix[row][col])
			.Count();

	private static int LookUp(int[][] matrix, int col, int row) =>
		Enumerable
			.Range(0, row)
			.Reverse()
			.TakeWhileInclusive(x => matrix[x][col] < matrix[row][col])
			.Count();

	private static int LookRight(int[][] matrix, int col, int row, int matrixWidth) =>
		Enumerable
			.Range(col + 1, matrixWidth - col - 1)
			.TakeWhileInclusive(x => matrix[row][x] < matrix[row][col])
			.Count();

	private static int LookDown(int[][] matrix, int col, int row, int matrixHeight) =>
		Enumerable
			.Range(row + 1, matrixHeight - row - 1)
			.TakeWhileInclusive(x => matrix[x][col] < matrix[row][col])
			.Count();
	
	private static int CountVisible(string source)
	{
		var matrix = ParseMatrix(source);
		var matrixWidth = matrix[0].Length;
		var matrixHeight = matrix.Length;
		return Enumerable
			.Range(0, matrix[0].Length)
			.SelectMany(_ => Enumerable.Range(0, matrix.Length), (row, col) => (row, col))
			.Max(x => LookLeft(matrix, x.col, x.row)
						* LookUp(matrix, x.col, x.row)
						* LookRight(matrix, x.col, x.row, matrixWidth)
						* LookDown(matrix, x.col, x.row, matrixHeight));
	}
}

public static class Extensions
{
	public static IEnumerable<T> TakeWhileInclusive<T>(this IEnumerable<T> source, Func<T, bool> predicate)
	{
		foreach (T t in source)
		{
			yield return t;
			if (!predicate(t))
				yield break;
		}
	}
}
