using CabInvoiceGenerator;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        public readonly int MINIMUM_COST_PER_KM;
        public readonly int COST_PER_TIME;
        public readonly int MINIMUM_FARE;
        public RideType rideType;
        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            if (RideType.NORMAL == rideType)
            {
                MINIMUM_COST_PER_KM = 10;
                COST_PER_TIME = 1;
                MINIMUM_FARE = 5;
            }
            else
            {
                MINIMUM_COST_PER_KM = 15;
                COST_PER_TIME = 2;
                MINIMUM_FARE = 20;
            }
        }
        //calulating for uc1 and uc 5 normal and premium
        public double CalculateTotalFair(double distance, int time)
        {
            try
            {
                if (distance <= 0)
                {
                    throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.INVALID_ID_DISTANCE, "distance is invalid");
                }
                else if (distance <= 0)
                {
                    throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.INVALIDID_TIME, "time is valid");
                }
                else
                {
                    double totalFare = 0;
                    totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
                    return Math.Max(totalFare, MINIMUM_FARE);
                }
            }
            catch (CabInvoiceCustomException ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        //method overloading for multiple rides
        public InvoiceSummery CalculateTotalFair(Ride[] rides)
        {
            double totalFair = 0;
            foreach (Ride ride in rides)
            {
                totalFair += CalculateTotalFair(ride.distance, ride.time);
            }
            totalFair = Math.Max(totalFair, MINIMUM_FARE);
            return new InvoiceSummery(rides.Length, totalFair);
            //rides.Where(x => x.userID == 3);
        }
    }
}