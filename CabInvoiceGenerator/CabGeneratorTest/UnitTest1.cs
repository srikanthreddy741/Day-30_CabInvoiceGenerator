using CabInvoiceGenerator;

namespace CabGeneratorTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            //arrange
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
            double expected = 25;
            //act
            double fare = invoiceGenerator.CalculateFare(distance, time);
            //assert
            Assert.AreEqual(expected, fare);
        }

        [Test]
        public void GivenMultipleRideShouldReturnInvoiceSummary()
        {
            //arrange
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 5) };
            //act
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 35.0);
            //assert
            Assert.AreEqual(expectedSummary.GetType(), summary.GetType());
        }
        [Test]
        public void GivenInvoiceGenerator_UsingInvoiceSummary_ShouldReturnInvoiceSummary()
        {
            //arrange
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            //act
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0, 3);
            //assert
            Assert.AreEqual(expectedSummary, summary);
        }
        [Test]
        public void GivenUserId_UsingInvoiceSummary_ShouldReturnInvoice()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            invoiceGenerator.AddRides("1", rides);
            InvoiceSummary summary = invoiceGenerator.GetInvoiceSummary("1");
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0, "1");
            Assert.AreEqual(expectedSummary, summary);
        }
        [Test]
        public void GivenRides_WhenPremiumOrNormal_ShouldReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double distance = 3.0;
            int time = 20;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 85;
            Assert.AreEqual(expected, fare);
        }
    }
}