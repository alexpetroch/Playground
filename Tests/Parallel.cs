namespace Tests
{
    using NUnit.Framework;
    using Playground.Parallel;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    [TestFixture]
    [Category("Parallel")]
    class Parallel
    {
        private static int shared = 0;

        [Test]
        public static void ReaderWriterLock()
        {
            var rw = new SimpleReaderWriterLock();
            Task task1 = Task.Run(() => doStuff(rw, 240, false));
            Task task2 = Task.Run(() => doStuff(rw, 150, false));
            Task task3 = Task.Run(() => doStuff(rw, 200, true));
            Task task4 = Task.Run(() => doStuff(rw, 180, false));
            Task task5 = Task.Run(() => doStuff(rw, 80, false));
            Task task6 = Task.Run(() => doStuff(rw, 50, true));

            Task.WaitAll(task1, task2, task3, task4, task5, task6);
            Assert.That(shared == 200);
        }

        static void doStuff(SimpleReaderWriterLock rw, int sleep, bool write)
        {
            for (int i  = 0; i < 100; i++)
            {
                if(write)
                {
                    rw.EnterWriteLock();
                    shared++;
                }
                else
                {
                    rw.EnterReadLock();
                    int value = shared;
                }

                Thread.Sleep(sleep);

                if (write)
                {
                    rw.ExitWriteLock();
                }
                else
                {
                    rw.ExitReadLock();
                }
            }
        }
    }
}
