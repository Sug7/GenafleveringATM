using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMClasses
{
    public class Render
    {
        public double _direction { get; set; }
        public DateTime Date { get; set; }
        public double X_cor { get; set; }
        public double Y_cor { get; set; }
        public string _tag { get; set; }
        public double _altitude { get; set; }
        public bool _velocity { get; set; }

        public Render(IUpdate previousTrack, IUpdate currentTrack)
        {
            _tag = currentTrack.tag_;
            X_cor = currentTrack.X_cor;
            Y_cor = currentTrack.X_cor;
            _altitude = currentTrack.altitude_;
            Date= currentTrack.Date;


            _velocity = CalculateVelocity(previousTrack.X_cor, X_cor, previousTrack.Y_cor, Y_cor, previousTrack.Date,
                Date);

            _direction = CalculateDegree(previousTrack.X_cor, X_cor, previousTrack.Y_cor, Y_cor);
        }

        public double Distance(double x1, double x2, double y1, double y2)
        {
            double hyp = Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));
            return hyp;
        }

        public double CalculateVelocity(double x1, double x2, double y1, double y2, DateTime date1, DateTime date2)
        {
            double hyp = Distance(x1, x2, y1, y2);
            TimeSpan span = date2 - date1;
            double timedef = span.TotalMilliseconds / 1000;
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
