using System;


namespace ConsoleApp1
{
    internal class CustomText
    {
        private string Text;

        public string txt
        {
            get { return Text; }
            set { Text = value; }
        }

        public int countDoubles()
        {
            int result = 0;
            for(int i = 0; i < txt.Length-1; i++)
            {   
                if(txt[i] == txt[i + 1])
                {
                    result++;
                    i++;
                }
            }
            return result;
        }
        public void addLine()
        {
            Console.WriteLine("Input this line:");
            string line = Console.ReadLine();
            Text += line;
        }
    }
}
