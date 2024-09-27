using System;

namespace TestTask2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Начало");
            RunTests();
        }

        public static void RunTests()
        {
            Test1();
            Thread.Sleep(5000);
            Test2();
        }
        public static void Test1()
        {
            Console.WriteLine("Тест1");

            Thread thr1 = new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                    ReadValue(1);
            });

            // Потоки для параллельного чтения
            Thread thr2 = new Thread(() =>
            {
                Thread.Sleep(10);

                for (int i = 0; i < 10; i++)
                    ReadValue(2);

            });
            thr1.Start();
            thr2.Start();
        }
        public static void Test2()
        {
            Console.WriteLine("\n\n\nТест2");

            Thread thr1 = new Thread(() =>
            {
                for (int i = 0; i < 20; i++)
                    ReadValue(1);
            });

            // Потоки для параллельного чтения
            Thread thr2 = new Thread(() =>
            {
                Thread.Sleep(10);

                for (int i = 0; i < 20; i++)
                    WriteValue(2);

            });

            Thread thr3 = new Thread(() =>
            {
                Thread.Sleep(10);

                for (int i = 0; i < 20; i++)
                    WriteValue(3);
            });

            Thread thr4 = new Thread(() =>
            {
                Thread.Sleep(10);

                for (int i = 0; i < 20; i++)
                    WriteValue(3);
            });

            Thread thr5 = new Thread(() =>
            {
                Thread.Sleep(10);

                for (int i = 0; i < 20; i++)
                    WriteValue(3);
            });


            thr1.Start();
            thr2.Start();
            thr3.Start();
            thr4.Start();
            thr5.Start();
        }

        public static void WriteValue(int thr)
        {
            int c = Server.GetCount();
            //Console.WriteLine($"Финиш чтения потока {thr} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}, count {c}");
            Thread.Sleep(20);
        }

        public static void ReadValue(int thr)
        {
            var c = Server.AddToCount(new Random().Next(1, 1000));
            //Console.WriteLine($"Запись потока {thr} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}, count {c}");
        }
    }
}
