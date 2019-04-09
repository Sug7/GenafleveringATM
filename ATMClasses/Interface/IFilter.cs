using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ATMClasses.Decoding;

namespace ATMClasses
{
    public interface IFilter
    {
        event EventHandler<TrackEvent> TrackEdited;
        List<Update> _uTracks { get; set; }
        Dictionary<string, ITrack> _dictionaryTrack { get; }
        Dictionary<string, Update> _dictionaryUpdate { get; }
        void CreateTrack(Update updateTrack);
        void OnUpdateCreated(object source, UpdateEvent uTrack);
        void RemoveTrack(string tag);

   

    }
}
