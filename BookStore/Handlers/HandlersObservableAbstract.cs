using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Handlers
{
    public abstract class HandlersObservableAbstract
    {
        protected List<IHandler> _handlers;
        public abstract void AddHandler(IHandler handler);
        public abstract void Execute(List<Book> books);
    }
}
