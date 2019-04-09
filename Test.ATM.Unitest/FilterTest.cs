using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMClasses;
using Castle.Core.Smtp;
using NSubstitute;
using NUnit.Framework;

namespace Test.ATM.Unitest
{
    public class FilterTest
    {
        private Filter _uut;
        private IDecoding _decoding;

        [SetUp]
        public void Setup()
        {
            _decoding = Substitute.For<IDecoding>();

            _uut = new Filter(_decoding);
        }

        [Test]
        //Tom event, ingen fejl og ingen event i den anden ende
        public void OnUpdateCreated_EmptyListInEventArg_TrackEditedIsNotRaised()
        {
            //ARRANGE
            var updateEvent = new Decoding.UpdateEvent();

            var wasCalled = false;
            _uut.TrackEdited += (sender, args) => wasCalled = true;

            //ACT
            _decoding._updateCreated += Raise.EventWith(updateEvent);
            _decoding._updateCreated += Raise.EventWith(updateEvent);


            //ASSERT
            Assert.False(wasCalled);
        }

        [TestCase(499.999)]
        [TestCase(20000.001)]
        //Test for Altitude lige uden for grænsen, bliver ikke tilføjet
        public void OnUpdateCreated_ContainOneTrackOutsideAltiude_TrackIsNotAdded(double altitude)
        {
            //ARRANGE
            var updateEvent = new Decoding.UpdateEvent();
            updateEvent.updatetracks = new List<Update>();
            updateEvent.updatetracks.Add(new Update("tag", 5000, 5000, altitude, DateTime.Now));

            Dictionary<String, ITrack> wasCalled = new Dictionary<string, ITrack>();
            _uut.TrackEdited += (sender, args) => wasCalled = args.tracks;

            //ACT
            _decoding._updateCreated += Raise.EventWith(updateEvent);
            _decoding._updateCreated += Raise.EventWith(updateEvent);


            //ASSERT
            Assert.That(wasCalled.ContainsKey("tag"), Is.False);
        }

        [TestCase(500)]
        [TestCase(20000)]
        //Test altitude indenfor tracking, bliver tilføjet
        public void OnUpdateCreated_ContainOneTrackInsideAltitude_TrackIsAdded(double altitude)
        {
            //ARRANGE
            var updateEvent = new Decoding.UpdateEvent();
            updateEvent.updatetracks = new List<Update>();
            updateEvent.updatetracks.Add(new Update("tag", 5000, 5000, altitude, DateTime.Now));

            Dictionary<String, ITrack> argsTracks = new Dictionary<string, ITrack>();
            _uut.TrackEdited += (sender, args) => argsTracks = args.tracks;

            //ACT
            _decoding._updateCreated += Raise.EventWith(updateEvent);
            _decoding._updateCreated += Raise.EventWith(updateEvent);


            //ASSERT
            Assert.That(argsTracks.ContainsKey("tag"), Is.True);
        }


        [TestCase(0)]
        [TestCase(80000)]
        //Test xcordinat lige på grænsen, bliver tilføjet
        public void OnUpdateCreated_ContainOneTrackWithXcordinatWithin_TrackIsAdded(double xCordinat)
        {
            //ARRANGE
            var updateEvent = new Decoding.UpdateEvent();
            updateEvent.updatetracks = new List<Update>();
            updateEvent.updatetracks.Add(new Update("tag", xCordinat, 5000, 1000, DateTime.Now));

            Dictionary<String, ITrack> argsTracks = new Dictionary<string, ITrack>();
            _uut.TrackEdited += (sender, args) => argsTracks = args.tracks;

            //ACT
            _decoding._updateCreated += Raise.EventWith(updateEvent);
            _decoding._updateCreated += Raise.EventWith(updateEvent);


            //ASSERT
            Assert.That(argsTracks.ContainsKey("tag"), Is.True);
        }

        [TestCase(-0.001)]
        [TestCase(80000.001)]
        //Test xcordinat lige på grænsen, bliver tilføjet
        public void OnUpdateCreated_ContainOneTrackWithXcordinatOutside_TrackIsAdded(double xCordinat)
        {
            //ARRANGE
            var updateEvent = new Decoding.UpdateEvent();
            updateEvent.updatetracks = new List<Update>();
            updateEvent.updatetracks.Add(new Update("tag", xCordinat, 5000, 1000, DateTime.Now));

            Dictionary<String, ITrack> argsTracks = new Dictionary<string, ITrack>();
            _uut.TrackEdited += (sender, args) => argsTracks = args.tracks;

            //ACT
            _decoding._updateCreated += Raise.EventWith(updateEvent);
            _decoding._updateCreated += Raise.EventWith(updateEvent);


            //ASSERT
            Assert.That(argsTracks.ContainsKey("tag"), Is.False);
        }

        [TestCase(0)]
        [TestCase(80000)]
        //Test ycordinat lige på grænsen, bliver tilføjet
        public void OnUpdateCreated_ContainOneTrackWithYcordinatWithin_TrackIsAdded(double yCordinat)
        {
            //ARRANGE
            var updateEvent = new Decoding.UpdateEvent();
            updateEvent.updatetracks = new List<Update>();
            updateEvent.updatetracks.Add(new Update("tag", yCordinat, 5000, 1000, DateTime.Now));

            Dictionary<String, ITrack> argsTracks = new Dictionary<string, ITrack>();
            _uut.TrackEdited += (sender, args) => argsTracks = args.tracks;

            //ACT
            _decoding._updateCreated += Raise.EventWith(updateEvent);
            _decoding._updateCreated += Raise.EventWith(updateEvent);


            //ASSERT
            Assert.That(argsTracks.ContainsKey("tag"), Is.True);
        }

        [TestCase(-0.001)]
        [TestCase(80000.001)]
        //Test ycordinat lige på grænsen, bliver tilføjet
        public void OnUpdateCreated_ContainOneTrackWithYcordinatOutside_TrackIsAdded(double yCordinat)
        {
            //ARRANGE
            var updateEvent = new Decoding.UpdateEvent();
            updateEvent.updatetracks = new List<Update>();
            updateEvent.updatetracks.Add(new Update("tag", yCordinat, 5000, 1000, DateTime.Now));

            Dictionary<String, ITrack> argsTracks = new Dictionary<string, ITrack>();
            _uut.TrackEdited += (sender, args) => argsTracks = args.tracks;

            //ACT
            _decoding._updateCreated += Raise.EventWith(updateEvent);
            _decoding._updateCreated += Raise.EventWith(updateEvent);


            //ASSERT
            Assert.That(argsTracks.ContainsKey("tag"), Is.False);
        }
    }
}
