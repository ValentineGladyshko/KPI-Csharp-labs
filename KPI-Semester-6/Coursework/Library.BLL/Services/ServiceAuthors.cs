using System;
using System.Collections.Generic;
using System.Linq;
using Library.DAL.Repositories;
using Library.DAL.Entities;
using Library.BLL.DataModels;
using Library.BLL.Exceptions;

namespace Library.BLL.Services
{
    public class ServiceAuthors
    {
        private UnitOfWork UOW;

        public ServiceAuthors()
        {
            UOW = new UnitOfWork();
        }

        public void AddAuthor(AuthorDM authorDM)
        {
            UOW.Authors.Create(new Author
            {
                FirstName = authorDM.FirstName,
                LastName = authorDM.LastName
            });

            UOW.Save();
        }

        public void DeleteAuthor(AuthorDM authorDM)
        {
            try
            {
                Author author = UOW.Authors.Get(authorDM.AuthorID);

                foreach(BookAuthor ba in UOW.BookAuthors.Find(ba => ba.AuthorID == author.AuthorID))
                {
                    UOW.BookAuthors.Delete(ba.BookAuthorID);
                }
                UOW.Save();

                UOW.Authors.Delete(author.AuthorID);
                UOW.Save();
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in deleting Author");
            }
        }

        public void UpdateAuthor(AuthorDM authorDM)
        {
            try
            {
                UOW.Authors.Update(new Author
                {
                    AuthorID = authorDM.AuthorID,
                    FirstName = authorDM.FirstName,
                    LastName = authorDM.LastName
                });

                UOW.Save();
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in updating Author");
            }
        }

        public AuthorDM GetAuthor(int ID)
        {
            try
            {
                Author author = UOW.Authors.Get(ID);

                return new AuthorDM
                {
                    AuthorID = author.AuthorID,
                    FirstName = author.FirstName,
                    LastName = author.LastName
                };
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in geting Author");
            }
        }

        public IEnumerable<AuthorDM> GetAuthors()
        {
            List<AuthorDM> result = new List<AuthorDM>();

            foreach (Author a in UOW.Authors.GetAll())
            {
                result.Add(new AuthorDM
                {
                    AuthorID = a.AuthorID,
                    FirstName = a.FirstName,
                    LastName = a.LastName
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
