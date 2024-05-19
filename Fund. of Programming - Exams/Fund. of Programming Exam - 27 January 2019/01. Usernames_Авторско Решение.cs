using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // ASCII Approach:
            while (true)
            {
                string username = Console.ReadLine();
                bool checkifInvalid = false;

                for (int j = 0; j < username.Length; j++)
                {
                    if (username[j] < 65 || (username[j] > 90 && username[j] < 97) || username[j] > 122)
                    {
                        checkifInvalid = true;
                    }
                }

                if (checkifInvalid)
                {
                    Console.WriteLine("Invalid username!");
                }
                else
                {
                    break;
                }
            }
            //REGEX Approach:
            //string name = string.Empty;
            //while (true)
            //{
            //    name = Console.ReadLine();

            //    var regex = new Regex("^[A-Za-z]+$");

            //    Match match = regex.Match(name);

            //    if (match.Success)
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Invalid username!");
            //    }
            //}
        }
    }
}