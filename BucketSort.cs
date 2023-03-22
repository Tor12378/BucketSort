using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

class BucketSortExample
{
    static void Main()
    {
        string filename = "data.txt"; // имя файла для хранения наборов данных
        int numOfSets = 50; // количество наборов данных
        int minNumOfElements = 100; // минимальное количество элементов в наборе
        int maxNumOfElements = 10000; // максимальное количество элементов в наборе

        GenerateTestData(filename, numOfSets, minNumOfElements, maxNumOfElements);

        int[] data;
        Stopwatch stopwatch = new Stopwatch();

        // считываем данные из файла и сортируем каждый набор
        using (StreamReader sr = new StreamReader(filename))
        {
            for (int i = 0; i < numOfSets+3; i++)
            {
                data = ReadData(sr);

                // сортируем массив и замеряем время и количество итераций
                stopwatch.Start();
                int iterations = BucketSort(data);
                stopwatch.Stop();

                Console.WriteLine("Set {0}: {1} elements, {2} iterations, {3} ms",
                    i + 1, data.Length, iterations, stopwatch.Elapsed.TotalMilliseconds);
               

                stopwatch.Reset();
            }
        }
    }

    static int[] ReadData(StreamReader sr)
    {
        // первый элемент в строке - количество элементов
        int numOfElements = int.Parse(sr.ReadLine());

        // остальные элементы разделены пробелом
        string[] elements = sr.ReadLine().Split(' ');

        int[] data = new int[numOfElements];

        for (int i = 0; i < numOfElements; i++)
        {
            data[i] = int.Parse(elements[i]);
        }

        return data;
    }

    static void GenerateTestData(string filename, int numOfSets, int minNumOfElements, int maxNumOfElements)
    {
        Random rnd = new Random();

        using (StreamWriter sw = new StreamWriter(filename))
        {
            for (int i = 0; i < numOfSets; i++)
            {
                int numOfElements = 100 + 200 * i;
                //int numOfElements = rnd.Next(minNumOfElements, maxNumOfElements + 1);
                sw.WriteLine(numOfElements);

                // генерируем элементы от 0 до 999
                for (int j = 0; j < numOfElements; j++)
                {
                    sw.Write(rnd.Next(1000000) + " ");
                }

                sw.WriteLine();
            }
            sw.WriteLine(10000);
            // генерируем элементы от 0 до 999
            for (int j = 0; j < 10000; j++)
            {
                sw.Write(rnd.Next(10000) + " ");
            }
            sw.WriteLine();
            sw.WriteLine(10000);
            // генерируем элементы от 0 до 999
            for (int j = 0; j < 10000; j++)
            {
                sw.Write(j + " ");
            }
            sw.WriteLine();
            sw.WriteLine(10000);
            // генерируем элементы от 0 до 999
            for (int j = 9999; j >= 0; j--)
            {
                sw.Write(j+ " ");
            }
            sw.WriteLine();
        }
    }

    static int BucketSort(int[] data)
    {
        int numOfBuckets = 10; // количество корзин
        int iterations = 0; // количество итераций

        List<int>[] buckets = new List<int>[numOfBuckets];

        // создаем корзины
        for (int i = 0; i < numOfBuckets; i++)
        {
            buckets[i] = new List<int>();
        }

        // распределяем элементы по корзинам
        for (int i = 0; i < data.Length; i++)
        {
            buckets[data[i] / 100000].Add(data[i]);
            
        }

        // сортируем каждую корзину
        for (int i = 0; i < numOfBuckets; i++)
        {
            buckets[i].Sort();
            iterations++;
        }

        int index = 0;

        // объединяем отсортированные корзины
        for (int i = 0; i < numOfBuckets; i++)
        {
            for (int j = 0; j < buckets[i].Count; j++)
            {
                data[index] = buckets[i][j];
                index++;
                iterations++;
            }
        }

        return iterations;
    }
}