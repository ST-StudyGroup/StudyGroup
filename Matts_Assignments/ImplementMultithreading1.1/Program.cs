using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public static Task SleepAsyncA(int millisecondsTimeout)
        {
            return Task.Run(() => Thread.Sleep(millisecondsTimeout));
        }

        public static Task SleepAsyncB(int millisecondsTimeout)
        {
            TaskCompletionSource<bool> tcs = null;
            var t = new Timer(delegate { tcs.TrySetResult(true); }, null, -1, -1);
            tcs = new TaskCompletionSource<bool>(t);
            t.Change(millisecondsTimeout, -1);
            return tcs.Task;
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

            Task<Int32[]> parent = Task.Run(() =>
            {
                var results = new Int32[3];
                new Task(() => results[0] = 0,
                TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = 1,
                TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = 2,
                TaskCreationOptions.AttachedToParent).Start();
                return results;
            });

            var numbers = Enumerable.Range(0, 10);

            var parallelResult = numbers.AsParallel()
            .Where(i => i % 2 == 0)
            .ToArray();

            foreach (int i in parallelResult)
                Console.WriteLine(i);
        }
    }
}
