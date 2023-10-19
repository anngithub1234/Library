using System;
using System.Collections.Generic;
using System.Text;

namespace CB009582SDAM
{
    class bookAdmin
    {
        private SortedDictionary<int, Books> books = new SortedDictionary<int, Books>();

        public void AddBook(Books b)
        {
            books.Add(b.Id, b);
        }

        public Books search_Book(int bookId)
        {
            try
            {
                return books[bookId];
            }
            catch (KeyNotFoundException)
            {
                throw new Exception($"Book {bookId} does not exist");
            }
        }

        public List<Books> View_AllBooks()
        {
            List<Books> list = new List<Books>(books.Count);

            foreach (Books b in books.Values)
            {
                list.Add(b);
            }

            return list;
        }

    }
}
