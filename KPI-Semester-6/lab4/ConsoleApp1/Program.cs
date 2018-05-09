using System;
using Library.DAL.Repositories;
using Library.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            var Genres = unitOfWork.Genres.GetAll();
            foreach(Genre b in Genres)
            {
                Console.Write(b.GenreID);
                Console.Write(" ");
                Console.WriteLine(b.Name);
               
            }
            Console.WriteLine("dsgdfh");
            Console.ReadKey();
            
            var Books = unitOfWork.Books.GetAll();
            foreach (Book b in Books)
            {
                Console.Write(b.GenreID);
                Console.Write(" ");
                Console.Write(b.Genre.Name);
                Console.Write(" ");
                Console.WriteLine(b.Name);

            }
            Console.WriteLine("dsgdfh");
            Console.ReadKey();
        }
    }
}
