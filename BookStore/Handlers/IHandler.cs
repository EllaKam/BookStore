using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Handlers
{
    public interface IHandler
    {
        void Execute(Book book);
    }
}
