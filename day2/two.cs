using System;
using System.Linq;

public class Program
{
	public static void Main()
	{
		var s = @"A Y
B X
C Z";
		Console.WriteLine(s.Split("\n").Sum(Score));
	}

	static int Score(string input) => input switch
	{
		("A Y") => 1 + 3, // ok
		("B Y") => 2 + 3,
		("C Y") => 3 + 3,
		("A X") => 3 + 0,
		("B X") => 1 + 0, // ok
		("C X") => 2 + 0,
		("A Z") => 2 + 6,
		("B Z") => 3 + 6,
		("C Z") => 1 + 6, // ok
	};
}
