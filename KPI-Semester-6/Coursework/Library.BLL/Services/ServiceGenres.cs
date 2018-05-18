using System;
using System.Collections.Generic;
using System.Linq;
using Library.DAL.Repositories;
using Library.DAL.Entities;
using Library.BLL.DataModels;
using Library.BLL.Exceptions;

namespace Library.BLL.Services
{
    public class ServiceGenres
    {
        private UnitOfWork UOW;

        public ServiceGenres()
        {
            UOW = new UnitOfWork();
        }

        public void AddGenre(GenreDM genreDM)
        {
            UOW.Genres.Create(new Genre
            {
                Name = genreDM.Name
            });

            UOW.Save();
        }

        public bool DeleteGenre(GenreDM genreDM)
        {
            try
            {
                Genre genre = UOW.Genres.Get(genreDM.GenreID);

                if (UOW.Books.Find(b => b.GenreID 
                    == genre.GenreID).Count() == 0)
                {
                    UOW.Genres.Delete(genre.GenreID);
                    UOW.Save();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in deleting Genre");
            }
        }

        public void UpdateGenre(GenreDM genreDM)
        {
            try
            {
                UOW.Genres.Update(new Genre
                {
                    GenreID = genreDM.GenreID,
                    Name = genreDM.Name
                });

                UOW.Save();
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in updating Genre");
            }
        }

        public GenreDM GetGenre(int ID)
        {
            try
            {
                Genre genre = UOW.Genres.Get(ID);

                return new GenreDM
                {
                    GenreID = genre.GenreID,
                    Name = genre.Name
                };
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, "Error in geting Genre");
            }
        }

        public IEnumerable<GenreDM> GetGenres()
        {
            List<GenreDM> result = new List<GenreDM>();

            foreach (Genre g in UOW.Genres.GetAll())
            {
                result.Add(new GenreDM
                {
                    GenreID = g.GenreID,
                    Name = g.Name
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
