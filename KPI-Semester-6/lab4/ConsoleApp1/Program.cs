using System;
using Library.DAL.Repositories;
using Library.DAL.Entities;
using Library.BLL.Services;
using Library.BLL.DataModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceBooks serviceBooks = new ServiceBooks();
            UnitOfWork unitOfWork = new UnitOfWork();
            //var Genres = unitOfWork.Genres.GetAll();
            //foreach (Genre b in Genres)
            //{
            //    Console.Write(b.GenreID);
            //    Console.Write(" ");
            //    Console.WriteLine(b.Name);

            //}
            //Console.WriteLine("dsgdfh");
            //Console.ReadKey();

            //var Books = unitOfWork.Books.GetAll();
            //foreach (Book b in Books)
            //{
            //    var Authors = unitOfWork.BookAuthors.Find(ba => b.BookID == ba.BookID);
            //    Console.Write(b.GenreID);
            //    Console.Write("; ");
            //    Console.Write(b.Genre.Name);
            //    Console.Write("; LLL ; ");
            //    foreach (BookAuthor ba in Authors)
            //    {
            //        Console.Write(ba.Author.FirstName);
            //        Console.Write(" ");
            //        Console.Write(ba.Author.LastName);
            //        Console.Write(", ");
            //    }
            //    Console.Write("; LLL ; ");
            //    Console.WriteLine(b.Name);

            //}
            //Console.WriteLine("dsgdfh");
            //Console.ReadKey();
            //BookDM book = new BookDM();
            //book.BookID = 3;
            //AuthorDM author = new AuthorDM();
            //author.AuthorID = 3;
            //serviceBooks.DeleteAuthorFromBook(book, author);
            //var Books1 = unitOfWork.Books.GetAll();
            //foreach (Book b in Books1)
            //{
            //    var Authors = unitOfWork.BookAuthors.Find(ba => b.BookID == ba.BookID);
            //    Console.Write(b.GenreID);
            //    Console.Write("; ");
            //    Console.Write(b.Genre.Name);
            //    Console.Write("; LLL ; ");
            //    foreach (BookAuthor ba in Authors)
            //    {
            //        Console.Write(ba.Author.FirstName);
            //        Console.Write(" ");
            //        Console.Write(ba.Author.LastName);
            //        Console.Write(", ");
            //    }
            //    Console.Write("; LLL ; ");
            //    Console.WriteLine(b.Name);

            //}
            List <BookDM> list = serviceBooks.BookSearch(unitOfWork.Genres.Get(4).Name).ToList();
            foreach (BookDM b in list)
            {
                Console.WriteLine(b.Name);
            }
            Console.WriteLine("dsgdfh");
            Console.ReadKey();
        }
    }
}
