using System;

namespace Helpers.Lib
{
    public class Helper
    {
        public static string ReadString(string caption, bool required = false)
        {
        l1:
            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.Green;

            string value = Console.ReadLine();
            Console.ResetColor();

            if (required == true && string.IsNullOrWhiteSpace(value))
            {
                PrintError("Bosh buraxila bilmez");
                goto l1;
            }

            return value;
        }

        public static int ReadInt(string caption, int minvalue = 0)
        {
        l1:
            Console.Write(caption);

            string value = Console.ReadLine();

            int number;

            if (int.TryParse(value, out number) || minvalue > number)
            {
                PrintError("Duzgun reqem daxil edilmeyib");
            }

            
            else if (number < minvalue)
            {
                PrintError($"Minimal {minvalue} daxil edile biler");
                goto l1;
            }
            return number;
        }

        public static double ReadDouble(string caption, double minvalue = 0)
        {
        l1:
            Console.Write(caption);

            string value = Console.ReadLine();

            double number;

            if (double.TryParse(value, out number) || minvalue > number)
            {
                PrintError("Duzgun reqem daxil edilmeyib");
            }
            else if (number < minvalue)
            {
                PrintError($"Minimal {minvalue} daxil edile biler");
                goto l1;
            }
            return number;
        }


        public static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ResetColor();
        }





    }
}
