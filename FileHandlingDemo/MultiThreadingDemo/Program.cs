using System;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
namespace MultiThreadingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread starting.....");

            Thread thread = Thread.CurrentThread;

            Console.WriteLine(thread.ThreadState);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);

                Thread.Sleep(2000);
            }

            ThreadStart ts = new ThreadStart(DisplayNumber);

            Thread ChildThread = new Thread(ts);

            ChildThread.Start();


            Console.WriteLine("Main thread ends");
        }

        static void DisplayNumber()
        {
            Console.WriteLine("Child thread starts");

            for (char c='A'; c <= 'G' ; c++)
            {
                Console.WriteLine(c);

                Thread.Sleep(1000);
            }

            Console.WriteLine("Child thread ends");
        }
    }
}
