using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAsyncThreading
{
    class Program
    {
        // You can think of parallel programming as a subset of asynchronous programming: 
        // every parallel execution is asynchronous, but not every asynchronous execution
        // is parallel.

        // -Phone call analogy-
        // Syncronous: Someone calls you and you answer leaving your current work.
        // Asynchronous: Someone emails you which gives you a chance to answer them back at 
        // another time not interupting your current work.
        // Parallel: Someone calls you and you continue to work while talking.

        // -Cook analogy-
        // The cooks time is more valuable than a toaster or stove or the assitant that is 
        // working with her/him.
        // It would be a waste of time if the cook would sit and wait for the toast to 
        // finish before starting other work making things far more efficient.
        // This is the same as if you set a thread to sleep while waiting for a task to 
        // finish.


        static void Main(string[] args)
        {
            StringBuilder a = new StringBuilder();

            object _lock = new object();

            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000; i++)
                    lock(_lock)
                    {
                        a.Append("a");
                    }
            });

            for (int i = 0; i < 1000; i++)
                lock (_lock)
                {
                    a.Append("b");
                }

            up.Wait();
            Console.Write(a);



            int n = 0;

            var up2 = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                    Interlocked.Increment(ref n);
            });
            Interlocked.Exchange
            for (int i = 0; i < 1000000; i++)
                Interlocked.Decrement(ref n);

            up2.Wait();
            Console.WriteLine(n);
        }
    }
}
