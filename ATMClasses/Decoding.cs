using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATMClasses
{

    public class Decoding : IDecoding
    {

        private ITransponderReceiver _receiver;
        public List<Update> _ftracks { get; set; }
        public event EventHandler<UpdateEvent> _updateCreated;

        public object _dictionaryUpdate { get; set; }
        
        public Decoding(ITransponderReceiver myReceiver)
        {
            _receiver = myReceiver;

            _receiver.TransponderDataReady += DataHandler; //datahandler will be added to an internal list that the event keeps track of (when the owning class fires that event, all the delegates in the list will be called)

        }


        public void DataHandler(object o, RawTransponderDataEventArgs eventArgs)
        {
            //List<string> recList = eventArgs.TransponderData;
            _ftracks = new List<Update>();
            //  foreach (var track in e.TransponderData)
            //foreach (var track in recList)
            //{
            //    Console.WriteLine(track);
            //}
            //onUpdateCreated(_ftracks);

            foreach (var track in eventArgs.TransponderData)
            {
                Split(track);   
            }
            onUpdateCreated(_ftracks);
        }

        public void Split(String track)
        {
            string[] transData = track.Split(';');

            DateTime dateTime = DateTime.ParseExact(transData[4], "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture);


            Update updateTrack = new Update(
                transData[0],
                Convert.ToDouble(transData[1]),
                Convert.ToDouble(transData[2]),
                Convert.ToDouble(transData[3]),
                dateTime
            );

            _ftracks.Add(updateTrack);

        }

        protected virtual void onUpdateCreated(List<Update> utrack)
        {
            _updateCreated?.Invoke(this, new UpdateEvent() { updatetracks = utrack });
        }
            
           
        public class UpdateEvent : EventArgs
        {
            public List<Update> updatetracks { get; set; }
        }

    }
}
