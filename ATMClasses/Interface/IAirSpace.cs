using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMClasses.Interface
{
    public interface IAirSpace
    {
        event EventHandler<SplitEvent> SplitCreated;

        double Distance(ITrack track1, ITrack track2);
        void onTrackEdited(object source, TrackEvent trackEvent);
        Dictionary<String, ITrack> tracks { get; set; }

    }
}
