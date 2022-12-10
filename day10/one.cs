using System;
using System.Collections.Generic;
using System.Linq;
					
public class Program
{	
	public static void Main()
	{
		var s = @"addx 15
addx -11
addx 6
addx -3
addx 5
addx -1
addx -8
addx 13
addx 4
noop
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx -35
addx 1
addx 24
addx -19
addx 1
addx 16
addx -11
noop
noop
addx 21
addx -15
noop
noop
addx -3
addx 9
addx 1
addx -3
addx 8
addx 1
addx 5
noop
noop
noop
noop
noop
addx -36
noop
addx 1
addx 7
noop
noop
noop
addx 2
addx 6
noop
noop
noop
noop
noop
addx 1
noop
noop
addx 7
addx 1
noop
addx -13
addx 13
addx 7
noop
addx 1
addx -33
noop
noop
noop
addx 2
noop
noop
noop
addx 8
noop
addx -1
addx 2
addx 1
noop
addx 17
addx -9
addx 1
addx 1
addx -3
addx 11
noop
noop
addx 1
noop
addx 1
noop
noop
addx -13
addx -19
addx 1
addx 3
addx 26
addx -30
addx 12
addx -1
addx 3
addx 1
noop
noop
noop
addx -9
addx 18
addx 1
addx 2
noop
noop
addx 9
noop
noop
noop
addx -1
addx 2
addx -37
addx 1
addx 3
noop
addx 15
addx -21
addx 22
addx -6
addx 1
noop
addx 2
addx 1
noop
addx -10
noop
noop
addx 20
addx 1
addx 2
addx 2
addx -6
addx -11
noop
noop
noop";
		var s2 = @"addx 1
addx 4
addx 1
noop
addx 4
noop
noop
noop
noop
addx 4
addx 1
addx 5
noop
noop
addx 5
addx -1
addx 3
addx 3
addx 1
noop
noop
addx 4
addx 1
noop
addx -38
addx 10
noop
noop
noop
noop
noop
addx 2
addx 3
addx -2
addx 2
addx 5
addx 2
addx -13
addx 14
addx 2
noop
noop
addx -9
addx 19
addx -2
addx 2
addx -9
addx -24
addx 1
addx 6
noop
noop
addx -2
addx 5
noop
noop
addx -12
addx 15
noop
addx 3
addx 3
addx 1
addx 5
noop
noop
noop
noop
addx -24
addx 29
addx 5
noop
noop
addx -37
noop
addx 26
noop
noop
addx -18
addx 28
addx -24
addx 17
addx -16
addx 4
noop
addx 5
addx -2
addx 5
addx 2
addx -18
addx 24
noop
addx -2
addx 10
addx -6
addx -12
addx -23
noop
addx 41
addx -34
addx 30
addx -25
noop
addx 16
addx -15
addx 2
addx -12
addx 19
addx 3
noop
addx 2
addx -27
addx 36
addx -6
noop
noop
addx 7
addx -33
addx -4
noop
addx 24
noop
addx -17
addx 1
noop
addx 4
addx 1
addx 14
addx -12
addx -14
addx 21
noop
noop
noop
addx 5
addx -17
addx 1
addx 20
addx 2
noop
addx 2
noop
noop
noop
noop
noop";

		var lines = s.Trim().Split("\n").Select(x => x.Substring(4).Trim()).Select(x => string.IsNullOrEmpty(x) ? 0 : int.Parse(x)); 
		Assert(DoTheThing(lines), 13140);
	}

	private static void Assert<T>(T actual, T expected, string message = "")
	{
		Console.WriteLine($"ok: actual: {actual} | expected: {expected}{(string.IsNullOrEmpty(message) ? "" : " | {message} ")}");
	}
	
	private static void AssertSequence<T>(IEnumerable<T> actual, IEnumerable<T> expected, string message = "")
	{
		if (actual.SequenceEqual(expected))
		{	
			Console.WriteLine($"ok: actual: {string.Join(",", actual)} | expected: same {(string.IsNullOrEmpty(message) ? "" : " | {message} ")}");
			return;
		}
		Console.WriteLine($"actual: {string.Join(",", actual)} | expected:  {string.Join(",", expected)}{(string.IsNullOrEmpty(message) ? "" : " | {message} ")}");
		Console.WriteLine($"diff: {string.Join(",", actual.Except(expected))} vs {string.Join(",", expected.Except(actual))}");
	}
	
	private static int LimitSignal(int x) => 40*x + 20;
	
	private static int DoTheThing(IEnumerable<int> lines)
	{
		var limits = Enumerable.Range(0, 6).Select(LimitSignal);
		AssertSequence(limits, new[]{20,60,100,140,180,220});
		var clock = Clock(lines);
		var result = limits.Select(x => (1 + clock.Take(x).Sum()) * x);
		AssertSequence(result, new[]{420,1140,1800,2940,2880,3960});
		return result.Sum() - limits.Last();
	}
	
	private static IEnumerable<int> Clock(IEnumerable<int> source)
	{
		foreach (var item in source)
		{
			yield return 0;
			if (item != 0)
			{
				yield return item;
			}
		}
	}
}
