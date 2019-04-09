
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ATMClasses;
using TransponderReceiver;




namespace AirTrafficGruppe5Application
{
    public class Program
    {
       

        static void Main(string[] args)
            {
                var tr = TransponderReceiverFactory.CreateTransponderDataReceiver();
                var decoding = new Decoding(tr);

                while (true) Thread.Sleep(1000);
            }
        
    }
}
