﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class MainProgram
    {
        static List<int>[] crystal;

        static int ArrayLenght = 50;       
        static double Probability = 0.7;
        static int PartsAmount = 10;
        static int Iterations = 500;
        static int Seconds = 30;

        static void Main(string[] args)
        {
            Console.WriteLine("Choose mode: 1 - TimeMode, 2 - IterationMode");

            int mode = 0;

            do
            {
                var number = Console.ReadLine();

                int.TryParse(number, out mode);

            } while (mode != 1 && mode != 2);

            if (mode == 1)
            {
                TimeMode();
            }
            else
            {
                IterationMode();
            }
        }

        private static void IterationMode()
        {
            crystal = new List<int>[ArrayLenght];

            for (int i = 0; i < crystal.Length; i++)
            {
                crystal[i] = new List<int>();
            }

            Parallel.For(0, PartsAmount, (i, state) =>
            {
                var task = new Thread(() => MoveParticalIterationMode(i + 1));

                task.Start();
                task.Join();
            });
        }

        private static void TimeMode()
        {
            crystal = new List<int>[ArrayLenght];

            for (int i = 0; i < crystal.Length; i++)
            {
                crystal[i] = new List<int>();
            }

            Parallel.For(0, PartsAmount, (i, state) =>
            {
                var task = new Thread(() => MoveParticalTimeMode(i + 1));

                task.Start();
                task.Join();
            });
        }

        private static void MoveParticalTimeMode(int number)
        {
            int position = 0;
            var now = DateTime.Now;

            lock (crystal)
            {
                crystal[0].Add(number);
                WriteCrystal();
            }

            while (now.AddSeconds(Seconds) > DateTime.Now)
            {
                lock (crystal)
                {
                    if (Random.Shared.NextDouble() <= Probability)
                        position = MoveRight(position, number);
                    else
                        position = MoveLeft(position, number);

                    WriteCrystal();
                }
                Thread.Sleep(100);
            }
            
        }

        private static void MoveParticalIterationMode(int number)
        {
            int position = 0;
            var now = DateTime.Now;

            lock (crystal)
            {
                crystal[0].Add(number);
                WriteCrystal();
            }

            for (int i = 0; i < Iterations; i++)
            {
                lock (crystal)
                {
                    if (Random.Shared.NextDouble() <= Probability)
                        position = MoveRight(position, number);
                    else
                        position = MoveLeft(position, number);
                }
            }
            lock (crystal)
            {
                WriteCrystal();
            }
        }

        private static int MoveLeft(int position, int number)
        {
            if (position - 1 < 0)
            {
                return MoveRight(position, number);
            }

            crystal[position].Remove(number);
            crystal[--position].Add(number);
            return position;
        }

        private static int MoveRight(int position, int number)
        {
            if (position + 1 >= ArrayLenght)
            {
                return MoveLeft(position, number);
            }

            crystal[position].Remove(number);
            crystal[++position].Add(number);
            return position;
        }

        private static void WriteCrystal()
        {
            Console.Clear();

            Console.WriteLine(new string('-', ArrayLenght + PartsAmount * 4));
            Console.Write("|");
            foreach (var cell in crystal)
            {
                foreach (var item in cell)
                {
                    Console.Write($" {item} ");
                }
                Console.Write("|");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', ArrayLenght + PartsAmount * 4));
        }
    }
}
