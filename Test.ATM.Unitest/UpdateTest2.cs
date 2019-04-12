using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMClasses;
using NUnit.Framework;

namespace Test.ATM.Unitest
{
    class UpdateTest2
    {
        [TestFixture()]
        class UpdateTest
        {
            // TEST 1

            [TestCase(10000, 10000, 500)]
            [TestCase(90000, 90000, 20000)]
           
            public void BoundaryCoordinates_Return_InAirSpaceTrue(double x, double y, double altitude)
            {
                Update u = new Update("AES", x, y, altitude, DateTime.Now);

                Assert.That(u.InAirspace.Equals(true));
            }

            //TEST 2

            [TestCase(9999, 10000, 500)]
            [TestCase(10000, 9999, 500)]
            [TestCase(10000, 10000, 499)]
            [TestCase(90001, 90000, 20000)]
            [TestCase(90000, 90001, 20000)]
            [TestCase(90000, 90000, 20001)]


            //metode, scenario, forventet resultat
            public void BoundaryCoordinates_Returns_InAirspaceFalse(double x, double y, double altitude)
            {
                Update u = new Update("AES", x, y, altitude, DateTime.Now);

                Assert.That(u.InAirspace.Equals(false));
            }




        }
    }
}

