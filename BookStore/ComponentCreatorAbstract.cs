using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BookStore.Handlers;

namespace BookStore
{
    public abstract class ComponentCreatorAbstract
    {
        public ILoader Loader;
        public HandlersObservableAbstract Handlers;
        public IOutput Output;
        protected abstract void LoaderCreator();

        protected abstract void HandlersCreator();

        protected abstract void OutputCreator();
        public abstract void CreateComponent();

    }
}
