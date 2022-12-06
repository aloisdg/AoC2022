def find_marker_index(signal, marker):
	for i in range(len(signal)):
		if len(set(signal[i:i+marker])) == marker:
			return i + marker

	return -1

s = "bvwbjplbgvbhsrlpgdmjqwftvncz"
marker = 4
print(find_marker_index(s, marker))
