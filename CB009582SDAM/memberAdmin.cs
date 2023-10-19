using System;
using System.Collections.Generic;
using System.Text;

namespace CB009582SDAM
{
    class memberAdmin
    {
   

        private bookAdmin bookAd;
        private loanAdmin loanAd;
        private reservedItem r;


        private Dictionary<int, Member> members = new Dictionary<int, Member>();
        public memberAdmin(bookAdmin bookAd, loanAdmin loanAd)
        {

            this.bookAd = bookAd;
            this.loanAd = loanAd;

        }

        public void AddMember(Member m)
        {
            members.Add(m.memId, m);
        }

        public void BorrowBook(int memberId, int bookId)
        {
            Member m = searchMember(memberId);

            if (m != null && m.NumberOfLoans < 6)
            {
                Books b = bookAd.search_Book(bookId);
                if (b != null && b.Status == Books.AVAILABLE)
                {
                    loanAd.CreateLoan(m, b, DateTime.Now);
                }
            }
        }

        public Member searchMember(int memberId)
        {
            try
            {
                return members[memberId];
            }
            catch (KeyNotFoundException)
            {
                throw new Exception($"Member {memberId} does not exist");
            }
        }
        public void reserve1(int bookId)
        {


            Books b = bookAd.search_Book(bookId);
            if (b != null && b.Status == Books.AVAILABLE || b != null && b.Status == Books.ON_LOAN)
            {
                reservedItem.Equals(b, DateTime.Now);
            }


        }


        //member ui

    }

}