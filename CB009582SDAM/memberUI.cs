using System;
using System.Collections.Generic;
using System.Text;

namespace CB009582SDAM
{
    class memberUI
    {
   

        private loanAdmin loanM;
        private memberAdmin memberM;

        public memberUI(loanAdmin loanM, memberAdmin memberM)
        {
            this.loanM = loanM;
            this.memberM = memberM;
        }

        public void BorrowBook(int memberId, int bookId)
        {
            memberM.BorrowBook(memberId, bookId);
        }

        public void ReturnBook(int memberId, int bookId)
        {
            loanM.EndLoan(memberId, bookId);
        }

        public bool RenewLoan(int memberId, int bookId)
        {
            return loanM.RenewLoan(memberId, bookId);
        }

        public void ReserveBook(int bookId)
        {
            memberM.reserve1(bookId);
        }

    }
}