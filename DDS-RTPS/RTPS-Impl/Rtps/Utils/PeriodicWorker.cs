using System;
using System.Threading;
using System.Threading.Tasks;

namespace Doopec.Rtps.Utils
{
    public class PeriodicWorker
    {
        // create the cancellation token source
        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        private bool isRunning = false;

        public int Period { get; set; }

        public int Count { get; set; }

        public void Start(int period)
        {
            this.Period = period;
            isRunning = true;
            KeepWorkerRunning();
        }

        public virtual void End()
        {
            isRunning = false;
            // cancel the token
            tokenSource.Cancel();
        }

        public bool IsRunning
        { get { return isRunning; } }

        public virtual void DoPeriodicWork()
        {
        }

        private void KeepWorkerRunning()
        {
            // create the cancellation token
            CancellationToken token = tokenSource.Token;

            // create the first task, which we will let run fully
            Task task = new Task(() =>
            {
                while (isRunning)
                {
                    // put the task to sleep for this.Period milliseconds
                    bool cancelled = token.WaitHandle.WaitOne(this.Period);
                    // Doing some periodic work
                    DoPeriodicWork();
                    Count++;
                    // check to see if we have been cancelled
                    if (cancelled)
                    {
                        throw new OperationCanceledException(token);
                    }
                }
            }, token);
            // start task
            task.Start();
        }
    }
}
