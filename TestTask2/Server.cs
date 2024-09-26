using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask2
{
    public static class Server
    {

        private static volatile int count;
        private static ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

        public static int GetCount()
        {
            _lock.EnterReadLock();
            Console.WriteLine($"Начало чтения переменной {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}, count {count}"); // не произойдет пока происходит запись переменной
            /*
              Можно увидеть что чтение потоков происходит одновременно до миллисекунд
            */
            try
            {
                return count;
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public static int AddToCount(int value)
        {
            _lock.EnterWriteLock();
            Console.WriteLine($"  Начало записи потока {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}, count: {value + count}");
            try
            {
                count += value;
                return count;
            }
            finally
            {
                Thread.Sleep(200);
                Console.WriteLine($"  Конец  записи потока {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}, count: {count}");
                _lock.ExitWriteLock();
            }
        }
    }
}
