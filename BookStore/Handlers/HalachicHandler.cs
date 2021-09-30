using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Handlers
{
    public class HalachicHandler : IHandler
    {
        public void Execute(Book book)
        {
            if (book.PublishDate.DayOfWeek == DayOfWeek.Saturday)
            {
                book.IsDelete = true;
            }
        }
    }
}
