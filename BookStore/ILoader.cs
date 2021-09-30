using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore
{
    public interface ILoader
    {
        List<Book> Load(string path);
    }
}
