using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcodeCSharp.Helpers
{
    public class Measurement
    {
        public static IDisposable Run(
            Action<long> afterMeasuredAction = null) =>
                new Timer(afterMeasuredAction);

        private class Timer : IDisposable
        {
            private readonly Action<long> _afterMeasuredAction;
            private readonly Stopwatch _stopwatch;

            public Timer(Action<long> afterMeasuredAction)
            {
                _afterMeasuredAction = afterMeasuredAction ?? (_ => { });
                _stopwatch = Stopwatch.StartNew();
            }

            public void Dispose()
            {
                _stopwatch.Stop();
                _afterMeasuredAction.Invoke(_stopwatch.ElapsedTicks);
            }
        }
    }

}
