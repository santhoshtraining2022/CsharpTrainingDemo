using System;

namespace ThreadSimple
{
    using System;
    using System.Threading;

    class Test
    {
        static void Main()
        {



            //   Thread childThread1 = new Thread(DisplayFunction);
            //   childThread1.Start();

            // To start a thread using a static thread procedure, use the
            // class name and method name when you create the ThreadStart
            // delegate. Beginning in version 2.0 of the .NET Framework,
            // it is not necessary to create a delegate explicitly. 
            // Specify the name of the method in the Thread constructor, 
            // and the compiler selects the correct delegate. For example:
            //
            //   Thread newThread = new Thread(Work.DoWork);
            //
            //  ThreadStart threadDelegate = new ThreadStart(Work.DoWork);
            // Thread newThread = new Thread(threadDelegate);
            //   newThread.Start();

            // To start a thread using an instance method for the thread 
            // procedure, use the instance variable and method name when 
            // you create the ThreadStart delegate. Beginning in version
            // 2.0 of the .NET Framework, the explicit delegate is not
            // required.
            //
            //Work w = new Work();
            //w.Data = 42;
            //threadDelegate = new ThreadStart(w.DoMoreWork);
            //newThread = new Thread(threadDelegate);
            //newThread.Start();

            // MyClass myclass1 = new MyClass("Child1");
            //MyClass[] objMyClass = new MyClass[4];
            //objMyClass[0] = new MyClass("Child thread1");
            //objMyClass[1] = new MyClass("Child thread2");
            //objMyClass[2] = new MyClass("Child thread3"); 
            //objMyClass[3] = new MyClass("Child thread4");

            //foreach (MyClass obj in objMyClass)
            //{
            //    do
            //    {
            //        Thread.Sleep(1000);
            //        Console.WriteLine("\nLoop Iteration " + obj.count + "in Main Thread"); obj.count++;
            //    } while (obj.count < 10);

            //}

            MyThread objmythread1 = new MyThread("childtread1", new int[5] { 43, 5, 53, 53, 35 });

            Console.Read();
        }


        static void DisplayFunction()
        {

            Console.WriteLine("child thread1");
        }
    }

    class Work
    {
        public static void DoWork()
        {
            Console.WriteLine("Static thread procedure.");
        }
        public int Data;
        public void DoMoreWork()
        {
            Console.WriteLine("Instance thread procedure. Data={0}", Data);
        }
    }

    /* This code example produces the following output (the order 
       of the lines might vary):
    Static thread procedure.
    Instance thread procedure. Data=42
     */



    class MyClass
    {
        public int count; public Thread thrd;
        public MyClass(string name)
        {
            thrd = new Thread(this.run);
            thrd.Name = name;
            thrd.Start(); //starting the thread count = 0;
        }
        public void run()
        {
            Console.WriteLine(thrd.Name + " is started");

            do
            {
                Thread.Sleep(1000);
                Console.WriteLine("Loop Iteration " + count + "in" + thrd.Name);
                count++;
            } while (count < 10);

        }

    }


    class MyThread
    {
        public Thread thrd; 
        int[] a;
        int answer;
        //create a sum array object for all instances of MyThread
         static SumArray sa = new SumArray();

        public MyThread(string name, int[] nums)
        {
            a = nums;
            thrd = new Thread(this.run);
            thrd.Name = name;
            thrd.Start(); //calls run method()
        }
        public void run()
        {
            Console.WriteLine(thrd.Name + " is starting!!");

            answer = sa.sumIt(a);
            Console.WriteLine("sum is: " + answer);


           // Console.WriteLine("sum wil be called");

            Console.WriteLine(thrd.Name + " is completed!!");


        }
    }

    class SumArray
    {
        int sum;

        public int sumIt(int[] nums)
        {
              lock (this)
            {
            //Lock the entire method
            sum = 0; //reset sum

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                Console.WriteLine("Running total for " + Thread.CurrentThread.Name + " is " + sum); Thread.Sleep(1000);
            }
            return sum;
           }

        }
    }
}

