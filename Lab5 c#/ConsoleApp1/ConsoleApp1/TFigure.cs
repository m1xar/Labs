using System;

namespace ConsoleApp1
{
    class TFigure
    {
        private int[,] Figure;
        public int[,] fgr
        {
            get { return Figure; }
            set { Figure = value; }
        }


        public double CalculateS()
        {
            double S = 0;
            for (int i = 1; i < Figure.GetLength(0); i++)
            {
                S += Figure[i - 1, 0] * Figure[i, 1];
                S -= Figure[i, 0] * Figure[i - 1, 1];
            }
            S += Figure[Figure.GetLength(0) - 1, 0] * Figure[0, 1];
            S -= Figure[0, 0] * Figure[Figure.GetLength(0) - 1, 1];
            return Math.Abs(S) / 2;
        }
        public double CalculateP()
        {
            double P = 0;
            for(int i = 0; i < Figure.GetLength(0) - 1; i++)
            {
                double line = 0;
                line = Math.Sqrt(Math.Pow((Figure[i + 1, 0] - Figure[i, 0]), 2) + Math.Pow((Figure[i + 1, 1] - Figure[i, 1]), 2));
                P += line;
            }
            P += Math.Sqrt(Math.Pow((Figure[0, 0] - Figure[Figure.GetLength(0)-1, 0]), 2) + Math.Pow((Figure[0, 1] - Figure[Figure.GetLength(0)-1, 1]), 2));
            return P;
        }
        public void outputFigure()
        {
            for(int i = 0; i < Figure.GetLength(0); i++)
            {
                Console.WriteLine($"Point number {i+1}: x = {Figure[i, 0]} y = {Figure[i, 1]}");
            }
        }
    }
}
