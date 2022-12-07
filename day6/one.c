#include <unistd.h>

void d_putchar(char c)
{
	write(1, &c, 1);
}

void d_putnumber(int n)
{
	if (n < 0)
	{
		d_putchar('-');
		n = -n;
	}

	if (n < 10)
	{
		d_putchar(n + '0');
	}
	else
	{
		d_putnumber(n / 10);
		d_putchar(n % 10 + '0');
	}
}

void d_putnumber_ln(int n)
{
	d_putnumber(n);
	d_putchar('\n');
}

int d_strlen(char *str)
{
	int i;
	for (i = 0; str[i] != 0; i++);
	return i;
}

int has_duplicate(char *str, int marker, int start)
{
	for (int i = 0; i < marker; i++)
	{
		for (int j = i + 1; j < marker; j++)
		{
			if (str[start + i] == str[start + j])
			{
				return 1;
			}
		}
	}

	return 0;
}

int find_marker(char *signal, int marker)
{
	int length = d_strlen(signal);

	for (int i = 0; i < length; i++)
	{
		if (has_duplicate(signal, marker, i) == 0)
		{
			return i + marker;
		}
	}

	return -1;
}

int main()
{
	int marker = 4;

	d_putnumber_ln(find_marker("mjqjpqmgbljsphdztnvjfqwrcgsmlb", marker));	// 7
	d_putnumber_ln(find_marker("bvwbjplbgvbhsrlpgdmjqwftvncz", marker));	// 5
	d_putnumber_ln(find_marker("nppdvjthqldpwncqszvftbrmjlhg", marker));	// 6
	d_putnumber_ln(find_marker("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", marker));	// 10
	d_putnumber_ln(find_marker("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", marker));	// 11
	return 0;
}
