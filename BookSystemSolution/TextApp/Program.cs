using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TextApp
{
    internal class Program
    {
        //static void Main()
        //{

        //    using (FileStream fs = new FileStream(@"D:\people.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite))
        //    {
                
        //            BinaryFormatter bf = new BinaryFormatter();

        //           //bf.Serialize(fs, people); 


        //        var storedData = (Person[])bf.Deserialize(fs);

        //        foreach (var item in storedData)
        //        {
        //            Console.WriteLine(item);
        //        }

        //    }
        //}

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            Console.Write("r: oxumaq,\nw: yazmaq\n :::: ");
            string cmd = Console.ReadLine();

            FileStream fs = new FileStream(@"C:\mynote.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            switch (cmd)
            {
                case "r":
                    {
                        StreamReader sr = new StreamReader(fs);
                        string text = sr.ReadToEnd();
                        Console.WriteLine(text);
                        sr.Close();
                        break;
                    }
                case "w":
                    {
                        StreamWriter sw = new StreamWriter(fs);
                        do
                        {
                            Console.Write("Text: ");
                            sw.WriteLine(Console.ReadLine());

                            Console.WriteLine("Davam etmek ucun enter sixin");
                        } while (Console.ReadKey().Key == ConsoleKey.Enter);

                        sw.Flush();
                        sw.Close();
                        fs.Close();
                        break;
                    }
                default:
                    break;
            }

            fs.Close();


        }
    }
}
