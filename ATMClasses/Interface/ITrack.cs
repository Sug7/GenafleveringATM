using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMClasses
{
    public interface ITrack
    {
        double direction_ { get; set; }
        DateTime _date { get; set; }
        double _xcoordinate { get; set; }
        double _ycoordinate { get; set; }
        string _tag { get; set; }
        double _altitude { get; set; }
        double Velocity { get; set; }

        double Distance(double x1, double x2, double y1, double y2);
        double CalculateVelocity(double x1, double x2, double y1, double y2, DateTime date1, DateTime date2);
        double CalculateDegree(double x1, double x2, double y1, double y2);
    }
}
