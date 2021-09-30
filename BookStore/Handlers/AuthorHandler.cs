using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace BookStore.Handlers
{
    public class AuthorHandler : IHandler
    {
        public void Execute(Book book)
        {
            string authorName = ConfigurationManager.AppSettings["AuthorName"];
            if (book.Author.IndexOf(authorName) > -1)
            {
                book.IsDelete = true;
            }
        }
    }
}
