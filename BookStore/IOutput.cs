using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore
{
    public interface IOutput
    {
        void SaveBooks(List<Book> books);
    }
}
