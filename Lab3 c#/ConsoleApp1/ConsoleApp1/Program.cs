using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static CustomText[] setText(int n)
        {
            CustomText[] texts = new CustomText[n];
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine($"Set line number {i+1}");
                texts[i] = new CustomText();
                texts[i].txt = Console.ReadLine(); 
            }
            return texts;
        }
        static void addText(CustomText[] texts)
        {
            bool key = true;
            while (key)
            {
                Console.WriteLine("Which line do you want to add text to?");
                int a = int.Parse(Console.ReadLine());
                if (a > texts.Length)
                    Console.WriteLine("Line is out of range!");
                else
                {
                    texts[a - 1].addLine();
                }
                Console.WriteLine("Do you want to add more text? (+ or -)");
                char c = Char.Parse(Console.ReadLine());
                if (c == '+')
                    key = true;
                else
                    key = false;
            }
        }
        static void findLine(CustomText[] texts)
        {
            int n = 0, index=0;
            for(int i = 0; i < texts.Length; i++)
            {
                if (texts[i].countDoubles() > n)
                {
                    n = texts[i].countDoubles();
                    index = i;
                }
            }
            Console.WriteLine($"{index+1} is the line with the greatest number of doubling of letter which is equal to {n}");
            Console.WriteLine("This line: " + texts[index].txt);
        }
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Input number of lines:");
            n = int.Parse(Console.ReadLine());
            CustomText[] texts = setText(n);
            addText(texts);
            findLine(texts);
        }
    }
}
