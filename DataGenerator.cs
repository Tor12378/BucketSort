using System;
using System.IO;

class DataGenerator
{
    private const int MinValue = 0;
    private const int MaxValue = 10000;

    public static void Generate(int size, string filename)
    {
        Random random = new Random();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            for (int i = 0; i < size; i++)
            {
                writer.WriteLine(random.Next(MinValue, MaxValue));
            }
        }
    }
}