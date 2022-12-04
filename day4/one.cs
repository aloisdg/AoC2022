using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
	static bool IsSubRange(int a1, int a2, int b1, int b2) => (a1 >= b1 && a2 <= b2) || (a1 <= b1 && a2 >= b2);
	public static void Main()
	{
		@"2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8"
			.Split("\n")
			.Select(x => x.Split(new[]{',', '-'}).Select(int.Parse).ToArray())
			.Count(x => IsSubRange(x[0], x[1], x[2], x[3]))
			.Dump();
	}
}
