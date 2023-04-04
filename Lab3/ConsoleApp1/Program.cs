using System;
using System.IO;
using System.Net;
using System.Threading;
using Newtonsoft.Json;

internal class Program
{
    private static async Task Main(string[] args)
    {
        // Thread class methods
        // #1
        GetMenuInstructions();

        // #2
        // Create a new thread and start it
        Thread thread = new Thread(() => PerformTask("Hello, world!"));
        thread.Start();

        // Do some other work on the main thread
        Console.WriteLine("Doing some work on the main thread");

        // Wait for the other thread to finish
        thread.Join();

        // Output a message to indicate that the task has been completed
        Console.WriteLine("Task completed successfully");

        // #3
        ThreadPriorityCheck();

        // Async - await methods

        // #1

        Console.WriteLine("Starting the task...");
        int result = await PerformTaskAsync();
        Console.WriteLine("The result is: " + result);

        // #2
        await GetPosts();

        // #3

        Demo();
        Console.ReadLine();

    }

    public static void Demo()
    {
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();

        var task1 = StartSchoolAssembly();
        var task2 = TeachClass12();
        var task3 = TeachClass11();


        Task.WaitAll(task1, task2, task3);
        watch.Stop();
        Console.WriteLine($"Execution Time:{ watch.ElapsedMilliseconds} ms");
        }


    public static async Task StartSchoolAssembly()
    {
        await Task.Run(() =>
        {
            Thread.Sleep(8000);
            Console.WriteLine("School Started");
        });
    }


    public static async Task TeachClass12()
    {
        await Task.Run(() =>
        {
            Thread.Sleep(3000);
            Console.WriteLine("Taught class 12");
        });


    }

    public static async Task TeachClass11()
    {
        await Task.Run(() =>
        {
            Thread.Sleep(2000);
            Console.WriteLine("Taught class 11");
        });


    }

    static async Task GetPosts()
    {
        string url = "https://jsonplaceholder.typicode.com/posts/1";
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();
            Post post = JsonConvert.DeserializeObject<Post>(json);
            Console.WriteLine(post.Title);
        }
    }

    static async Task<int> PerformTaskAsync()
    {
        Console.WriteLine("Performing the task...");
        await Task.Delay(5000); // Simulate some work that takes 5 seconds
        Console.WriteLine("Task completed.");
        return 42;
    }



    public static void ThreadPriorityCheck()
    {

        // Creating and initializing threads
        Thread THR1 = new Thread(Work);
        Thread THR2 = new Thread(Work);
        Thread THR3 = new Thread(Work);

        // Set the priority of threads
        THR2.Priority = ThreadPriority.Lowest;
        THR3.Priority = ThreadPriority.AboveNormal;
        THR1.Start();
        THR2.Start();
        THR3.Start();

        // Display the priority of threads
        Console.WriteLine("The priority of Thread 1 is: {0}",
                                              THR1.Priority);

        Console.WriteLine("The priority of Thread 2 is: {0}",
                                              THR2.Priority);

        Console.WriteLine("The priority of Thread 3 is: {0}",
                                              THR3.Priority);
    }

    public static void Work()
    {

        // Sleep for 1 second
        Thread.Sleep(1000);
    }

    static void PerformTask(string message)
    {
        // Output a message to indicate that the task has started
        Console.WriteLine("Task started with message: " + message);

        // Do some work
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Working on task... (" + (i + 1) + "/10)");
            Thread.Sleep(1000);
        }

        // Output a message to indicate that the task has been completed
        Console.WriteLine("Task completed with message: " + message);
    }

    private static void GetMenuInstructions()
    {
        // Create an array of endpoint URLs
        string[] urls = new string[]
        {
            "https://jsonplaceholder.typicode.com/posts/1",
            "https://jsonplaceholder.typicode.com/posts/2",
            "https://jsonplaceholder.typicode.com/posts/3",
            "https://jsonplaceholder.typicode.com/posts/4",
            "https://jsonplaceholder.typicode.com/posts/5"
        };

        // Create a new thread for each URL and start making requests to the API in each thread
        Thread[] threads = new Thread[urls.Length];
        for (int i = 0; i < 4; i++)
        {
            threads[i] = new Thread(() => MakeRequest(urls[i]));
            threads[i].Start();
        }

        // Wait for all threads to finish
        for (int i = 0; i < 4; i++)
        {
            threads[i].Join();
        }

        Console.WriteLine("All requests have been completed successfully");
    }
    static void MakeRequest(string url)
    {
        Console.WriteLine("Making request to " + url);
        using (WebClient client = new WebClient())
        {
            string response = client.DownloadString(url);
            Console.WriteLine("Response from " + url + ": " + response);
        }
    }

    class Post
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}


   