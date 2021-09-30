using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using BookStore.Handlers;

namespace BookStore
{
    class Program
    {
        static void Main(string[] args)
        {
            BookStoreProcessAbstract process = new BookStoreProcess();
            process.CreateComponent();
            string pathFileInput = ConfigurationManager.AppSettings["FileInput"];
            if (File.Exists(pathFileInput))
            {
                //TODO: Schema validation
                List<Book> books = process.Load(pathFileInput);
                process.Handlers(books);
                process.Save(books);
            }
            else
            {
                Console.WriteLine($"File {pathFileInput} doesn't exits");
            }
            Console.Read();
        }
    }
}
