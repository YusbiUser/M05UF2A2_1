﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2_2
{
    class Program
    {
        public static int w = 0, w1 = (Console.WindowWidth / 2) - 10, h = 0, h1 = Console.WindowHeight / 3;
        static string[] S = new string[4], S1 = new string[5], MenuS = { " Test 1: Historia ", " Test 2: Mates    ", " Test 3: Física   ", "       Exit       " };
        static string path = @"C:\Users\Usuario\source\repos\prove10\", folder, src, ans, ans1;

        static void Main(string[] args)
        {
            static void Main()
            {
                Menu(MenuSelector(MenuS));

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
                for (int i = 0; i < S1.Length; i++)
                {
                    Console.Title = S1[i];
                    Test(TestSelector(S));
                }
                Outcome(ans, ans1);
            }
        }
    }
}