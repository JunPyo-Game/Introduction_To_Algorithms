

using SortLibray;

class Program
{
	static void Main(string[] args)
	{
	int[] array = { 9, 7, 3, 1, 8, 2, 5, 4, 6, 0 };
		Console.WriteLine("[BubbleSort] Original array: " + string.Join(", ", array));
		Sort.BubbleSort(array);
		Console.WriteLine("[BubbleSort] Sorted array:   " + string.Join(", ", array));
	}
}
