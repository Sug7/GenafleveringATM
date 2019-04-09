using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMClasses.Interface;

namespace ATMClasses
{
    public class AirSpace : IAirSpace
    {
        private List<ConditionDetecter> conditionTracks;
        public event EventHandler<SplitEvent> SplitCreated;

        public Dictionary<String, ITrack> tracks { get; set; }

        public AirSpace(IFilter trackfilter, IWriter writer)
        {
            trackfilter.TrackEdited += onTrackEdited;
            conditionTracks = new List<ConditionDetecter>();
        }

        public void onTrackEdited(object source, TrackEvent trackEvent)
        {
            tracks = trackEvent.tracks;
            conditionTracks = new List<ConditionDetecter>();

            List<ITrack> flight = new List<ITrack>();

            foreach (var track in trackEvent.tracks)
            {
                flight.Add(track.Value);
            }

            for (int i = 0; i < flight.Count; i++)
            {
                for (int j = i + 1; j < flight.Count; j++)
                {
                    if (Distance(flight[i], flight[j]) < 5000)
                    {
                        if (Math.Abs(flight[i]._altitude - flight[j]._altitude) < 300)
                        {
                            List<ITrack> condition = new List<ITrack>();
                            condition.Add(flight[i]);
                            condition.Add(flight[j]);
                            conditionTracks.Add(new ConditionDetecter(condition));
                        }
                    }
                }
            }

            if (conditionTracks.Count > 0)
            {
                onSplitCreated(conditionTracks);
            }
        }

        public double Distance(ITrack track1, ITrack track2)
        {
            double hyp1 = Math.Sqrt(Math.Pow((track1._xcoordinate - track2._xcoordinate), 2) + Math.Pow((track1._ycoordinate - track2._ycoordinate), 2));
            return Math.Abs(hyp1);
        }
        protected virtual void onSplitCreated(List<ConditionDetecter> conditiontracks)
        {
            SplitCreated?.Invoke(this, new SplitEvent() { Conditiontracks= conditiontracks });
        }
     }

    public class SplitEvent : EventArgs
    {
        public List<ConditionDetecter> Conditiontracks { get; set; }
    }
}
