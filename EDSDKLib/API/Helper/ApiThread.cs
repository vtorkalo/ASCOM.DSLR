using EOSDigital.SDK;
using System.Threading;

namespace EOSDigital.API
{
    internal sealed class ApiThread : STAThread
    {
        protected override void WaitForNotification()
        {
            lock (threadLock1)
            {
                while (block1 && IsRunning)
                {
                    Monitor.Wait(threadLock1, 0);
                    lock (ExecLock)
                    {
                        CanonSDK.EdsGetEvent();
                        Monitor.Wait(ExecLock, 40);
                    }
                }
                block1 = true;
            }
        }
    }
}
