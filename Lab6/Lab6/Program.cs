using System;
using static Lab6.Func;

namespace Lab6
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            string expression = "(a*(b+c))/d";
            Cell root = GenerateTree(expression);
            Console.WriteLine($"Binary tree for {expression}:");
            Console.WriteLine($"Level number 1: {root}\n{String(root, 2)}");
            Console.ReadLine();
        }
    }
}