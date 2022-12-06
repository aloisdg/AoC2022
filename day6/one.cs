using System;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
		var s = "mjqjpqmgbljsphdztnvjfqwrcgsmlb";

		for (var i = 0; i < s.Length; i++)
		{
			if (s.Substring(i, 4).Distinct().Count() == 4)
			{
				Console.WriteLine(i + 4);
				return;
			}
		}
	}
}
