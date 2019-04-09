using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMClasses
{
    public interface IUpdate
    {
        string _tag { get; set; }
        double _xcoordinate { get; set; }
        double _ycoordinate { get; set; }
        double _altitude { get; set; }
        DateTime _date { get; set; }
        bool InAirspace { get; set; }
    }
}

