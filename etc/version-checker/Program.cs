using System;
using System.IO;
using System.Net;

// RealFX's Updater, made in C#,
// You are allowed to edit this program,
// but you have to give credit to use it.
// (C) RealFX, 2021

namespace VersionChecker
{
    public class strings
    {
        public static string UrlToGetUpdateFrom = "https://raw.githubusercontent.com/RealFX-Code/RealFX-Code.github.io/main/etc/version-checker/version.dat";
        public static readonly string SavePath = Path.GetTempPath();
        public static readonly string SaveFile = @"Version.tmp";
        public static string fullpath = SavePath + SaveFile;
        public int FileExists = -1;
        public int yesno = 0;
        public static int yesno2 = 0;
        public int currentver = 106;
        public static string newver = "Undefined";
        public static int fixednewver = 2222;
    }
    public class Program
    {
        public static void PrintMenu(int currentversion, int newver, strings dd)
        {
            strings strings1 = new strings();
            if (strings.UrlToGetUpdateFrom == null)
            {
                Console.WriteLine("An Error Occured While Getting String Contents From UrlToGetUpdateFrom.");
                Console.ReadKey();
                System.Environment.Exit(-1);
            }
            else
            {
                
            }

            Console.WriteLine($"Welcome To RealFX's Updater, \t\t\t\t\t\t\t\t\t  Current Version, {dd.currentver}");
            Console.WriteLine("This app will check for updates from the URL below,");
            Console.WriteLine(strings.UrlToGetUpdateFrom);
            Console.WriteLine("Would you like to check for updates? (0 = no | 1 = yes)");
            try
            {
                dd.yesno = Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception e)
            {
                if (e == e)
                {
                    Console.WriteLine("\nInvalid Characted Entered!!");
                    Console.WriteLine("Exiting...");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"\n\n {e}");
                    Console.ReadKey();
                    System.Environment.Exit(-2);
                }
                else
                {
                    Console.WriteLine("Critical Error, Exiting!");
                    Console.ReadKey();
                    System.Environment.Exit(202);
                }
            }
            
        }

        static void printLine()
        {
            // prints 120 "-"'s, makes 1 line of "-"''s in the terminal
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
        }

        static void checkversion()
        {
            strings dd = new strings();
            WebClient wc = new WebClient();
            try
            {
                // Check if file exists with its full path    
                if (File.Exists(Path.Combine(strings.SavePath, strings.SaveFile)))
                {
                    // If file found, delete it    
                    File.Delete(Path.Combine(strings.SavePath, strings.SaveFile));
                    dd.FileExists = 1;
                }
                else dd.FileExists = 0;
            }
            catch (IOException ioExp)
            {
                dd.FileExists = 1;
            }
            wc.DownloadFile(strings.UrlToGetUpdateFrom, strings.fullpath);
            strings.newver = System.IO.File.ReadAllText(strings.fullpath);
            strings.fixednewver = Convert.ToInt32(strings.newver.Replace(".", String.Empty));
            if (strings.fixednewver > dd.currentver)
            {
                Console.WriteLine($"Update Available!, Update? (1 = Yes | 0 = no) \t\t\t\t\t\t\t  New Version, {strings.fixednewver}");
                try
                {
                    strings.yesno2 = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    if (e == e)
                    {
                        Console.WriteLine("\nInvalid Characted Entered!!");
                        Console.WriteLine("Exiting...");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine($"\n\n {e}");
                        Console.ReadKey();
                        System.Environment.Exit(-2);
                    }
                    else
                    {
                        Console.WriteLine("Critical Error, Exiting!");
                        Console.ReadKey();
                        System.Environment.Exit(202);
                    }
                }
            }
            else
            {
                Console.WriteLine("No New Updates Available!");
                Console.WriteLine("Press Any Key To Exit...");
                Console.ReadKey();
                System.Environment.Exit(1);
            }
        }

        static void Main(string[] args)
        {
            strings dd = new strings();
            Console.Title = $"RealFX (C) Updater, Your Current Version is {dd.currentver}";
            printLine();
            PrintMenu(106, 123, dd);
            if (dd.yesno == 1)
            {
                printLine();
                checkversion();
            }
            else
            {
                printLine();
                Console.WriteLine("\nUpdate Cancelled!");
                Console.WriteLine("Exiting Updated...");
                Console.ReadKey();
                System.Environment.Exit(1);
            }
            if (strings.yesno2 == 1)
            {
                printLine();
                Console.WriteLine("You Choose Yes...");
                Console.ReadKey();
                System.Environment.Exit(202);
            }
            else
            {
                printLine();
                Console.WriteLine("\nUpdate Cancelled!");
                Console.WriteLine("Exiting Updated...");
                Console.ReadKey();
                System.Environment.Exit(1);
            }
        }
    }
}

// Hello