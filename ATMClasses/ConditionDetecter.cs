using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMClasses
{
    public class ConditionDetecter
    {
        public List<ITrack> detectingFligts { get; }
        public  DateTime detectTime { get; }
        

        public ConditionDetecter(List<ITrack> All_Flights)
        {
            detectingFligts = All_Flights;
            detectTime = DateTime.Now;
        }

    }
}
