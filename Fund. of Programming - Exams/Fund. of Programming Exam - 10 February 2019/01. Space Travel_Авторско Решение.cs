using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string name = Console.ReadLine();
                string code = Console.ReadLine();
                string message = "";
                for (int i = 0; i < code.Length - 1; i += 2)
                {
                    string current = "";
                    current += code[i];
                    current += code[i + 1];
                    int number = int.Parse(current);

                    message += (char)number;
                }
                Console.WriteLine(message);
                if(message.ToLower() == "go home")
                {
                    Console.WriteLine("Going home.");
                    break;
                }
            }
        }     
    }
}