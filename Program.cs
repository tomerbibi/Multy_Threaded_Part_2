using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multy_Threaded_Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 25)

            // b)
            Task t1 = new Task(() =>
            {
                Thread.Sleep(10_000);
            }, TaskCreationOptions.LongRunning);

            // 26)
            // im not sure if i should have got those numbers from somewhere but i think that the point
            // here is that i return double
            Task<double> t2 = Task<double>.Factory.StartNew(() => 2 + 4);
            double result = t2.Result;

            // 27)

            // b)
            Task t4 = new Task(() =>
            {
                Console.WriteLine("Welcome");
            });
            Task t5 = t4.ContinueWith(g =>
            {
                Console.WriteLine("Goodbye");
            });
            t4.Start();
            t5.Wait();

            // 28)
            Task t6 = new Task(() =>
            {
                Console.WriteLine(DateTime.Now);
            });
            Task t7 = t6.ContinueWith(g =>
            {
                Console.WriteLine(DateTime.Now);
            }, TaskContinuationOptions.NotOnFaulted);
            t6.Start();
            t7.Wait();

            // 29)

            // b)
            var tasks = new List<Task>();
            for (int i = 0; i < 3; i++)
            {
                tasks.Add(Task.Run(() => Thread.Sleep(5000)));
            }
            Task.WaitAll(tasks.ToArray());
            while(!tasks[0].IsCompleted && !tasks[1].IsCompleted && !tasks[2].IsCompleted)
            {
                Thread.Sleep(100);
            }
            Console.WriteLine("all tasks are done");

            // 30)

            // b)
            Random r = new Random();
            var tasks2 = new List<Task>();
            for (int i = 0; i < 3; i++)
            {
                tasks2.Add(Task.Run(() => Thread.Sleep(r.Next(5000, 10_001))));
            }
            Task.WaitAny(tasks2.ToArray());
            Console.WriteLine("one task is done!");

        }
    }
}
