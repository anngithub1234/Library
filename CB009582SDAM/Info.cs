using System;
using System.Collections.Generic;
using System.Text;

namespace CB009582SDAM
{
    class Info
    {
        private bookAdmin bookAd;
        private loanAdmin loanAd;

        public Info(bookAdmin bookAd, loanAdmin loanAd)
        {
            this.bookAd = bookAd;
            this.loanAd = loanAd;
        }

        public List<Books> ViewAllBooks()
        {
            return bookAd.View_AllBooks();
        }

        public List<Loan> ViewCurrentLoans()
        {
            return loanAd.GetCurrentLoans();
        }
    }
}

