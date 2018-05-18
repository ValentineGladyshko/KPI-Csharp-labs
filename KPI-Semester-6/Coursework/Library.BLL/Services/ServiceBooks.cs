using System;
using System.Collections.Generic;
using System.Linq;
using Library.DAL.Repositories;
using Library.DAL.Entities;
using Library.BLL.DataModels;
using Library.BLL.Exceptions;

namespace Library.BLL.Services
{
    public class ServiceBooks
    {
        private UnitOfWork UOW;

        public ServiceBooks()
        {
            UOW = new UnitOfWork();
        }

        public void AddBook(BookDM bookDM)
        {
            UOW.Books.Create(new Book
            {
                Name = bookDM.Name,
                GenreID = bookDM.GenreID,
                PublishDate = bookDM.PublishDate,
                Quantity = bookDM.Quantity
            });

            UOW.Save();
        }

        public bool DeleteBook(BookDM bookDM)
        {
            try
            {
                Book book = UOW.Books.Get(bookDM.BookID);

                if (UOW.BookUsers.Find(bu => bu.BookID
                     == book.BookID).Count() == 0)
                {
                    foreach (BookAuthor ba in UOW.BookAuthors.Find(ba => ba.BookID == book.BookID))
                    {
                        UOW.BookAuthors.Delete(ba.BookAuthorID);
                    }
                    UOW.Save();

                    UOW.Books.Delete(book.BookID);
                    UOW.Save();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in deleting Book");
            }
        }

        public void UpdateBook(BookDM bookDM)
        {
            try
            {
                UOW.Books.Update(new Book
                {
                    BookID = bookDM.BookID,
                    Name = bookDM.Name,
                    GenreID = bookDM.GenreID,
                    PublishDate = bookDM.PublishDate,
                    Quantity = bookDM.Quantity
                });

                UOW.Save();
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in updating Book");
            }
        }

        public BookDM GetBook(int ID)
        {
            try
            {
                Book book = UOW.Books.Get(ID);

                IEnumerable<Author> authors = UOW.Authors.GetAll();

                List<AuthorDM> authorList = new List<AuthorDM>();
                foreach (Author a in authors.Where
                    (a => a.BookAuthors.Any(ba => ba.BookID == ID)))
                {
                    authorList.Add(new AuthorDM
                    {
                        AuthorID = a.AuthorID,
                        FirstName = a.FirstName,
                        LastName = a.LastName
                    });
                }

                return new BookDM
                {
                    BookID = book.BookID,
                    Name = book.Name,
                    GenreID = book.GenreID,
                    PublishDate = book.PublishDate,
                    Quantity = book.Quantity,
                    Authors = authorList
                };
            }
            catch(Exception ex)
            {
                throw new DataException(ex.Message, "Error in geting Book");
            }
        }

        public void AddAuthorToBook(BookDM bookDM, AuthorDM authorDM)
        {
            try
            {
                UOW.BookAuthors.Create(new BookAuthor
                {
                    BookID = bookDM.BookID,
                    AuthorID = authorDM.AuthorID
                });

                UOW.Save();
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in adding Author to Book");
            }
        }

        public void DeleteAuthorFromBook(BookDM bookDM, AuthorDM authorDM)
        {
            try
            {
                UOW.BookAuthors.Delete(UOW.BookAuthors.Find(ba => ba.BookID == bookDM.BookID
                    && ba.AuthorID == authorDM.AuthorID).First().BookAuthorID);

                UOW.Save();
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in deleting Author from Book");
            }
        }

        public IEnumerable<BookDM> GetBooks()
        {
            IEnumerable<Book> books = UOW.Books.GetAll();
            IEnumerable<Author> authors = UOW.Authors.GetAll();

            List<BookDM> result = new List<BookDM>();

            foreach (Book b in books)
            {
                List<AuthorDM> authorList = new List<AuthorDM>();
                var authorQuery = authors.Where(a => a.BookAuthors.Any(ba => ba.BookID == b.BookID));
                foreach (Author a in authorQuery)
                {
                    authorList.Add(new AuthorDM
                    {
                        AuthorID = a.AuthorID,
                        FirstName = a.FirstName,
                        LastName = a.LastName
                    });
                }

                result.Add(new BookDM
                {
                    BookID = b.BookID,
                    Name = b.Name,
                    GenreID = b.GenreID,
                    PublishDate = b.PublishDate,
                    Quantity = b.Quantity,
                    Authors = authorList
                });
            }

            return result;
        }

        public IEnumerable<BookDM> BookSearch(string searchSrring)
        {
            searchSrring = searchSrring.ToLower();

            IEnumerable<Book> books = UOW.Books.GetAll();
            IEnumerable<Author> authors = UOW.Authors.GetAll();

            //IEnumerable<BookAuthor> bookAuthors = UOW.BookAuthors.GetAll();

            var bookQuery = books.Where(b => b.Name.ToLower().Contains(searchSrring) 
                || b.Genre.Name.ToLower().Contains(searchSrring) 
                || b.BookAuthors.Any(ba => ba.Author.FirstName.ToLower().Contains(searchSrring) 
                || ba.Author.LastName.ToLower().Contains(searchSrring)));

            //var query1 =
            //    (from book in books
            //     join bookAuthor in bookAuthors
            //     on book.BookID equals bookAuthor.BookID
            //     join author in authors
            //     on bookAuthor.AuthorID equals author.AuthorID
            //     where (book.Name.Contains(searchSrring)
            //         || book.Genre.Name.Contains(searchSrring)
            //         || author.FirstName.Contains(searchSrring)
            //         || author.LastName.Contains(searchSrring))
            //     select book).Distinct();

            List<BookDM> result = new List<BookDM>();

            foreach(Book b in bookQuery)
            {
                List<AuthorDM> authorList = new List<AuthorDM>();
                var authorQuery = authors.Where(a => a.BookAuthors.Any(ba => ba.BookID == b.BookID));
                foreach (Author a in authorQuery)
                {
                    authorList.Add(new AuthorDM
                    {
                        AuthorID = a.AuthorID,
                        FirstName = a.FirstName,
                        LastName = a.LastName
                    });
                }

                BookDM tmp = new BookDM
                {
                    BookID = b.BookID,
                    Name = b.Name,
                    GenreID = b.GenreID,
                    PublishDate = b.PublishDate,
                    Quantity = b.Quantity,
                    Authors = authorList
                };

                result.Add(tmp);
            }

            return result;
        }

        public void Dispose()
        {
            UOW.Dispose();
        }
    }
}
