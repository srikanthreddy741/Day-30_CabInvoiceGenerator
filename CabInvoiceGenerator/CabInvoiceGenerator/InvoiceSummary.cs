using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceSummery : object
    {
        public int numberofRides;
        public double totalFair;
        public double average;
        public InvoiceSummery(int numberofRides, double totalFair)
        {
            this.numberofRides = numberofRides;
            this.totalFair = totalFair;
            this.average = (totalFair / numberofRides);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is InvoiceSummery))
            {
                return false;
            }
            InvoiceSummery imputedObject = (InvoiceSummery)obj;
            return this.numberofRides == imputedObject.numberofRides && this.totalFair == imputedObject.totalFair && this.average == imputedObject.average;
        }
    }
}