using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

namespace BookSystem.Lib
{
    public class Helper
    {
        public static string ReadString(string caption, bool required = false)
        {
        l1:

            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            string value = Console.ReadLine();
            Console.ResetColor();
            if (required && string.IsNullOrWhiteSpace(value))
            {
                PrintError("Bos buraxila bilmez");
                goto l1;
            }

            return value;
        }

        public static int ReadInt(string caption, int minvalue = 1, int minValue = 0)
        {
        l1:
            Console.Write(caption);

            string value = Console.ReadLine();

            if (!int.TryParse(value, out int number))
            {
                PrintError("Duzgun reqem daxil edilmeyib");
                goto l1;
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
            Console.WriteLine(caption);
            string value = Console.ReadLine();
            double number;

            if (!double.TryParse(value, out number))
            {
                PrintError("Duzgun reqem daxil edin");
                goto l1;
            }
            else if (number < minvalue)
            {
                PrintError($"Minimal {minvalue} daxil edile biler");
                goto l1;
            }
            return number;
        }

        public static MenuStates ReadMenu(string caption)
        {
        l1:
            Console.WriteLine(caption);

            string value = Console.ReadLine();

            bool success = Enum.IsDefined(typeof(MenuStates), value);

            if (success)
            {
                PrintError("Bele menu movcu deyil");
                goto l1;
            }            
            if (!Enum.TryParse(value, out MenuStates menu))
            {
                PrintError("Belə bir menyu mövcud deyil çünki menyu sadəcə indeksə görə axtarıl malıdır!!!");
                goto l1;
            }
            return (MenuStates)Enum.Parse(typeof(MenuStates), value);
        }

        public static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void PrintWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void Init(string message)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.Title = "Book System v1.0";

            CultureInfo ci = new CultureInfo("az-Latn-Az");
            ci.NumberFormat.NumberDecimalSeparator = ".";
            ci.DateTimeFormat.ShortDatePattern = "dd.MM.yyyy";
            ci.DateTimeFormat.LongDatePattern = "dd.MM.yyyy";
            ci.DateTimeFormat.ShortTimePattern = "HH:mm";
            ci.DateTimeFormat.LongTimePattern = "HH:mm:ss";

            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }
        [Obsolete]
        public static void SaveToFile<T>(string filname, T graphData)
        {
            using (var fs = new FileStream(filname, FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(fs, graphData);
            }
        }
        [Obsolete]
        public static T LoadFromFile<T>(string filname)
        {
            if (!File.Exists(filname))
            {
                return default(T);
            }
            using (var fs = new FileStream(filname, FileMode.Open, FileAccess.Read))
            {

                BinaryFormatter bf = new BinaryFormatter();
                var graph = bf.Deserialize(fs);
                if (graph is T)
                {
                    return (T)graph;

                }

                return default(T);
            }

        }
    }
}
