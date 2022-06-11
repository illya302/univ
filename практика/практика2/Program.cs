using System;
using part1;

namespace part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;

            var a = new DoublyLinkedList<Student>();
            var command = "/help";
            while (command != "/end") 
            {
                try
                {
                    switch (command)
                    {
                        case "/help":
                            CommandHandler.Help();
                            break;
                        case "/add":
                            CommandHandler.AddStudent(ref a);
                            CommandHandler.ShowList(ref a);
                            break;
                        case "/delete":
                            CommandHandler.RemoveStudent(ref a);
                            CommandHandler.ShowList(ref a);
                            break;
                        case "/show":
                            CommandHandler.ShowList(ref a);
                            Console.WriteLine("------------------------------------------------------------------------");

                            break;
                        case "/search":
                            CommandHandler.SearchStudent(ref a);
                            break;
                        case "/length":
                            CommandHandler.Length(ref a);
                            break;
                        case "/sort":
                            CommandHandler.SortList(ref a);
                            CommandHandler.ShowList(ref a);
                            break;
                        default:
                            Console.WriteLine("Немає такої команди, введiть щє раз");
                            break;
                    }
                    command = Console.ReadLine();
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                } 
            }
            Console.ReadLine();   
        }
    }
}
