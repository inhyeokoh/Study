using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    class Program
    {
        static int number = 1;
        static object _obj = new object();

        static void Thread1()
        {
            for (int i = 0; i < 50000; i++)
            {
                lock (_obj)
                {
                    number++;
                }
            }
        }

        static void Thread2()
        {
            for (int i = 0; i < 50000; i++)
            {
                lock (_obj)
                {
                    number--;
                }
            }
        }

        static void Main(string[] args)
        {
            Task t1 = new Task(Thread1);
            Task t2 = new Task(Thread2);
            t1.Start();
            t2.Start();

            Console.WriteLine(number);
        }
    }
}
