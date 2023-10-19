using System;
using System.Collections.Generic;
using System.Text;

namespace CB009582SDAM
{
    class Subscriptions
    {
        public static readonly string memberStatus1 = "Activated";
        public static readonly string memberStatus2 = "Deactivated";
        private static readonly int borrowingLimit1 = 3;
        private static readonly int borrowingLimit2 = 2;
        private static readonly int borrowingLimit3 = 1;
        public static readonly string TierA = "A";
        public static readonly string TierB = "B";
        public static readonly string TierC = "C";

        public string Subscription_Status { get; private set; }

        public int BORROWINGLIMIT { get; protected set; }

        public void Subscriptions1()
        {
            Subscription_Status = memberStatus1;
            BORROWINGLIMIT = borrowingLimit1;
        }

        public void Subscriptions2()
        {
            Subscription_Status = memberStatus1;
            BORROWINGLIMIT = borrowingLimit2;
        }

        public void Subscriptions3()
        {
            Subscription_Status = memberStatus1;
            BORROWINGLIMIT = borrowingLimit3;
        }

        public void activate_Subscription()
        {
            this.Subscription_Status = memberStatus1;
        }

        public void deactivate_Subscription()
        {
            this.Subscription_Status = memberStatus2;
        }






    }
}
