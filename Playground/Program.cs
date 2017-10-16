using Playground.Parallel;
using System;
using System.Collections.Generic;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Read();

            LinkedList<int> list = new LinkedList<int>();
            
        }

        static void Parallel()
        {
            TaskParallel t = new TaskParallel();
            t.Run();
        }
    }
}
