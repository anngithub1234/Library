using System;
using System.Collections.Generic;
using System.Text;

namespace CB009582SDAM
{
   
    
        class Books
        {
            private static int bookID = 1231;
            public static readonly string AVAILABLE = "Available";
            public static readonly string ON_LOAN = "On loan";


            public string Author { get; }
            public int Id { get; }
            public string ISBN { get; }
            public string Status { get; private set; }
            public string Title { get; }

            public Books(string author, string isbn, string title)
            {
                Id = bookID++;
                Author = author;
                ISBN = isbn;
                Title = title;
                Status = AVAILABLE;
            }

            public void Set_Available()
            {
                Status = AVAILABLE;
            }

            public void Set_OnLoan()
            {
                Status = ON_LOAN;
            }
        }
    
}
