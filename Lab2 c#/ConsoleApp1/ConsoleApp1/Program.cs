using System;
using System.IO;

namespace ConsoleApp1
{
    struct Book
    {
        public string name;
        public string date;
        public int year;
    }
    internal class Program
    {
        static void createFile1(string path)
        {
            BinaryWriter file = new BinaryWriter(File.Open(path, FileMode.Append, FileAccess.Write));
            Console.WriteLine("Input number of books:");
            int n = int.Parse(Console.ReadLine());
            Book[] books = new Book[n];
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine($"Book number {i+1}:");
                books[i] = new Book();
                Console.WriteLine("Set name:");
                books[i].name = Console.ReadLine();
                Console.WriteLine("Set writing date:");
                books[i].date = Console.ReadLine();
                Console.WriteLine("Set publication year (write 0 if book has not been publicated): ");
                books[i].year = int.Parse(Console.ReadLine());
            }
            foreach (Book book in books)
            {
                file.Write(book.name);
                file.Write(book.date);
                file.Write(book.year);
            }
            file.Close();
        }
        static void createFile2(string path1, string path2)
        {
            BinaryReader file1 = new BinaryReader(File.Open(path1, FileMode.Open, FileAccess.Read));
            BinaryWriter file2 = new BinaryWriter(File.Open(path2, FileMode.Create, FileAccess.Write));
            while(file1.PeekChar() != -1)
            {
                Book book = new Book();
                book.name = file1.ReadString();
                book.date = file1.ReadString();
                book.year = file1.ReadInt32();
                if(book.year <= 2000)
                {
                    file2.Write(book.name);
                    file2.Write(book.date);
                    file2.Write(book.year);
                }
            }
            file1.Close();
            file2.Close();
        }
        static void outputfile(string path)
        {
            Console.WriteLine(path + ':');
            BinaryReader file = new BinaryReader(File.Open(path, FileMode.Open, FileAccess.Read));
            int i = 1;
            while(file.PeekChar() != -1)
            {
                Console.WriteLine($"Book number {i}");
                Console.WriteLine(file.ReadString());
                Console.WriteLine(file.ReadString());
                Console.WriteLine(file.ReadInt32());
                i++;
            }
            file.Close();
        }
        static void countWinterBooks(string path)
        {
            BinaryReader file = new BinaryReader(File.Open(path, FileMode.Open, FileAccess.Read));
            int counter = 0;
            while (file.PeekChar() != -1)
            {
                Book book = new Book();
                book.name = file.ReadString();
                book.date = file.ReadString();
                book.year = file.ReadInt32();
                if(int.Parse(book.date[3..5]) == 2 || int.Parse(book.date[3..5]) == 1 || int.Parse(book.date[3..5]) == 12)
                {
                    counter++;
                }
            }
            Console.WriteLine($"Number of winter books is equal to {counter}");
            file.Close();

        }
        static void Main(string[] args)
        {
            string path1 = "firstFile.txt", path2 = "secondFile.txt";
            createFile1(path1);
            createFile2(path1, path2);
            outputfile(path2);
            countWinterBooks(path1);
            outputfile(path1);
        }
    }
}
