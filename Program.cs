using System;
using System.Diagnostics;
using System.IO;
/*
class Program
{
    private const int MinSize = 100;
    private const int MaxSize = 10000;
    private const int NumSets = 100;

    static void Main(string[] args)
    {
        string directory = "data";
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        // Генерация наборов данных
        for (int i = 0; i < NumSets; i++)
        {
            int size = (i * (MaxSize - MinSize) / (NumSets - 1)) + MinSize;
            string filename = Path.Combine(directory, $"data_{i:D4}.txt");
            DataGenerator.Generate(size, filename);
        }
        // Запуск алгоритма на каждом наборе данных
        Stopwatch stopwatch = new Stopwatch();
        for (int i = 0; i < NumSets; i++)
        {
            string filename = Path.Combine(directory, $"data_{i:D4}.txt");
            int[] array = File.ReadAllLines(filename).Select(int.Parse).ToArray();
            stopwatch.Restart();
            BucketSort.Sort(array);
            stopwatch.Stop();
            Console.WriteLine($"Set {i:D4}: Size = {array.Length}, Time = {stopwatch.ElapsedMilliseconds} ms, Iterations = {array.Length}");
        }
    }
}
*/