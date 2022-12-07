using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
	record struct Node(int size, List<Node> children);
	
	public static void Main()
	{
		var s = @"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k";
		var sizes = GetSizes(s);
		var freeSpace = 70000000 - sizes.Max();
		sizes.Where(x => x + freeSpace >= 30000000).Min().Dump();
	}

	private static Node ParseNode(Stack<string> lines)
	{
		lines.Pop();
		var size = 0;
		var children = new List<Node>();
		while (lines.TryPop(out string current) && current != "$ cd ..")
		{
			if (current.StartsWith("$ cd"))
			{
				var child = ParseNode(lines);
				children.Add(child);
				size += child.size;
				continue;
			}

			if (!current.StartsWith("dir "))
			{
				size += int.Parse(current.Remove(current.IndexOf(" ")));
			}
		}

		return new Node(size, children);
	}

	private static IEnumerable<Node> Flatten(Node node) => node.children.SelectMany(Flatten).Append(node);
	
	private static IEnumerable<int> GetSizes(string input)
	{
		var lines = new Stack<string>(input.Split("\n").Skip(1).Reverse());
		return Flatten(ParseNode(lines)).Select(x => x.size);
	}
}
