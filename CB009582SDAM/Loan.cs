using System;
using System.Collections.Generic;
using System.Text;

namespace CB009582SDAM
{
    class Loan
    {

        private static int nextID = 1;

        public int loanId { get; }
        public Member Member { get; }

        public Books Books { get; }

        public DateTime dueDate { get; set; }
        public DateTime BorrowDate { get; }
        public int NumberOfExtends { get; private set; }
        


        public Loan(Member m, Books b, DateTime borrowDate)
        {

            loanId = nextID++;
            Member = m;
            Books = b;
            Books.Set_OnLoan();
            Member.IncrementNumberOfLoans();
            BorrowDate = borrowDate;
            dueDate = BorrowDate.AddDays(7);
            NumberOfExtends = 0;
           

        }


        public bool extend()
        {
            if (NumberOfExtends < 3)
            {

                dueDate = dueDate.AddDays(7);
                NumberOfExtends++;
                return true;

            }

            return false;

        }

        private DateTime returnDate;

        public DateTime ReturnDate
        {
            get
            {
                return returnDate;
            }

            set
            {

                returnDate = value;
                Books.Set_Available();
                Member.DecrementNumberOfLoans();


            }
        }

        public int NumberOfExtentions { get; private set; }
        // loan Admin

        

    }
    /*public bool FineCaldebit()
    {
        if (fineAmount == 100)
        {

            fineAmount1 = fineAmount.15%;
            fineAmount = fineAmount - fineAmount1;
            return true;

        }

        return false;

    }
    public bool FineCalcash()
    {
        if (fineAmount == 100)
        {

            fineAmount2 = fineAmount.5;
            fineAmount =
            return true;

        }

        return false;

    }
    public bool FineCalcredit()
    {
        if (fineAmount == 100)
        {

            fineAmount3 = fineAmount.1 ;

            return true;

        }

        return false;

    }*/


}