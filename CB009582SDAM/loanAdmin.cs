using System;
using System.Collections.Generic;
using System.Text;

namespace CB009582SDAM
{
    class loanAdmin
    {

        List<Loan> loans = new List<Loan>();

        public void CreateLoan(Member m, Books b, DateTime loanDate)
        {
            loans.Add(new Loan(m, b, loanDate));
        }

        public void EndLoan(int memberId, int bookId)
        {
            Loan loan = FindLoan(memberId, bookId);

            if (loan != null)
            {
                loan.ReturnDate = DateTime.Now;
            }
        }

        public Loan FindLoan(int memberId, int bookId)
        {
            Loan foundLoan = null;

            for (int i = 0; foundLoan == null && i < loans.Count; i++)
            {
                if (loans[i].Books.Id == bookId &&
                    loans[i].Member.memId == memberId &&
                    loans[i].ReturnDate.ToBinary() == 0)
                {
                    foundLoan = loans[i];
                }
            }

            return foundLoan;
        }

        public List<Loan> GetCurrentLoans()
        {
            List<Loan> list = new List<Loan>();

            foreach (Loan loan in loans)
            {
                if (loan.ReturnDate.ToBinary() == 0)
                {
                    list.Add(loan);
                }
            }

            return list;
        }

        public bool RenewLoan(int memberId, int bookId)
        {
            Loan loan = FindLoan(memberId, bookId);

            if (loan != null)
            {
                bool loanWasRenewed = loan.extend();

                if (loanWasRenewed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }



    }
}  
