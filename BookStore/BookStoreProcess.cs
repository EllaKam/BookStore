using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Handlers;

namespace BookStore
{
    public class BookStoreProcess : BookStoreProcessAbstract
    {

        public BookStoreProcess()
        {
            _componentCreator = new ComponentCreator();
        }

        public override void CreateComponent()
        {
            _componentCreator.CreateComponent();
        }

        public override List<Book> Load(string path)
        {
            return _componentCreator.Loader.Load(path);
        }

        public override void Handlers(List<Book> books)
        {
            _componentCreator.Handlers.Execute(books);
        }

        public override void Save(List<Book> books)
        {
            _componentCreator.Output.SaveBooks(books);
        }
    }
}
