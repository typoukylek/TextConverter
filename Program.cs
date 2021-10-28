using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Write a text: ");
            string consoleText = Console.ReadLine();
            Console.WriteLine("Choose [1] to save in TXT\nChoose [2] to save in CSV\n Choose [3] to save in PDF");
            string format = Console.ReadLine();
            WriteFile wf = new WriteFile();

            switch (format)
            {
                case "1":
                    wf.WriteToFile(consoleText, "txt");
                    Console.WriteLine($"File Console.TXT Saved. {Environment.CurrentDirectory}");
                    break;
                case "2":
                    {
                        consoleText = consoleText.Replace(" ", ";");
                        wf.WriteToFile(consoleText, "csv");
                        Console.WriteLine($"File Console.CSV Saved. + {Environment.CurrentDirectory}");
                    }
                    break;
                case "3":
                    {
                        //pdf
                    }
                    break;
            }

            Console.Read();
        }


        interface IWrite
        {
            void WriteToFile(string text, string type);
        }

        class WriteFile : IWrite
        {
            public void WriteToFile(string text, string type)
            {
                using (StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + @"\Console." + type, false, Encoding.GetEncoding("utf-8")))
                {
                    sw.WriteLine(text);
                }
            }
        }

    }
}