using My_IO;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace OOP_LAB_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleMenu.Info();
        path:
            Console.Write("Enter path to file where you want to write:");
            string path = Console.ReadLine();
            Regex regex = new Regex(@"\.txt$");

            if (regex.IsMatch(path))
            {
                IO my = new IO();
                if (!File.Exists(path))
                    my = new IO(path);

                my.Path = path;
                string input;
                do
                {
                    Console.Write("\nEnter the command:");
                    input = Console.ReadLine();
                    Console.WriteLine();
                    try
                    {
                        switch (input.ToLower())
                        {
                            case "/info":
                                ConsoleMenu.Info();
                                break;
                            case "/persons":
                                ConsoleMenu.Persons();
                                break;
                            case "/add":
                                ConsoleMenu.AddPersonToFile(my);
                                break;
                            case "/show":
                                ConsoleMenu.Show(my);
                                break;
                            case "/search":
                                ConsoleMenu.Search(my);
                                break;
                            case "/sleepvertical":
                                ConsoleMenu.SleepVertical(my);
                                break;
                            case "/study":
                                ConsoleMenu.Study(my);
                                break;
                            case "/getfiles":
                                ConsoleMenu.ShowAllFiles();
                                break;
                            case "/delete":
                                ConsoleMenu.Delete(my);
                                break;
                            case "/clear":
                                ConsoleMenu.ClearFile(my);
                                break;
                            case "/cls":
                                Console.Clear();
                                break;
                            case "/path":
                                goto path;
                            case "/end":
                                break;
                            default:
                                Console.WriteLine("Ther is no such a command");
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                } while (input.ToLower() != "/end");
            }
            else
            {
                Console.WriteLine("Wrong file path! Try enter again.");
                goto path;
            }
        }
    }
}
