using System;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
		var s = "bvwbjplbgvbhsrlpgdmjqwftvncz";
		var maker = 4;
		FindMakerIndex(s, maker).Dump();
	}
	
	public static int FindMakerIndex(string signal, int maker)
	{
		for (var i = 0; i < signal.Length; i++)
		{
			if (signal.Substring(i, maker).Distinct().Count() == maker)
			{
				return i + maker;
			}
		}
		return -1;
	}
}
