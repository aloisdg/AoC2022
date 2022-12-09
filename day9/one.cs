using System;
using System.Linq;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		var s = @"R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2";

		var lines = s.Split("\n").Select(x => x.Split(" ")).Select(x => (x[0][0], int.Parse(x[1])));
		var length = 2;
		var rope = new (int x, int y)[length];
		lines
			.Select(line => {
				var (direction, steps) = line;
				return (direction, steps);
			})
			.SelectMany(line =>
				Enumerable.Range(0, line.steps).Select(_ => {
					var (head, body) = rope;
					var newHead = MoveHead(head, line.direction);
					rope = UpdateRope(length, body.Prepend(newHead).ToArray());
					return rope.Last();
			})).Distinct().Count().Dump();
	}
	
	private static (int x, int y)[] UpdateRope(int length, (int x, int y)[] rope)
	{
		for (int j = 1; j < length; j++)
		{
			var newTail = MoveTail(rope[j - 1], rope[j]);
			if (newTail == rope[j])
			{
				return rope; 
			}
			rope[j] = newTail;
		}
		return rope;
	}
	
	private static (int x, int y) MoveHead((int x, int y) head, char direction) =>
		direction switch
		{
			'U' => (head.x, head.y - 1),
			'D' => (head.x, head.y + 1),
			'L' => (head.x - 1, head.y),
			'R' => (head.x + 1, head.y),
			_ => head,
		};

	private static (int x, int y) MoveTail((int x, int y) head, (int x, int y) tail) =>
		(head.x - tail.x, head.y - tail.y) switch
		{
			( > 1, > 1) => (head.x - 1, head.y - 1),
			( > 1, < -1) => (head.x - 1, head.y + 1),
			( < -1, > 1) => (head.x + 1, head.y - 1),
			( < -1, < -1) => (head.x + 1, head.y + 1),
			( > 1, _) => (head.x - 1, head.y),
			( < -1, _) => (head.x + 1, head.y),
			(_, > 1) => (head.x, head.y - 1),
			(_, < -1) => (head.x, head.y + 1),
			_ => (tail.x, tail.y),
		};
}

public static class Extensions
{
    public static void Deconstruct<T>(this IList<T> list, out T first, out IList<T> rest)
	{
        first = list.Count > 0 ? list[0] : default(T);
        rest = list.Skip(1).ToList();
    }
}
