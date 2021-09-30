using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Handlers
{
    public class HandlersObservable : HandlersObservableAbstract
    {

        public HandlersObservable()
        {
            _handlers = new List<IHandler>();
        }
        public override void AddHandler(IHandler handler)
        {
            _handlers.Add(handler);
        }

        public override void Execute(List<Book> books)
        {
            foreach (Book book in books)
            {
                foreach (IHandler handler in _handlers)
                {
                    if (!book.IsDelete)
                    {
                        handler.Execute(book);
                    }
                }
            }
        }
    }
}
