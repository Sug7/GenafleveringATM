using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMClasses
{
    public interface IUpdate
    {
        DateTime Date { get; set; }
        double X_cor { get; set; }
        double Y_cor { get; set; }
        string tag_ { get; set; }
        double altitude_ { get; set; }
        bool Airspace_ { get; set; }
    }
}
