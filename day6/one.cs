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
	
	// for fun
	public static int FindMarkerIndexRec(string signal, int marker)
	{
		int loop(int i) => signal.Substring(i, marker).Distinct().Count() == marker
			? i + marker
			: loop(i + 1);
		
		return loop(0);
	}
}
