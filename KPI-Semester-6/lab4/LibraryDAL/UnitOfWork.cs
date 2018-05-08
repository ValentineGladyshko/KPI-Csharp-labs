using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class UnitOfWork : IDisposable
    {
        private LibraryContext db = new LibraryContext();
        private BookRepository bookRepository;
        private AuthorRepository authorRepository;
        private BookAuthorRepository bookAuthorRepository;
        private UserRepository userRepository;
        private BookUserRepository bookUserRepository;
        private GenreRepository genreRepository;

        public BookRepository Books
        {
            get
            {
                if (bookRepository == null)
                    bookRepository = new BookRepository(db);
                return bookRepository;
            }
        }

        public AuthorRepository Authors
        {
            get
            {
                if (authorRepository == null)
                    authorRepository = new AuthorRepository(db);
                return authorRepository;
            }
        }

        public BookAuthorRepository BookAuthors
        {
            get
            {
                if (bookAuthorRepository == null)
                    bookAuthorRepository = new BookAuthorRepository(db);
                return bookAuthorRepository;
            }
        }

        public UserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public BookUserRepository BookUsers
        {
            get
            {
                if (bookUserRepository == null)
                    bookUserRepository = new BookUserRepository(db);
                return bookUserRepository;
            }
        }

        public GenreRepository Genres
        {
            get
            {
                if (genreRepository == null)
                    genreRepository = new GenreRepository(db);
                return genreRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
