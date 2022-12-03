using System;
using System.Linq;

public class Program
{
	public static int Prioritize(char c) => c - (char.IsLower(c) ? 'a' : ('A' - 26)) + 1;

	public static void Main()
	{
		@"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw"
		.Split('\n')
		.Chunk(3)
		.SelectMany(a => a[0].Intersect(a[1]).Intersect(a[2]))
		.Sum(Prioritize)
		.Dump();
	}
}
