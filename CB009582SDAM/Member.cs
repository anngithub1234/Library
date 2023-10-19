using System;
using System.Collections.Generic;
using System.Text;

namespace CB009582SDAM
{
    class Member
    {
 
       private static int nextID = 1401;
        public int memId { get; set; }
        public string Name { get; set; }
        public int NumberOfLoans { get; private set; }



        public Member(string name)
        {
            memId = nextID++;
            Name = name;
            NumberOfLoans = 0;

        }



        public bool DecrementNumberOfLoans()
        {
            if (NumberOfLoans > 0)
            {
                NumberOfLoans--;
                return true;
            }

            return false;
        }

        public bool IncrementNumberOfLoans()
        {
            if (NumberOfLoans < 6)
            {
                NumberOfLoans++;
                return true;
            }

            return false;
        }


    }
}


