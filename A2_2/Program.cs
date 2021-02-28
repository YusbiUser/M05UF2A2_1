using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace A2_2
{
    class Program
    {
        //Decalration of staic out of method variables that i'll be using all along the program
        public static int w = 0, w1 = (Console.WindowWidth / 2) - 10, h = 0, h1 = Console.WindowHeight / 3;
        static string[] S = new string[4], S1 = new string[5], MenuS = { " Test 1: Historia ", " Test 2: Mates    ", " Test 3: Física   ", "       Exit       " };
        static string path = @"C:\Users\Usuario\source\repos\prove10\", folder, src, ans, ans1;

        //Main program
        static void Main()
        {
            //Using the menuselector to select the test you wanna do
            Menu(MenuSelector(MenuS));

            //Based on the info given by these two methods it'll grab the source folder and texts to make the respective test using the streamreader
            src = path + folder + "ans.txt";
            StreamReader sr;
            sr = new StreamReader(src);
            for (int i = 0; i < S.Length; i++) S[i] = sr.ReadLine();
            sr.Close();
            src = path + folder + "q.txt";
            sr = new StreamReader(src);
            for (int i = 0; i < S1.Length; i++) S1[i] = sr.ReadLine();
            sr.Close();
            src = path + folder + "ans1.txt";
            sr = new StreamReader(src);
            ans1 = sr.ReadLine();
            sr.Close();

            //Here it'll show a the possible answers to the questions that'll be put on the title of the console
            for (int i = 0; i < S1.Length; i++)
            {
                Console.Title = S1[i];
                Test(TestSelector(S));
            }

            //Finally it'll show your punctuation and after 5 seconds it'll go back to the main menu
            Outcome(ans, ans1);
        }

        //This code is made not to repeat the same lines in the selector methods
        static void Code1(int w, int h, int i)
        {
            Console.SetCursorPosition(w, h + i);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        //This method will show the punctuation of the test for 5 seconds, also it'll calculate how many right guesses you've made
        static void Outcome(string ans, string ans1)
        {
            int n = 0;
            for (int i = 0; i < ans1.Length; i++) if (ans[i] == ans1[i]) n++;
            Console.WriteLine("{0}/5", n);
            Thread.Sleep(4000);
            Console.Clear();
            Main();
        }

        //Selector Methods

        //This methods will show a selectable options whether it's the test with it's four options or the main menu to select the type of test you wanna try 
        static int TestSelector(string[] S)
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.CursorVisible = false;

            for (int i = 0; i < S.Length; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine(S[i]);
            }
            Console.WriteLine();

            int j = 0;

            var k = Console.ReadKey();

            while (k.Key != ConsoleKey.Enter)
            {
                //If the up or down key is pressed it will grow or lower the value of j in order to know what option is being selected, while the number increases or decreases the option will be higlighted while the others won't
                switch (k.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (j == S.Length - 1) j = 0;
                        else if (j >= 0 && j < S.Length) j++;
                        for (int i = 0; i < S.Length; i++)
                        {
                            Console.SetCursorPosition(0, i);
                            Console.WriteLine(S[i]);
                        }
                        Code1(0, 0, j);
                        Console.WriteLine(S[j]);
                        k = Console.ReadKey();
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        break;
                    case ConsoleKey.UpArrow:
                        if (j > 0 && j < S.Length) j--;
                        else if (j == 0) j = S.Length - 1;
                        for (int i = 0; i < S.Length; i++)
                        {
                            Console.SetCursorPosition(0, i);
                            Console.WriteLine(S[i]);
                        }
                        Code1(0, 0, j);
                        Console.WriteLine(S[j]);
                        k = Console.ReadKey();
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        break;
                }
            }
            return j;
        }

        static int MenuSelector(string[] S)
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.CursorVisible = false;

            for (int i = 0; i < S.Length; i++)
            {
                Console.SetCursorPosition(w1, h1 + i);
                Console.WriteLine(S[i]);
            }
            Console.WriteLine();

            int j = 0;

            var k = Console.ReadKey();

            while (k.Key != ConsoleKey.Enter)
            {
                //If the up or down key is pressed it will grow or lower the value of j in order to know what option is being selected, while the number increases or decreases the option will be higlighted while the others won't
                switch (k.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (j == S.Length - 1) j = 0;
                        else if (j >= 0 && j < S.Length) j++;
                        for (int i = 0; i < S.Length; i++)
                        {
                            Console.SetCursorPosition(w1, h1 + i);
                            Console.WriteLine(S[i]);
                        }
                        Code1(w1, h1, j);
                        Console.WriteLine(S[j]);
                        k = Console.ReadKey();
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        break;
                    case ConsoleKey.UpArrow:
                        if (j > 0 && j < S.Length) j--;
                        else if (j == 0) j = S.Length - 1;
                        for (int i = 0; i < S.Length; i++)
                        {
                            Console.SetCursorPosition(w1, h1 + i);
                            Console.WriteLine(S[i]);
                        }
                        Code1(w1, h1, j);
                        Console.WriteLine(S[j]);
                        k = Console.ReadKey();
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        break;
                }
            }
            return j;
        }

        //Info methods

        //This methods will give info to select a option on the menu or the test
        static void Test(int j)
        {
            switch (j)
            {
                //This switch will add the characters to compare later the correct answers in a string
                case 0:
                    ans += 'a';
                    break;
                case 1:
                    ans += 'b';
                    break;
                case 2:
                    ans += 'c';
                    break;
                case 3:
                    ans += 'd';
                    break;
            }
        }

        static void Menu(int j)
        {
            //This switch will change the variable folder to select the folder of the test selected
            switch (j)
            {
                case 0:
                    folder = @"Test1\";
                    break;
                case 1:
                    folder = @"Test2\";
                    break;
                case 2:
                    folder = @"Test3\";
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
