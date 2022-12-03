using System;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
		var s = @"1000
2000
3000
4000
5000
6000
7000
8000
9000
10000";
	var maxCalories = s
		.Split("\n\n")
		.Select(x => x.Split('\n').Sum(int.Parse))
		.OrderDescending()
		.Take(3)
		.Sum();
	Console.WriteLine(maxCalories);
	}
}
