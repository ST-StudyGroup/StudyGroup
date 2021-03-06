﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyTreadingProject
{
    class ThreadTest
    {
        static bool done;

        static readonly object locker = new object();
        // public delegate void ThreadStart();

        static void Main(string[] args)
        {
            //Thread t = new Thread(WriteY);
            //t.Start();

            //for (int i = 0; i < 1000; i++) Console.Write("x");
            // ThreadTest t = new ThreadTest();


            //#2 Test Timeout
            //Increase the timeout argument and see the result
            //Thread t = new Thread(Go2);
            //t.Start();
            //bool timeout = t.Join(2);
            //Console.WriteLine($"Thread completed: {timeout}");

            //#3 Test delegate
            //Thread t = new Thread(new ThreadStart(GoHello));
            //t.Start();
            //GoHello();

            //#4 lambda expression
            //Thread t = new Thread(() => Console.WriteLine("Hello!"));
            //t.Start();

            //#5 lambda expression calling another method
            //Thread t = new Thread(() => Print("Hello from t!"));
            //t.Start();

            //#6 This can cause issues, memory is changing as thread is being called
            //for (int i = 0; i < 10; i++)
            //    new Thread(() => Console.Write(i)).Start();

            //#7 Compare to results of #6
            //for (int i = 0; i < 10; i++)
            //{
            //    int temp = i;
            //    new Thread(() => Console.Write(temp)).Start();
            //}

            //****************************Chapter 1 Examples*********************************//

            //Example 1.1
            //Thread t = new Thread(c => ThreadMethod(0));
            //t.Start();

            ////t.Join(); //Uncomment to show how Join induces await

            //for (int i = 0; i < 4; i++)
            //{
            //    Console.WriteLine("Mainthread: Do somework.");
            //    Thread.Sleep(0);
            //}
            ////t.Join();

            //Example 1.2

            //Thread t = new Thread(c => ThreadMethod(1000));
            //t.IsBackground = true;
            //t.Start();

            //Example 1.3
            //Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));
            //t.Start(600); t.Join(); 

            //Example 1.4 Stopping a Thread

            bool stopped = false;

            Thread t = new Thread(new ThreadStart(() =>
                {
                    while (!stopped)
                    {
                        Console.WriteLine("Running...");
                        Thread.Sleep(1000);
                    }
                }));

           
            t.Start();

            //t.IsBackground = true;
            //Demonstrate - as long as foreground thread is running, background will continue
            //If you comment out the main thread below it should stop immediately (must comment out Join too)
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

            stopped = true;
            t.Join();

        }

        private static void Print(string message)
        {
            Console.WriteLine(message);
        }

        static void WriteY()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("y");
            }

        }
        static void Go()
        {
            // Declare and use a local variable - 'cycles'
            lock (locker)
            {
                if (!done) { Console.WriteLine("Done"); done = true; }
            }

        }
        static void Go2()
        {
            for (int i = 0; i < 1000; i++) Console.Write("y");
        }

        static void GoHello()
        {
            Console.WriteLine("Hello!");
        }


        public static void ThreadMethod(int sleep)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"ThreadProc:{i}");
                Thread.Sleep(sleep);
            }
        }

        public static void ThreadMethod(object o)
        {
            int sleep = (int)o;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"ThreadProc:{i}");
                Thread.Sleep(sleep);
            }
        }
    }
}

