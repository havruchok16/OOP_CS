using System;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace CS_14
{
    class Program
    {
        //метод для вывода чисел
        public static void Numbers()
        {
            Console.WriteLine("Number: ");
            int length = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < length; i++)
            {
                if (i == 5)
                {
                    Console.WriteLine("\nName: " + Thread.CurrentThread.Name);
                    Console.WriteLine("Id: " + Thread.CurrentThread.ManagedThreadId);
                    Console.WriteLine("Priority: " + Thread.CurrentThread.Priority);
                    Console.WriteLine("Status: " + Thread.CurrentThread.ThreadState);
                }

                Thread.Sleep(500);//остановка проекта на 500 мс
                Console.Write(i + " ");
            }
        }
        public static void Even()//метод для четных чисел
        {
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(i + " ");
                }
                Thread.Sleep(300);
            }
        }
        public static void Odd()//метод для нечетных чисел
        {
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 != 0)
                {
                    Console.Write(i + " ");
                }
                Thread.Sleep(400);
            }
        }

        public static void PushNumber(object obj)
        {
            Random num = new Random();
            Console.WriteLine(num.Next());
        }

        static void Main(string[] args)
        {
            DateTime Time = DateTime.Now;

            Console.WriteLine("\tProcesses");
            
            //вывод информации о всех процессах
            var allProcess = Process.GetProcesses();
            foreach(var process in allProcess)
            {
                Console.WriteLine($"ID: {process.Id}  Name: {process.ProcessName} Priority: {process.BasePriority} VirtualMemorySize64: {process.VirtualMemorySize64}");
                try
                {
                    Console.WriteLine("Start time: " + process.StartTime);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            Console.WriteLine("\tDomaines");

            //исследование домена
            var domain = AppDomain.CurrentDomain;
            Console.WriteLine($"Name: {domain.FriendlyName}");
            Console.WriteLine($"Config datails: {domain.SetupInformation}");
            Console.WriteLine($"Base Directory: {domain.BaseDirectory}");
            Console.WriteLine("Assemblies: ");

            foreach (var ass in domain.GetAssemblies())
            {
                Console.WriteLine(ass);
            }

            //создание домена и загрузка
            var d = AppDomain.CreateDomain("Domain");
            d.Load(domain.GetAssemblies()[0].FullName);
            AppDomain.Unload(d);


            Console.WriteLine("\tThreads");

            //работа с потоками
            Thread thread = new Thread(Numbers)
            {
                Name = "myThread" //имя потока
            };
            thread.Start();//запуск
            thread.Join();//блокировка

            Thread thread1 = new Thread(Even);
            Thread thread2 = new Thread(Odd);
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            Console.WriteLine();

            Thread thread3 = new Thread(Even)
            {
                Priority = ThreadPriority.Highest
            };
            Thread thread4 = new Thread(Odd);
            thread3.Start();
            thread3.Join();
            thread4.Start();
            thread4.Join();
            Console.WriteLine();

            object obj = new object();
            //при нажатии на любую кнопку программа остановит свою работу
            Console.WriteLine("Press any button to stop");
            TimerCallback time = new TimerCallback(PushNumber);
            Timer timer = new Timer(time, 0, 0, 1000);
        }
    }

}
