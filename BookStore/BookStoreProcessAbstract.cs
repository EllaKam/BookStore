using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Handlers;

namespace BookStore
{
    public abstract class BookStoreProcessAbstract
    {
        protected ComponentCreatorAbstract _componentCreator;

        public abstract void CreateComponent();
        public abstract List<Book> Load(string path);
        public abstract void Handlers(List<Book> books);
        public abstract void Save(List<Book> books);
    }
}
