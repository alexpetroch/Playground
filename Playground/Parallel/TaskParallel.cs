using System.Threading;
using System.Threading.Tasks;

namespace Playground.Parallel
{
    public class TaskParallel
    {

        public void Run()
        {
            string test = DoWork().Result;


            Task<int> success = DoWork().ContinueWith(t =>
            {
                string taskResult = t.Result + "hello";
                Thread.Sleep(5000);
                return 10;
            }, TaskContinuationOptions.NotOnFaulted);
        }

        private Task<string> DoWork()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(10000);
                return "Done with work!";
            });
        }
    }
}
