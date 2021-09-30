using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace BookStore
{
    public class JsonLoader : ILoader
    {
        public List<Book> Load(string path)
        {
            List<Book> books = null;

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                books = JsonConvert.DeserializeObject<List<Book>>(json);
            }

            return books;
        }
    }
}
