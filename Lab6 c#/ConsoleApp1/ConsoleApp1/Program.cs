using System;
using System.Linq.Expressions;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Tree(double[] values)
        {
            ParameterExpression aParam = Expression.Parameter(typeof(double), "a");
            ParameterExpression bParam = Expression.Parameter(typeof(double), "b");
            ParameterExpression cParam = Expression.Parameter(typeof(double), "c");
            ParameterExpression dParam = Expression.Parameter(typeof(double), "d");

            Expression sum = Expression.Add(bParam, cParam);
            Expression mult = Expression.Multiply(aParam, sum);
            Expression div = Expression.Divide(mult, dParam);

            LambdaExpression lambdaExpression = Expression.Lambda(div, aParam, bParam, cParam, dParam);

            var result = (Func<double, double, double, double, double>)lambdaExpression.Compile();

            Console.WriteLine($"Result = {result(values[0], values[1], values[2], values[3])}");
        }

        static double[] setValues()
        {
            double[] values = new double[4];
            Console.WriteLine("Set a:");
            values[0] = int.Parse(Console.ReadLine());
            Console.WriteLine("Set b:");
            values[1] = int.Parse(Console.ReadLine());
            Console.WriteLine("Set c:");
            values[2] = int.Parse(Console.ReadLine());
            Console.WriteLine("Set d:");
            values[3] = int.Parse(Console.ReadLine());
            return values;

        }

        static void Main(string[] args)
        {
            double[] values = new double[4];
            values = setValues();
            Tree(values);
        }
    }
}
