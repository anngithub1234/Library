using System;
namespace CB009582SDAM
{
    public class Fine
    {
        public double Amount { get; }
        public string Method { get; set; }
        public double FineAmount { get; private set; }
        public string PayMethod { get; }
        public DateTime fineDate { get; }
        public int FineCaldebit { get; private set; }
        public int FineCalcredit { get; private set; }
        public int FineCalcash { get; private set; }


        public Fine(double amount, string method)
        {
            Amount = amount;
            Method = method;
           
            FineAmount = 0;
            PayMethod = PayMethod;
            FineCaldebit = 0;
            FineCalcredit = 0;
            FineCalcash = 0;
           
        }

        /*public bool CalFine()
        {

        }*/


    }

}
