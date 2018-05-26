using System;
using System.Collections.Generic;
using System.Linq;
using Storage.DAL.Repositories;
using Storage.DAL.Entities;
using Storage.BLL.DataModels;
using Storage.BLL.Exceptions;

namespace Storage.BLL.Services
{
    public class ServiceUsers
    {
        private UnitOfWork UOW;

        public ServiceUsers()
        {
            UOW = new UnitOfWork();
        }

        public void AddUser(UserDM userDM)
        {
            UOW.Users.Create(new User
            {
                FirstName = userDM.FirstName,
                LastName = userDM.LastName,
                Quantity = 0
            });

            UOW.Save();
        }

        public void DeleteUser(UserDM userDM)
        {
            try
            {
                User user = UOW.Users.Get(userDM.UserID);

                foreach (BookUser bu in UOW.BookUsers.Find(bu => bu.UserID == user.UserID))
                {
                    UOW.BookUsers.Delete(bu.BookUserID);
                }
                UOW.Save();

                UOW.Users.Delete(user.UserID);
                UOW.Save();
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in deleting User");
            }
        }

        public void UpdateUser(UserDM userDM)
        {
            try
            {
                UOW.Users.Update(new User
                {
                    UserID = userDM.UserID,
                    FirstName = userDM.FirstName,
                    LastName = userDM.LastName,
                    Quantity = userDM.Quantity
                });

                UOW.Save();
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in updating User");
            }
        }

        public int AddBookToUser(UserDM userDM, BookDM bookDM)
        {
            try
            {
                if(UOW.Books.Get(bookDM.BookID).Quantity <= 0)
                {
                    return 1;
                }

                if (UOW.Users.Get(userDM.UserID).Quantity >= 10)
                {
                    return 2;
                }

                Book book = UOW.Books.Get(bookDM.BookID);
                book.Quantity--;
                UOW.Books.Update(book);
                UOW.Save();

                User user = UOW.Users.Get(userDM.UserID);
                user.Quantity++;
                UOW.Users.Update(user);
                UOW.Save();

                UOW.BookUsers.Create(new BookUser
                {
                    BookID = bookDM.BookID,
                    UserID = userDM.UserID
                });

                UOW.Save();
                return 0;
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in adding Book to User");
            }
        }

        public void DeleteBookFromUser(UserDM userDM, BookDM bookDM)
        {
            try
            {
                Book book = UOW.Books.Get(bookDM.BookID);
                book.Quantity++;
                UOW.Books.Update(book);
                UOW.Save();

                User user = UOW.Users.Get(userDM.UserID);
                user.Quantity--;
                UOW.Users.Update(user);
                UOW.Save();

                UOW.BookUsers.Delete(UOW.BookUsers.Find(bu => bu.BookID == bookDM.BookID
                    && bu.UserID == userDM.UserID).First().BookUserID);

                UOW.Save();
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in deleting Book from User");
            }
        }

        public UserDM GetUser(int ID)
        {
            try
            {
                User user = UOW.Users.Get(ID);

                IEnumerable<Book> books = UOW.Books.GetAll();
                IEnumerable<Author> authors = UOW.Authors.GetAll();

                List<BookDM> bookList = new List<BookDM>();
                var bookQuery = books.Where(b => b.BookUsers.Any(bu => bu.UserID == ID));
                foreach (Book b in bookQuery)
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

                    bookList.Add(new BookDM
                    {
                        BookID = b.BookID,
                        Name = b.Name,
                        GenreID = b.GenreID,
                        PublishDate = b.PublishDate,
                        Quantity = b.Quantity,
                        Authors = authorList
                    });
                }

                return new UserDM
                {
                    UserID = user.UserID,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Quantity = user.Quantity,
                    Books = bookList
                };
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in geting User");
            }
        }

        public IEnumerable<UserDM> GetUsers()
        {
            IEnumerable<Book> books = UOW.Books.GetAll();
            IEnumerable<User> users = UOW.Users.GetAll();
            IEnumerable<Author> authors = UOW.Authors.GetAll();

            List<UserDM> result = new List<UserDM>();

            foreach (User u in users)
            {
                List<BookDM> bookList = new List<BookDM>();
                var bookQuery = books.Where(b => b.BookUsers.Any(bu => bu.UserID == u.UserID));
                foreach (Book b in bookQuery)
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

                    bookList.Add(new BookDM
                    {
                        BookID = b.BookID,
                        Name = b.Name,
                        GenreID = b.GenreID,
                        PublishDate = b.PublishDate,
                        Quantity = b.Quantity,
                        Authors = authorList
                    });
                }

                result.Add(new UserDM
                {
                    UserID = u.UserID,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Quantity = u.Quantity,
                    Books = bookList
                });
            }

            return result;
        }

        public void Dispose()
        {
            UOW.Dispose();
        }
    }
}
