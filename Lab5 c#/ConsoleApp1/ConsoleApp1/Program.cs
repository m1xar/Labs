using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static TPentagon[] createPentagones(int n)
        {
            TPentagon[] arr = new TPentagon[n];
            for(int i = 0; i < n; i++)
            {
                Console.Write("Do you want to set this pentagone automatically? (+ or -) : ");
                if(Console.ReadLine() == "+")
                    arr[i] = new TPentagon(true);
                else
                    arr[i] = new TPentagon();
            }
            return arr;
        }

        static THexagon[] createHexagones(int m)
        {
            THexagon[] arr = new THexagon[m];
            for (int i = 0; i < m; i++)
            {
                Console.Write("Do you want to set this hexagone automatically? (+ or -) : ");
                if (Console.ReadLine() == "+")
                    arr[i] = new THexagon(true);
                else
                    arr[i] = new THexagon();
            }
            return arr;
        } 

        static int MaxP(TPentagon[] pentas, int n)
        {
            double P = 0;
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                if(pentas[i].CalculateP() > P)
                {
                    index = i + 1;
                    P = pentas[i].CalculateP();
                }
            }
            return index;
        }
        static int MinS(THexagon[] hexas, int m) 
        {
            double S = double.MaxValue;
            int index = 0; 
            for (int i = 0; i < m; i++)
            {
                if(hexas[i].CalculateS() < S){
                    index = i + 1;
                    S = hexas[i].CalculateS();
                }
            }
            return index;
        }

        static void outPentas(TPentagon[] pentagones)
        {
            Console.WriteLine("Your pentagones:");
            for(int i = 0; i < pentagones.Length; i++)
            {
                Console.WriteLine($"Pentagone number {i+1}");
                pentagones[i].outputFigure();
            }
        }

        static void outHexas(THexagon[] hexagones)
        {
            Console.WriteLine("Your pentagones:");
            for (int i = 0; i < hexagones.Length; i++)
            {
                Console.WriteLine($"Pentagone number {i + 1}");
                hexagones[i].outputFigure();
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Set number of pentagones:");
            int n = int.Parse(Console.ReadLine());
            TPentagon[] pentagones = createPentagones(n);
            Console.Write("Set number of hexagones:");
            int m = int.Parse(Console.ReadLine());
            THexagon[] hexagones = createHexagones(m);
            int minS = MinS(hexagones, m);
            int maxP = MaxP(pentagones, n);
            outPentas(pentagones);
            outHexas(hexagones);
            Console.WriteLine($"Hexagone number {minS} have the least area! It is equal to {hexagones[minS-1].CalculateS()}");
            Console.WriteLine($"Pentagone number {maxP} have the greatest perimeter! It is equal to {pentagones[maxP-1].CalculateP()}");
        }
    }
}
