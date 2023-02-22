bool IsWork = true;

while (IsWork)

{
    Console.WriteLine();
    Console.WriteLine("Выберите программу:");
    Console.WriteLine("1 - Программа создаёт двумерынй массив размером m*n, заполненный случайными вещественными числами");
    Console.WriteLine("2 - Программа принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет");
    Console.WriteLine("3 - Программа создаёт двумерный массив из целых чисел и записывает среднее арифметическое элементов в каждом столбце в псоледнюю строку");
    Console.WriteLine("-1 - Для завершения работы");
    Console.Write("Выберите программу: ");

    int ReadInt(string argument)
    {
        Console.Write($"Введите {argument}: ");
        int number;

        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("вы ввели не число");
        }

        return number;
    }

    double[,] CreateRandomTwoDimensionDoubleArray(int m, int n)
    {
        double[,] result = new double[m, n];
        Random rnd = new Random();

        for (int i = 0; i < result.GetLength(0); i++)
        {
            for (int j = 0; j < result.GetLength(1); j++)
            {
                result[i, j] = Math.Round(rnd.NextDouble() * 10, 2);
            }
        }
        return result;
    }

    int[,] CreateRandomTwoDimensionIntArray(int m, int n)
    {
        int[,] result = new int[m, n];
        Random rnd = new Random();

        for (int i = 0; i < result.GetLength(0); i++)
        {
            for (int j = 0; j < result.GetLength(1); j++)
            {
                result[i, j] = rnd.Next(1, 10);
            }
        }
        return result;
    }

    string PrintTwoDimensionDoubleArray(double[,] array)
    {
        string result = string.Empty;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                result += $"{array[i, j]} ";
            }
            result += Environment.NewLine;
        }

        return result;
    }

    string PrintTwoDimensionIntArray(int[,] array)
    {
        string result = string.Empty;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                result += $"{array[i, j]} ";
            }
            result += Environment.NewLine;
        }

        return result;
    }

    if (int.TryParse(Console.ReadLine(), out int i))
    {
        switch (i)
        {
            case 1:
                {
                    Task_1();

                    void Task_1()
                    {
                        double[,] array = CreateRandomTwoDimensionDoubleArray(ReadInt("количество строк"), ReadInt("количество столбцов"));
                        Console.WriteLine();
                        Console.WriteLine(PrintTwoDimensionDoubleArray(array));
                    }

                    break;
                }
            case 2:
                {
                    Task_2();

                    void Task_2()
                    {
                        int m = ReadInt("сколько строк должно быть в массиве? ");
                        int n = ReadInt("сколько столбцов должно быть в массиве? ");
                        int[,] arrayD = CreateRandomTwoDimensionIntArray(m, n);
                        Console.WriteLine($"создан массив: ");
                        Console.WriteLine(PrintTwoDimensionIntArray(arrayD));

                        FindNumber(arrayD);

                        void FindNumber(int[,] array)
                        {
                            int i = ReadInt("номер строки");
                            int j = ReadInt("номер столбца");

                            if (i >= array.GetLength(0) + 1 || j >= array.GetLength(1) + 1)
                            {
                                Console.WriteLine("такого элемента в массиве нет");
                            }
                            else
                            {
                                Console.WriteLine($"в строке {i}, столбца {j} находится цифра: {array[i - 1, j - 1]}");
                            }
                        }
                    }

                    break;
                }
            case 3:
                {

                    Task_3();

                    void Task_3()
                    {
                        int m = ReadInt("сколько строк должно быть в массиве");
                        int n = ReadInt("сколько столбцов должно быть в массиве");
                        int[,] array = CreateRandomTwoDimensionIntArray(m, n);
                        double[,] newArray = NewArray(array);
                        Console.WriteLine($"создан массив: ");
                        Console.WriteLine(PrintTwoDimensionIntArray(array));
                        Console.WriteLine(PrintTwoDimensionDoubleArray(GetAverage(newArray)));

                        double[,] NewArray(int[,] array)
                        {
                            double[,] newArray = new double[array.GetLength(0) + 1, array.GetLength(1)];

                            for (int i = 0; i < array.GetLength(0); i++)
                            {
                                for (int j = 0; j < array.GetLength(1); j++)
                                {
                                    newArray[i, j] = array[i, j];
                                }
                            }

                            return newArray;
                        }

                        double[,] GetAverage(double[,] array)
                        {
                            double sum = 0;
                            double average = 0;

                            for (int j = 0; j < array.GetLength(1); j++)
                            {
                                for (int i = 0; i < array.GetLength(0); i++)
                                {
                                    sum += array[i, j];
                                }
                                average = Math.Round(sum / (array.GetLength(0) - 1), 2);
                                array[array.GetLength(0) - 1, j] = average;
                                sum = 0;
                                average = 0;
                            }

                            return array;
                        }
                    }

                    break;
                }

            case -1: IsWork = false; break;
        }
    }
}