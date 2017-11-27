using System.Diagnostics;
using System.Threading;

namespace Playground.Parallel
{
    public class SimpleReaderWriterLock
    {
        private static readonly object _globalLock = new object();
        private static readonly object _readerLock = new object();
        private int _readerCount = 0;

        public void EnterReadLock()
        {
            lock(_readerLock)
            {
                _readerCount++;
                if(_readerCount == 1)
                {
                    Monitor.Enter(_globalLock);
                }
            }
        }

        public void ExitReadLock()
        {
            lock (_readerLock)
            {
                _readerCount--;
                if (_readerCount == 0)
                {
                    Debug.Assert(Monitor.IsEntered(_globalLock) == true);
                    Monitor.Exit(_globalLock);
                }
            }
        }

        public void EnterWriteLock()
        {
            Monitor.Enter(_globalLock);
        }

        public void ExitWriteLock()
        {
            Monitor.Exit(_globalLock);
        }
    }
}
