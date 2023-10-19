using System;
using System.Collections.Generic;

namespace CB009582SDAM
{
    class Program
    {
        private static Info details;
        private static memberUI member_ui;
        private const int EXIT = 8;


        static void Main(string[] args)
        {
            libraryData();
            interfaceText();

            int choice = menuChoice();

            while (choice != EXIT)
            {
                /*s
                {
                    c
                }*/
                if (choice== 1)
                {
                    Borrow_Book();
                }
                else if(choice== 2)
                {
                    Return_Book();
                }
                else if (choice == 3)
                {
                    ViewAllBook_Status();
                }
                else if (choice == 4)
                {
                    extend_Loan();
                }
                else if (choice == 5)
                {
                    view_Loan();
                }
                else if (choice == 6)
                {
                    reserve_Abook();
                }
                
                

                interfaceText();
                choice = menuChoice();
            }

        }

        private static void libraryData()
        {

            bookAdmin bookAd = new bookAdmin();
            loanAdmin loanMgr = new loanAdmin();
            memberAdmin memberM = new memberAdmin(bookAd, loanMgr);

            details = new Info(bookAd, loanMgr);
            member_ui = new memberUI(loanMgr, memberM);
            memberM.AddMember(new Member("ann"));
            memberM.AddMember(new Member("Hirundya"));
            memberM.AddMember(new Member("Mark"));

            bookAd.AddBook(new Books("Jame", "Title 1", "1234567890"));
            bookAd.AddBook(new Books("Author 2", "Title 2", "1234567889"));
            bookAd.AddBook(new Books("Author 3", "Title 3", "1234567888"));
        }

        private static int menuChoice()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            int Choice = displayMenu1("\nEnter Your Choice ");
            while (Choice < 1 || Choice > 9)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Choice, Try Again");
                Choice = displayMenu1("\nEnter Your Choice");
            }
            return Choice;
        }


        private static void interfaceText()
        {
            Console.ForegroundColor = ConsoleColor.Blue;


            Console.WriteLine("\n.................SyscoTech Book Managment System.................\n\n", Console.ForegroundColor);
            Console.WriteLine("Welcome To Main Menu, Please Enter Your Choice\n");
            Console.WriteLine(" 1 to modify borrow \n 2 to extend return " +
              "\n3 to view member details\n4 to view all books\n5 to view current loans\n6 to reserve a Book\n7 to Extend loans\n8 to Exit ");

        }

        private static int displayMenu1(string prompt)
        {

            try
            {
                Console.Write(prompt + ": > ");

                return Convert.ToInt32(Console.ReadLine());

            }
            catch (Exception)
            {
                return -1;
            }

        }

        private static void Borrow_Book()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int memberID = displayMenu1("\nMember ID");
            int bookID = displayMenu1("Book ID");
            try
            {

                member_ui.BorrowBook(memberID, bookID);
                Console.WriteLine("Book borrowed");

            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This ID's does not exist");

            }

        }

        private static void extend_Loan()
        {
            int memberId = displayMenu1("\nMember ID");
            int bookId = displayMenu1("Book ID");
            Console.WriteLine("\nLoan has {0}been renewed", member_ui.RenewLoan(memberId, bookId) ? "" : "not ");
        }
        private static void Return_Book()
        {
            int memberID = displayMenu1("\nMember ID");
            int bookID = displayMenu1("Book ID");

            try
            {
                member_ui.ReturnBook(memberID, bookID);
                Console.WriteLine("\nBook returned");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + e.Message);
            }

        }


        private static void ViewAllBook_Status()
        {
            List<Books> books = details.ViewAllBooks();
            Console.WriteLine("All Book Details");
            Console.WriteLine("\t{0, -4} {1, -20} {2, -20} {3, -10}    {4}", "ID", "Title", "Author", "ISBN", "Status");
            foreach (Books b in books)
            {

                DisplayBook(b);

            }
        }

        private static void reserve_Abook()
        {
            ViewAllBook_Status();
            Console.WriteLine("which book do  you what to reserve");
            int bookID = displayMenu1("Book ID");
            try
            {

                member_ui.ReserveBook(bookID);
                Console.WriteLine("\nBook reserved");

            }
            catch (Exception)
            {
                Console.WriteLine("this book doesn't exsist");
            }

        }

        private static void DisplayBook(Books b)
        {
            Console.WriteLine(
                "\t{0, -4}  {1, -20} {2, -20} {3, -10}    {4}",
                b.Id,
                b.Title,
                b.Author,
                b.ISBN,
                b.Status);
        }


        private static void view_Loan()
        {


            List<Loan> loans = details.ViewCurrentLoans();
            Console.WriteLine("\nCurrent loans");
            Console.WriteLine("\t{0, -20} {1, -20} {2, -12} {3, -12} {4, -8}", "Title", "Borrower", "Loan date", "Due date", "Renewals");
            foreach (Loan l in loans)
            {
                DisplayLoan(l);
            }

        }

        private static void DisplayLoan(Loan loan)
        {

            Console.WriteLine(
                "\t{0, -20} {1, -20} {2, -12} {3, -12}    {4}",
                loan.Books.Title,
                loan.Member.Name,
                loan.BorrowDate.ToString("dd/MM/yyyy"),
                loan.dueDate.ToString("dd/MM/yyyy"),
                loan.NumberOfExtends);

        }


     
    }
}

