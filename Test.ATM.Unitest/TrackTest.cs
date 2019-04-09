using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMClasses;


namespace Test.ATM.Unitest
{
    [TestFixture()]

    class TrackTest
    {
        private Update track1 = new Update("TAG", 0, 0, 0, DateTime.Now);
        private Update track2 = new Update("TAG", 0, 0, 0, DateTime.Now);

        // test 1:
        [TestCase(50, 0, 0, 0, 50)]
        [TestCase(0, 50, 0, 0, 50)]
        [TestCase(0, 0, 50, 0, 50)]
        [TestCase(0, 0, 0, 50, 50)]
        [TestCase(0, 30, 0, 40, 50)]

        //Metoden, scenario og det forvenetet resultat:
        public void Coordinates_Returns_Distance(double x1, double x2, double y1, double y2, double distance)
        {

           track1._xcoordinate = x1;
            track1._ycoordinate = y1;

           track2._xcoordinate = x2;
            track2._ycoordinate = y2;

            Track track = new Track(track1, track2);
            double hyp = track.Distance(x1, x2, y1, y2);
            Assert.That(hyp, Is.EqualTo(distance));
        }

        //Test 2:

        [Test]

        //Metoden, scenario og det forvenetet resultat:

        public void Coordinates_Date_Return_Velocity1()
        {
            //                                 "yyyymmddhhmmssfff"
            DateTime dt1 = DateTime.ParseExact("20190320000000000", "yyyyMMddhhmmssfff",
                System.Globalization.CultureInfo.InvariantCulture);
            //                                 "yyyymmddhhmmssfff"
            DateTime dt2 = DateTime.ParseExact("20190320000001000", "yyyyMMddhhmmssfff",
                System.Globalization.CultureInfo.InvariantCulture);

            track1._date = dt1;
            track1._xcoordinate = 0;
            track1._ycoordinate = 0;

            track2._date = dt2;
           track2._xcoordinate = 30;
            track2._ycoordinate = 40;

            Track track = new Track(track1, track2);
            double v = track.CalculateVelocity(0, 30, 0, 40, dt1, dt2);
            Assert.That(v, Is.EqualTo(50));
        }


        [Test]

        //Metoden, scenario og det forvenetet resultat:

        public void Coordinates_Date_Return_Velocity2()
        {
            //                                 "yyyymmddhhmmssfff"
            DateTime dt1 = DateTime.ParseExact("20190325000000000", "yyyyMMddhhmmssfff",
                System.Globalization.CultureInfo.InvariantCulture);
            //                                 "yyyymmddhhmmssfff"
            DateTime dt2 = DateTime.ParseExact("20190325000005000", "yyyyMMddhhmmssfff",
                System.Globalization.CultureInfo.InvariantCulture);

            track1._date = dt1;
            track1._xcoordinate = 0;
            track1._ycoordinate = 1000;

            track2._date = dt2;
            track2._xcoordinate = 0;
            track2._ycoordinate = 0;

            Track track = new Track(track1, track2);
            double v = track.CalculateVelocity(0, 0, 1000, 0, dt1, dt2);
            Assert.That(v, Is.EqualTo(200));
        }

        //3.4-3.11
        [TestCase(0, 25, 0, 25, 45)]
        [TestCase(50, 25, 0, 25, 315)]
        [TestCase(25, 0, 25, 0, 225)]
        [TestCase(0, 25, 25, 0, 135)]
        [TestCase(0, 0, 0, 25, 0)]
        [TestCase(0, 25, 0, 0, 90)]
        [TestCase(0, 0, 25, 0, 180)]
        [TestCase(25, 0, 0, 0, 270)]
        public void Coordinates_Returns_Degree(double x1, double x2, double y1, double y2, double degree)
        {
           track1._xcoordinate = x1;
            track1._ycoordinate = y2;

            track2._xcoordinate = x2;
            track2._ycoordinate = y2;
            
            Track track = new Track(track1, track2);
            double deg = track.CalculateDegree(x1, x2, y1, y2);

            Assert.That(deg, Is.EqualTo(degree));

        }
    }
}
