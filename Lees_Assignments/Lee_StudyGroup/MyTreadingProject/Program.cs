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
        #region :: Variables
        static bool done;

        static readonly object locker = new object();
        // public delegate void ThreadStart();

        //For Chapter Example 1.5
        //[ThreadStatic]
        //public static int _field;

        //For ChapterExample 1.6
        //public static ThreadLocal<int> __threadId =
        //    new ThreadLocal<int>(() =>
        //    {
        //        return Thread.CurrentThread.ManagedThreadId;
        //    });

        public static ThreadLocal<string> __threadName =
            new ThreadLocal<string>(() =>
            {
                return Thread.CurrentThread.Name;
            });
        public static ThreadLocal<ThreadPriority> __threadPriority =
            new ThreadLocal<ThreadPriority>(() =>
            {
                return Thread.CurrentThread.Priority;
            });

        public static ThreadLocal<int> _threadMillisecond =
            new ThreadLocal<int>(() =>
            {
                return DateTime.UtcNow.Millisecond;
            });

        public static ThreadLocal<ThreadState> _threadingState =
            new ThreadLocal<ThreadState>(() =>
            {
                return Thread.CurrentThread.ThreadState;
            });
        #endregion

        static void Main(string[] args)
        {
            #region :: Threading in C# E Book
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

            #endregion

            #region :: Chapter 1 Examples

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

            //bool stopped = false;

            //Thread t = new Thread(new ThreadStart(() =>
            //    {
            //        while (!stopped)
            //        {
            //            Console.WriteLine("Running...");
            //            Thread.Sleep(1000);
            //        }
            //    }));


            //t.Start();

            ////t.IsBackground = true;
            ////Demonstrate - as long as foreground thread is running, background will continue
            ////If you comment out the main thread below it should stop immediately (must comment out Join too)
            //Console.WriteLine("Press any key to exit...");
            //Console.ReadKey();

            //stopped = true;
            //t.Join();

            //Example 1.5 Using the Thread Static Attribute 
            //With the ThreadStaticAttribute applied, the maximum value of _field becomes 10. 
            //If you remove it, you can see that both threads access the same value and it becomes 20.

            //new Thread(() =>
            //{
            //    for (int x = 0; x < 10; x++)
            //    {
            //        _field++;
            //        Console.WriteLine($"Thread A: {_field}");
            //    }
            //}).Start();

            //new Thread(() =>
            //{
            //    for (int x = 0; x < 10; x++)
            //    {
            //        _field++;
            //        Console.WriteLine($"Thread B: {_field}");
            //    }
            //}).Start();

            //Example 1.6 Using Threading Local
            //new Thread(() =>
            //{
            //    for (int x = 0; x < __threadId.Value; x++)
            //    {
            //        Console.WriteLine($"Thread A Id: {__threadId} Count: {x}");
            //    }
            //}).Start();

            //new Thread(() =>
            //{
            //    for (int x = 0; x < __threadId.Value; x++)
            //    {
            //        Console.WriteLine($"Thread B Id: {__threadId} Count: {x}");
            //    }
            //}).Start();


            //Example 1.7 Using the TreadPool
            //ThreadPool.QueueUserWorkItem((s) =>
            //{
            //    Console.WriteLine("Working on thread pool");
            //});

            //Console.ReadLine();

            //Example 1.8 Starting a new task
            //Task t = Task.Run(() =>
            //    {
            //        for (int x = 0; x < 100; x++)
            //        {
            //            Console.Write('*');
            //            Thread.Sleep(100);
            //        }
            //    });

            //t.Wait();
            //Console.WriteLine("howdy");

            //Example 1.9 Using a task that returns a value
            //Task<int> task = Task.Run(() =>
            //{
            //    return 42;
            //});

            //Console.WriteLine(task.Result);

            //Example 1.10 Adding Continuation
            //Task<int> t2 = Task.Run(() =>
            //{
            //    return 42;
            //}).ContinueWith((i) =>
            //{
            //    return i.Result * 2;
            //});

            //Console.WriteLine(t2.Result);

            //Example 1.11 Scheduling Different Continuation Tasks
            //Task<int> t = Task.Run(() =>
            //{
            //    return 42;
            //});

            //t.ContinueWith((i) =>
            //{
            //    Console.WriteLine("Cancelled");
            //}, TaskContinuationOptions.OnlyOnCanceled);

            //t.ContinueWith((i) =>
            //{
            //    Console.WriteLine("Faulted");
            //}, TaskContinuationOptions.OnlyOnFaulted);

            //var completedTask = t.ContinueWith((i) =>
            //{
            //    Console.WriteLine("Completed");
            //}, TaskContinuationOptions.OnlyOnRanToCompletion);

            //completedTask.Wait();


            /*****************************************************************************/
            //Example 1.12 Attaching Child Tasks
            //Task<Int32[]> parent = Task.Run(() =>
            //{
            //    var results = new Int32[3];
            //    new Task(() => results[0] = 0,
            //        TaskCreationOptions.AttachedToParent).Start();
            //    new Task(() => results[1] = 1,
            //        TaskCreationOptions.AttachedToParent).Start();
            //    new Task(() => results[2] = 2,
            //        TaskCreationOptions.AttachedToParent).Start();

            //    return results;
            //});

            //var finalTask = parent.ContinueWith(
            //    parentTask =>
            //    {
            //        foreach (int i in parentTask.Result)
            //        {
            //            Console.WriteLine(i);
            //        }
            //    });

            //finalTask.Wait();

            /*****************************************************************************/

            //Example 1.13 TaskFactory

            //int arrayCount = 3;

            Task<Int32[]> parent = Task.Run(() =>
            {
                var results = new Int32[3];

                TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);

                tf.StartNew(() => results[0] = 0);
                tf.StartNew(() => results[1] = 1);
                tf.StartNew(() => results[2] = 2);

                
                //Why Doesn't this work?

                //for (int x = 0; x < 3; x++)
                //{
                //    tf.StartNew(() => results[x] = x);
                //}

                return results;

            });

            var finalTask = parent.ContinueWith(
                parentTask =>
                {
                    foreach (int i in parentTask.Result)
                    {
                        Console.WriteLine(i);
                    }
                });

            finalTask.Wait();



            /*****************************************************************************/
            //Create an array of tasks
            Task[] tasks = new Task[3];



            #endregion

            #region :: My Experiments

            //Experiment with Current Thread Properties - "Execution Context"
            //You can name them. 
            //new Thread(() =>
            //{
            //    Thread.CurrentThread.Name = "ThreadingMyEyebrows";
            //    Console.WriteLine($"Thread Name A {__threadName}");
            //    Console.WriteLine($"Thread Priority A {__threadPriority}, Thread State: {_threadingState}");
            //    Thread.Sleep(1000);
            //    Console.WriteLine($"Thread Millisecond A {_threadMillisecond}");

            //}).Start();

            ////Why does this line prevent the next thread from starting?
            ////Thread.CurrentThread.Join();

            //new Thread(() =>
            //{
            //    Thread.CurrentThread.Name = "ThreadingAndShreding";
            //    Console.WriteLine($"Thread Name B {__threadName}");
            //    Console.WriteLine($"Thread Prority B {__threadPriority}, Thread State: {_threadingState}");
            //    Console.WriteLine($"Thread Millisecond B {_threadMillisecond}");

            //}).Start();

            #endregion

        }

        #region Methods
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

        #endregion
    }
}


