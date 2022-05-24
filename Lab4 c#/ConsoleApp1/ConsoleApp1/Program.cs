using System;


namespace Lab3
{
    class Binary
    {

        private string binary;

        public string GetBinary
        {
            get { return binary; }
        }


        public Binary(string number)
        {
            binary = number;
        }

        public Binary(int[] arr)
        {
            binary = "";
            for (int i = 0; i < arr.Length; i++)
            {
                binary += arr[i];
            }
        }
        public Binary(int number)
        {
            int size = 0, number_copy = number;
            while (number_copy != 0)
            {
                size++;
                number_copy /= 2;
            }
            int[] num = new int[size];
            for (int i = 0; i < size; i++)
            {
                num[size - 1 - i] = number % 2;
                number /= 2;
            }
            binary = "";
            for (int i = 0; i < num.Length; i++)
            {
                binary += num[i].ToString();
            }
        }
        public int BinarytoDecimal()
        {
            int result = 0;
            for(int i = 0; i < binary.Length; i++) { 
                if(binary[i] == '1')
                {
                    result += 1 * Convert.ToInt32(Math.Pow(2, binary.Length - i - 1));
                }
            }
            return result; 
        }



        public static Binary operator +(Binary n1, Binary n2)
        {
            int result = n1.BinarytoDecimal() + n2.BinarytoDecimal();
            return new Binary(result);
        }
        public static Binary operator +(Binary n1, int n2)
        {
            int result = n1.BinarytoDecimal() + n2;
            return new Binary(result);
        }
        public static Binary operator ++(Binary n1)
        {
            int result = n1.BinarytoDecimal() + 1;
            return new Binary(result);
        }
    }

    

    internal class Program
    {
        static int[] GetArray(int n)
        {
            int size = 0, n_copy = n;
            while (n_copy != 0)
            {
                size++;
                n_copy /= 10;
            }
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[size - 1 - i] = n % 10;
                n /= 10;
            }
            return arr;
        }
        static void Main(string[] args)
        {
            string n1;
            int[] n2;
            int n3;
            Console.WriteLine("Input your first num:");
            n1 = Console.ReadLine();
            Console.WriteLine("Input your second num:");
            int n = int.Parse(Console.ReadLine());
            n2 = GetArray(n);
            Console.WriteLine("Input your third num (decimal):");
            n3 = int.Parse(Console.ReadLine());
            Console.WriteLine("Start results:");
            Binary N1 = new Binary(n1);
            Console.WriteLine("First num (dec): " + N1.BinarytoDecimal() + "\t" + "First num(bin): " + N1.GetBinary); 
            Binary N2 = new Binary(n2);
            Console.WriteLine("First num (dec): " + N2.BinarytoDecimal() + "\t" + "First num(bin): " + N2.GetBinary);
            Binary N3 = new Binary(n3);
            Console.WriteLine("First num (dec): " + N3.BinarytoDecimal() + "\t" + "First num(bin): " + N3.GetBinary);
            N1++;
            N2 += 7;
            N3 = N1 + N2;
            Console.WriteLine("Final results:");
            Console.WriteLine("First num (dec): " + N1.BinarytoDecimal() + "\t" + "First num(bin): " + N1.GetBinary);
            Console.WriteLine("First num (dec): " + N2.BinarytoDecimal() + "\t" + "First num(bin): " + N2.GetBinary);
            Console.WriteLine("First num (dec): " + N3.BinarytoDecimal() + "\t" + "First num(bin): " + N3.GetBinary);
            Console.ReadLine();
        }
    }
}
