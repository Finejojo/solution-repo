using System;
using System.Threading;
class LockExample1
{
    //Creating a normal Method to Display Names
    
    public void Display()
    {
        //Lock is used to lock-in the Current Thread
        /*
        lock (this)
        {
            for (int i = 0; i <= 3; i++)
            {
                Thread.Sleep(3000);
                Console.WriteLine("My Name is Abhishek{0}",i);
            }
        }
        */
        for (int i = 0; i <= 3; i++)
        {
            Thread.Sleep(3000);
            Console.WriteLine("My Name is Abhishek{0}", i);
        }
    }
}
class Program
{
    private const string URL = "https://www.c-sharpcorner.com/";
    public static void DoingSynchronous()
    {
        Console.WriteLine("Writing a program");
    }

    static async Task MultipleTasksAsync()
    {
        Console.WriteLine("Doing Multiple tasks at a time ");
        await GetURLAsync();
    }

    static async Task GetURLAsync()
    {
        using (var httpClient = new HttpClient())
        {
            Console.WriteLine("Waiting for GetURLAsync to happen");
            string output = await httpClient.GetStringAsync(URL);
            Console.WriteLine($"\n OK! awaiting has finished \n The length of {URL} is {output.Length} characters");
        }
    }
    static void DoingSynchronousAfterAwait()
    {
        Console.WriteLine("Mean While I'm doing some other work");
        for (var i = 0; i <= 3; i++)
        {
            Console.Write("I'm Updating the Weather Info \t");
        }

    }


    static void WorkerThread()
    {
        Console.WriteLine("2. WorkerThread Started");
        for (int i = 0; i <= 3; i++)
        {
            Console.WriteLine("-> WorkerThread Executing");
            Console.WriteLine("Child Thread Paused");
            //Sleep method is used to pause the Thread for a specific period    
            Thread.Sleep(3000);
            Console.WriteLine("Child Thread Resumed");
        }
    }
    public static void Main()
    {
        DoingSynchronous();
        var MultiTask = MultipleTasksAsync();
        DoingSynchronousAfterAwait();
        MultiTask.Wait();
        Console.ReadLine();
        /*
        //Creating object for LockExample1 Class as _locker so that we can access its Display Method    
        LockExample1 _locker = new LockExample1();
        Console.WriteLine("Threading with the help of Lock");
        //Calling the Display Method using ThreadStart Delegate which is supplied to Thread constructor.    
        Thread t1 = new Thread(new ThreadStart(_locker.Display));
        Thread t2 = new Thread(new ThreadStart(_locker.Display));
        t1.Start(); //Starting Thread1    
        t2.Start(); //Starting Thread2 
        */
        /*
        //Creating the WorkerThread with the help of Thread class.    
        Thread ThreadObject1 = new Thread(WorkerThread);
        ThreadObject1.Start(); //Starting the Thread    
        //ThreadObject1.Join(); //Using Join to block the current Thread    
        Console.WriteLine("1. MainThread Started");
        for (int i = 0; i <= 3; i++)
        {
            Console.WriteLine("-> MainThread Executing");
            Thread.Sleep(3000); //Here 5000 is 5000 Milli Seconds means 5 Seconds    
        }
        // We are calling the Name of Current running Thread using CurrentThread    
        Thread Th = Thread.CurrentThread;
        Th.Name = "Main Thread";
        Console.WriteLine("\nGetting the Name of Currently running Thread");
        //Name Property is used to get the name of the current Thread    
        Console.WriteLine("Current Thread Name is: {0}", Th.Name);
        //Priority Property is used to display the Priority of current Thread    
        Console.WriteLine("Current Thread Priority is: {0}", Th.Priority);
        */
        /*
        Thread ThreadObject1 = new Thread(Example1); //Creating the Thread    
        Thread ThreadObject2 = new Thread(Example2);
        ThreadObject1.Start(); //Starting the Thread    
        ThreadObject2.Start();
        */
    }
    static void Example1()
    {
        Console.WriteLine("Thread1 Started");
        for (int i = 0; i <= 5; i++)
        {
            Console.WriteLine("Thread1 Executing");
            Thread.Sleep(5000); //Sleep is used to pause a thread and 5000 is MilliSeconds that means 5 Seconds    
        }
    }
    static void Example2()
    {
        Console.WriteLine("Thread2 Started");
        for (int i = 0; i <= 5; i++)
        {
            Console.WriteLine("Thread2 Executing");
            Thread.Sleep(5000);
        }
    }
}