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
		("A Y") => 2 + 6,
		("B Y") => 2 + 3,
		("C Y") => 2 + 0,
		("A X") => 1 + 3,
		("B X") => 1 + 0,
		("C X") => 1 + 6,
		("A Z") => 3 + 0,
		("B Z") => 3 + 6,
		("C Z") => 3 + 3,
	};
}
