using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;

namespace TaskExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> t1 = Task.Run(() => genNum());
            Task<int> t2 = Task.Run(() => genNum());
            var t3 = Task<int>
            .Factory
            .ContinueWhenAll(new Task[] { t1, t2 }, result => sumNum(t1.Result, t2.Result));
            log("El resultado es: " + t3.Result);
        }

        public static void nameThread()
        {
            if (Thread.CurrentThread.Name == null)
            {
                var r = new Random();
                Thread.CurrentThread.Name = "Oneal-thread-" + r.Next();
            }
        }

        public static void log(string msg)
        {
            nameThread();
            Console.WriteLine(Thread.CurrentThread.Name + " - " + msg);
        }
        public static int genNum()
        {
            var r = new Random();
            var i = r.Next(100);
            log("Generating " + i);
            return i;
        }
        public static int sumNum(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}
