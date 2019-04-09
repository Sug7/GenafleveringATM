using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATMClasses
{
    public class Update
    {
        //Attributter

        public string _tag { get; set; }
        public double _xcoordinate { get; set; }
        public double _ycoordinate { get; set; }
        public double _altitude { get; set; }
        public DateTime _date { get; set; }
        public bool InAirspace { get; set; }

        //Constructor
        public Update(string tag, double X, double Y, double altitude, DateTime date)
        {
            this._tag = tag;
            this._date = date;
            this._xcoordinate = X;
            this._ycoordinate = Y;
            this._altitude = altitude;
        }

        //Metode
        
    }

}
