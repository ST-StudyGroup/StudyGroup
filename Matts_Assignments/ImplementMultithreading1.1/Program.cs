using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImplementMultithreading1._1
{
    class Program
    {
        public static void ThreadMethod1000(object o)
        {
            for (int i = 0; i <= (int)o; i++)
            {
                Console.WriteLine($"Threading Proc at 1000ms: { i}");
                Thread.Sleep(1000);
            }
        }

        public static void ThreadMethod2000()
        {
            for (int i = 0; i <= 3; i++)
            {
                Console.WriteLine($"Other Proc at 2000ms { i}");
                Thread.Sleep(2000);
            }
        }

        public static void Main(string[] args)
        {
            var stopped = false;
            Thread t1 = new Thread(new ParameterizedThreadStart(ThreadMethod1000));
            Thread t2 = new Thread(new ThreadStart(ThreadMethod2000));
            Thread t3 = new Thread(new ThreadStart(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine("Running...");
                    Thread.Sleep(3000);
                }
            }));

            Task task = Task.Run(() =>
            {
                for (var i = 100; i >= 0; i--)
                {
                    Console.WriteLine("Something neat");
                }
            });

            Task<int> task2 = Task.Run(() =>
            {
                return 42;
            });

            task2.ContinueWith((i) =>
            {
                Console.WriteLine("Canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);

            task2.ContinueWith((i) =>
            {
                Console.WriteLine("Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);

            var completedTask = task2.ContinueWith((i) =>
            {
                Console.WriteLine("Completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            completedTask.Wait();

            Console.WriteLine(task2.Result);
        }
    }
}
