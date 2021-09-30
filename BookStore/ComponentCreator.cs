using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Handlers;

namespace BookStore
{
    public class ComponentCreator : ComponentCreatorAbstract
    {
        protected override void LoaderCreator()
        {
            Loader = new JsonLoader();
        }

        protected override void HandlersCreator()
        {
            Handlers = new HandlersObservable();
            Handlers.AddHandler(new AuthorHandler());
            Handlers.AddHandler(new HalachicHandler());
            Handlers.AddHandler(new PriceHandler());
        }


        protected override void OutputCreator()
        {
            Output = new ExcelOutput();
        }

        public override void CreateComponent()
        {
            LoaderCreator();
            HandlersCreator();
            OutputCreator();
        }
    }
}
