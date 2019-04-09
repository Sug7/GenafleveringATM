using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using ATMClasses;
using ATMClasses.Interface;

namespace Test.ATM.Unitest
{
    [TestFixture()]
    public class AirSpaceTest
    {
        private AirSpace _uut;
        private ITrack _track1;
        private ITrack _track2;
        private ITrack _track3;
        private ITrack _track4;
        private ITrack _track5;
        private ITrack _track6;
        private ITrack _track7;
        private TrackEvent _fakeTrackEvent;
        private int _eventCalled;
        private List<ConditionDetecter> _conditionList;
        private List<ITrack> _tracks;
        private IFilter _trackFilter;
        private IWriter _writer;

        [SetUp]

        public void Setup()
        {
            _fakeTrackEvent = new TrackEvent();
            _eventCalled = 0;
            //_conditionList = new List<ConditionDetecter>();
            //_conditionList = new List<ConditionDetecter>();


            _track1 = Substitute.For<ITrack>();
            _track1._xcoordinate = 50000;
            _track1._ycoordinate = 0;

            _track2 = Substitute.For<ITrack>();
            _track2._xcoordinate = 0;
            _track2._ycoordinate = 0;

            _track3 = Substitute.For<ITrack>();
            _track3._tag = "Flight3";
            _track3._xcoordinate = 20000;
            _track3._ycoordinate = 20000;
            _track3._altitude = 500;

            _track4 = Substitute.For<ITrack>();
            _track4._tag = "Flight4";
            _track4._xcoordinate = 20000;
            _track4._ycoordinate = 22000;
            _track4._altitude = 800;

            _track5 = Substitute.For<ITrack>();
            _track5._tag = "Flight5";
            _track5._xcoordinate = 20000;
            _track5._ycoordinate = 22000;
            _track5._altitude = 799;

            _track6 = Substitute.For<ITrack>();
            _track6._tag = "Flight6";
            _track6._xcoordinate = 20000;
            _track6._ycoordinate = 26000;
            _track6._altitude = 1000;

            _track7 = Substitute.For<ITrack>();
            _track7._tag = "Flight7";
            _track7._xcoordinate = 80000;
            _track7._ycoordinate = 40000;
            _track7._altitude = 500;

            _trackFilter = Substitute.For<IFilter>();
            _writer = Substitute.For<IWriter>();

            _uut = new AirSpace(_trackFilter, _writer);

            _uut.SplitCreated += (o, args) =>
            {
                _conditionList = args.Conditiontracks;
                ++_eventCalled;
            }
            ;
        }

        [Test]
        public void TwoTracks_Returns_Positive()
        {
            _fakeTrackEvent.tracks[_track4._tag] = _track4;
            _fakeTrackEvent.tracks[_track5._tag] = _track5;
            _trackFilter.TrackEdited += Raise.EventWith(_fakeTrackEvent);
            //double distance = _uut.Distance(_track1, _track2);
            //Assert.That(distance, Is.EqualTo(50000));
            Assert.That(_conditionList.Count, Is.EqualTo(1));
        }

        [Test]
        public void TwoTracks_Returns_Negative()
        {
            _fakeTrackEvent.tracks[_track1._tag] = _track1;
            _fakeTrackEvent.tracks[_track2._tag] = _track2;
            _trackFilter.TrackEdited += Raise.EventWith(_fakeTrackEvent);
            //double distance = _uut.Distance(_track1, _track2);
            //Assert.That(distance, Is.EqualTo(50000));
            Assert.That(_conditionList == null, Is.True);
        }

    }
}
