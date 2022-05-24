using System;

namespace ConsoleApp1
{
    class THexagon : TFigure
    {
        public THexagon(bool randKey = false)
        {
            if (randKey)
            {
                int[,] arr = new int[6, 2];
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Random rand = new Random();
                        arr[i, j] = rand.Next(10);
                    }
                }
                fgr = arr;
            }
            else
            {
                Console.WriteLine("Set your hexagon: ");
                int[,] arr = new int[6, 2];
                for (int i = 0; i < 6; i++)
                {
                    Console.WriteLine($"Point {i + 1}:");
                    for (int j = 0; j < 2; j++)
                    {
                        if (j == 0)
                            Console.Write("X = ");
                        else
                            Console.Write("Y = ");
                        arr[i, j] = int.Parse(Console.ReadLine());
                    }
                }
                fgr = arr;
            }
        }
    }
}
