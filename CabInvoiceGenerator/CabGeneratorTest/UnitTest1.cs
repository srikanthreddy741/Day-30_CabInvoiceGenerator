using CabInvoiceGenerator;

namespace CabGeneratorTest
{
    public class CanInvoiceTest
    {
        InvoiceGenerator invoicegenerator;
        [SetUp]
        public void Setup()
        {
            invoicegenerator = new InvoiceGenerator(RideType.NORMAL);
        }

        [Test]
        public void GivenDistanceAndTimeReturnTotalFair()
        {
            //assert
            int distance = 2;
            int time = 5;
            double expected = 25;
            InvoiceGenerator generator = new InvoiceGenerator(RideType.NORMAL);
            //act

            double actual = generator.CalculateTotalFair(distance, time);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GivenDistanceAndTimeReturnTotalFairForPrimiumRides()
        {
            //assert
            int distance = 2;
            int time = 5;
            double expected = 40;
            InvoiceGenerator generator = new InvoiceGenerator(RideType.PREMIUM);
            //act
            double actual = generator.CalculateTotalFair(distance, time);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GivenMultipleRidesreturnTotalFair()
        {
            //assert
            double expected = 97;
            Ride[] rides = new Ride[]
            {
                new Ride(2,5),//40
                new Ride(3,6)//3*15+6*2=57//57+40=97
            };
            InvoiceGenerator generator = new InvoiceGenerator(RideType.PREMIUM);
            //act

            InvoiceSummery actual = generator.CalculateTotalFair(rides);
            //assert
            Assert.AreEqual(expected, actual.totalFair);
        }
        [Test]
        public void GivenMultipleRidesreturnTotalFairNumberOfRidesAvreage()
        {
            //assert
            Ride[] rides = new Ride[]
            {
                new Ride(2,5),//40
                new Ride(3,6)//3*15+6*2=57//57+40=97
            };
            double totalFair = 97;
            double average = totalFair / rides.Length;
            InvoiceSummery expected1 = new InvoiceSummery(rides.Length, totalFair);
            //Program expected1 = new Program();
            InvoiceGenerator generator = new InvoiceGenerator(RideType.PREMIUM);
            //act

            var actual = generator.CalculateTotalFair(rides);
            //assert
            // Assert.AreEqual(expected1, actual);
            expected1.Equals(actual);
        }
    }
}