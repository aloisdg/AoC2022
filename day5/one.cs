using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Program
{
	public static void Main()
	{
		var s = @"
	[D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2";
		
		var lines = s.Replace("\t", "    ").Split("\n\n");
		var state = lines[0].Split('\n', StringSplitOptions.RemoveEmptyEntries);
		var prompt = lines[1].Split("\n");
	
		var stacks = state
			.SkipLast(1)
			.Select(row => row.Where((_, i) => (i - 1) % 4 == 0))
			.Transpose()
			.Select(col => col.Where(c => c != ' '))
			.Select(col => new Stack<char>(col.Reverse()))
			.ToArray();
		
		var pattern = new Regex(@"move (?<count>\d+) from (?<origin>\d+) to (?<target>\d+)");
		var actions = prompt
			.Select(line => 
					  {
						  var count = int.Parse(pattern.Match(line).Groups["count"].Value);
						  var origin = int.Parse(pattern.Match(line).Groups["origin"].Value) - 1;
						  var target = int.Parse(pattern.Match(line).Groups["target"].Value) - 1;
						  return (count, origin, target);
					  }
				   );
				
			foreach (var action in actions) {
				for (var i = 0; i < action.count; i++) {
					stacks[action.target].Push(stacks[action.origin].Pop());
				}
			}
		
		string.Concat(stacks.Select(x => x.First())).Dump();
	
	}
}

public static class Ext
{
	public static IEnumerable<IEnumerable<T>> Transpose<T>(this IEnumerable<IEnumerable<T>> array) =>
		array.First().Select((_, colIndex) => array.Select(row => row.ElementAt(colIndex)));
}
