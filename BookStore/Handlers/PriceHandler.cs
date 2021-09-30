using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Handlers
{
    public class PriceHandler : IHandler
    {
        public void Execute(Book book)
        {
            book.Price = Math.Round(book.Price, MidpointRounding.ToPositiveInfinity);
        }
    }
}
