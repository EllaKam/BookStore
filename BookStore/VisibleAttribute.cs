using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore
{
    public class VisibleAttribute : Attribute
    {
        public bool NotVisible { get; set; }

    }
}
