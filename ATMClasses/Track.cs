using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMClasses
{
    public class Track : ITrack
    {
        public double direction_ { get; set; }
        public DateTime _date { get; set; }
        public double _xcoordinate { get; set; }
        public double _ycoordinate { get; set; }
        public string _tag { get; set; }
        public double _altitude { get; set; }
        public double Velocity { get; set; }

        public Track(Update beforeTrack, Update nowTrack)
        {
            this._tag = nowTrack._tag;
            _xcoordinate = nowTrack._xcoordinate;
            _ycoordinate = nowTrack._ycoordinate;
            this._altitude = nowTrack._altitude;
            this._date = nowTrack._date;


            Velocity = CalculateVelocity(beforeTrack._xcoordinate, _xcoordinate, beforeTrack._ycoordinate, _ycoordinate, beforeTrack._date,
                _date);

            direction_ = CalculateDegree(beforeTrack._xcoordinate, _xcoordinate, beforeTrack._ycoordinate, _ycoordinate);
        }

        public double Distance(double x1, double x2, double y1, double y2)
        {
            double hyp = Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));
            return hyp;
        }

        public double CalculateVelocity(double x1, double x2, double y1, double y2, DateTime date1, DateTime date2)
        {
            double hyp = Distance(x1, x2, y1, y2);
            TimeSpan timeSpan = date2 - date1;
            double timedef = timeSpan.TotalMilliseconds / 1000; 
            double v = hyp / timedef;
            return v;
        }

        public double CalculateDegree(double x1, double x2, double y1, double y2)
        {
            double xDiff = x2 - x1;
            double yDiff = y2 - y1;

            double deg = Math.Atan(xDiff / yDiff) * 180 / Math.PI;

            if (xDiff > 0 && yDiff < 0)
                return -deg + 90;

            if (xDiff < 0 && yDiff < 0)
                return deg + 180;

            if (xDiff < 0 && yDiff > 0)
                return -deg + 270;

            if (xDiff < 0 && yDiff == 0)
                return deg + 360;

            if (xDiff == 0 && yDiff < 0)
                return deg + 180;

            return deg;
        }

    }
}
