using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;


namespace ATMClasses
{
    public class Writer
    {

        public Writer(AirSpace airSpace)
        {
            airSpace.SplitCreated += onSplitCreated;
        }

        public void onSplitCreated(object source, SplitEvent condition)
        {
            Console.Clear();

            String[] l = new String[condition.Conditiontracks.Count];

            for (int i = 0; i < condition.Conditiontracks.Count; i++)
            {
                l[i] = "Flight are in DANGER";

                for (int j = 0; j < condition.Conditiontracks[i].detectingFligts.Count; j++)
                {
                    l[i] += condition.Conditiontracks[i].detectingFligts[j]._tag + ", ";
                }

                l[i] += condition.Conditiontracks[i].detectTime + ":" +
                        condition.Conditiontracks[i].detectTime.Millisecond;
            }

            for (int i = 0; i < l.Length; i++)
            {
                Console.WriteLine(l[i]);
            }

        }
    }
}
