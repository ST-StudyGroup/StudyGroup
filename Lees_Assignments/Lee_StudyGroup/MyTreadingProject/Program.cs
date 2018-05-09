using System;
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
            Thread t = new Thread(() => Print("Hello from t!"));
            t.Start();

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
    }
}
