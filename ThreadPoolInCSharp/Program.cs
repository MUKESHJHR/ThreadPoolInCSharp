using System.Diagnostics;

namespace ThreadPoolInCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Example - 1 (Complete Example Code to Understand Thread Pooling in C#)
            //for (int i = 0; i < 10; i++)
            //{
            //    ThreadPool.QueueUserWorkItem(new WaitCallback(MyMethod));
            //}
            #endregion

            #region Example - 2 (Performance testing using and without using Thread Pool in C# )
            //Warmup code start
            for (int i = 0; i < 10; i++)
            {
                MethodWithThread();
                MethodWithThreadPool();
            }

            //Warmup code start
            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine("Executing using thread.");
            stopwatch.Start();
            MethodWithThread();
            stopwatch.Stop();
            Console.WriteLine($"Time consumed by MethodWithThread is : {stopwatch.ElapsedTicks.ToString()}");

            stopwatch.Reset();

            Console.WriteLine("Executing using Thread Pool.");
            stopwatch.Start();
            MethodWithThreadPool();
            stopwatch.Stop();
            Console.WriteLine($"Time consumed by MethodWithThreadPool is : {stopwatch.ElapsedTicks.ToString()}");

            #endregion

            Console.ReadKey();
        }

        #region Example - 1 (Complete Example Code to Understand Thread Pooling in C#)
        //public static void MyMethod(object obj)
        //{
        //    Thread thread = Thread.CurrentThread;
        //    string message = $"Background : {thread.IsBackground}, Thread Pool : {thread.IsThreadPoolThread}, Thread ID : {thread.ManagedThreadId}";
        //    Console.WriteLine(message);
        //}
        #endregion

        #region Example - 2 (Performance testing using and without using Thread Pool in C# )
        public static void MethodWithThread()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(Test);
                thread.Start();
            }
        }
        public static void MethodWithThreadPool()
        {
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(Test));
            }
        }
        public static void Test(object obj)
        {
        }
        #endregion
    }
}