using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATMClasses
{
    public class TransponderReceiver
    {
        public class RawTransponderDataEventArgs : EventArgs
        {
            public List<string> TransponderData;
            public RawTransponderDataEventArgs(List<string> transponderData)
            {
                TransponderData = transponderData;
            }
        }
        public interface ITransponderReceiver
        {
            event EventHandler<RawTransponderDataEventArgs> TransponderDataReady;
        }
        public class TransponderReceiverFactory
        {
            public static ITransponderReceiver CreateTransponderDataReceiver { get; }
        }
    }

    
}
