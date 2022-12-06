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

int d_strlen(char *str)
{
	int i;
	for (i = 0; str[i] != 0; i++);
	return i;
}

int isDistinctive(char *str, int maker, int start)
{
	for (int i = start; i < maker; i++)
	{
		for (int j = i + 1; j < maker; j++)
		{
			if (str[i] == str[j])
			{
				return 0;
			}
		}
	}

	return 1;
}

int findMakerIndex(char *signal, int maker)
{
	int length = d_strlen(signal);

	for (int i = 0; i < length; i++)
	{
		if (isDistinctive(signal, maker, i) == 1)
		{
			return i + maker;
		}
	}

	return -1;
}

int main()
{
	char *signal = "nppdvjthqldpwncqszvftbrmjlhg";
	int maker = 14;
	d_putnumber(findMakerIndex(signal, maker));
	return 0;
}
