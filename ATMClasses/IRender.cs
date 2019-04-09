using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMClasses
{
    public interface IRender
    {
        double direction_ { get; set; }
        DateTime Date { get; set; }
        double X_coordinates { get; set; }
        double Y_coordinates { get; set; }
        string Tag_ { get; set; }
        double Altitude_ { get; set; }
        bool Velocity { get; set; }

        double Distance(double x1, double x2, double y1, double y2);
        double CalculateVelocity(double x1, double x2, double y1, double y2, DateTime date1, DateTime date2);
        double CalculateDegree(double x1, double x2, double y1, double y2);
    }
}
