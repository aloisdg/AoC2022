using System;
using System.Linq;

public class Program
{
	public static (string, string) Half(string s) => (s[..(s.Length / 2)], s[(s.Length / 2)..]);
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
		.Select(Half)
		.Select(t => t.Item1.Intersect(t.Item2).Single())
		.Sum(Prioritize)
		.Dump();
	}
}
