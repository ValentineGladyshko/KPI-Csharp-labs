using System.Collections.Generic;
using System.Data.Entity;

namespace Library.DAL
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }

    public class BookRepository : IRepository<Book>
    {
        private LibraryContext db;

        public BookRepository(LibraryContext context)
        {
            this.db = context;
        }

        public IEnumerable<Book> GetAll()
        {
            return db.Books.Include(b => b.Genre);
        }

        public Book Get(int id)
        {
            return db.Books.Find(id);
        }

        public void Create(Book book)
        {
            db.Books.Add(book);
        }

        public void Update(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Book book = db.Books.Find(id);
            if (book != null)
                db.Books.Remove(book);
        }
    }

    public class AuthorRepository : IRepository<Author>
    {
        private LibraryContext db;

        public AuthorRepository(LibraryContext context)
        {
            this.db = context;
        }

        public IEnumerable<Author> GetAll()
        {
            return db.Authors;
        }

        public Author Get(int id)
        {
            return db.Authors.Find(id);
        }

        public void Create(Author author)
        {
            db.Authors.Add(author);
        }

        public void Update(Author author)
        {
            db.Entry(author).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Author author = db.Authors.Find(id);
            if (author != null)
                db.Authors.Remove(author);
        }
    }

    public class BookAuthorRepository : IRepository<BookAuthor>
    {
        private LibraryContext db;

        public BookAuthorRepository(LibraryContext context)
        {
            this.db = context;
        }

        public IEnumerable<BookAuthor> GetAll()
        {
            return db.BookAuthors.Include(b => b.Book).Include(b => b.Author);
        }

        public BookAuthor Get(int id)
        {
            return db.BookAuthors.Find(id);
        }

        public void Create(BookAuthor bookAuthor)
        {
            db.BookAuthors.Add(bookAuthor);
        }

        public void Update(BookAuthor bookAuthor)
        {
            db.Entry(bookAuthor).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            BookAuthor bookAuthor = db.BookAuthors.Find(id);
            if (bookAuthor != null)
                db.BookAuthors.Remove(bookAuthor);
        }
    }

    public class UserRepository : IRepository<User>
    {
        private LibraryContext db;

        public UserRepository(LibraryContext context)
        {
            this.db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public void Create(User user)
        {
            db.Users.Add(user);
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }
    }

    public class BookUserRepository : IRepository<BookUser>
    {
        private LibraryContext db;

        public BookUserRepository(LibraryContext context)
        {
            this.db = context;
        }

        public IEnumerable<BookUser> GetAll()
        {
            return db.BookUsers.Include(b => b.Book).Include(b => b.User);
        }

        public BookUser Get(int id)
        {
            return db.BookUsers.Find(id);
        }

        public void Create(BookUser bookUser)
        {
            db.BookUsers.Add(bookUser);
        }

        public void Update(BookUser bookUser)
        {
            db.Entry(bookUser).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            BookUser bookUser = db.BookUsers.Find(id);
            if (bookUser != null)
                db.BookUsers.Remove(bookUser);
        }
    }

    public class GenreRepository : IRepository<Genre>
    {
        private LibraryContext db;

        public GenreRepository(LibraryContext context)
        {
            this.db = context;
        }

        public IEnumerable<Genre> GetAll()
        {
            return db.Genres;
        }

        public Genre Get(int id)
        {
            return db.Genres.Find(id);
        }

        public void Create(Genre genre)
        {
            db.Genres.Add(genre);
        }

        public void Update(Genre genre)
        {
            db.Entry(genre).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Genre genre = db.Genres.Find(id);
            if (genre != null)
                db.Genres.Remove(genre);
        }
    }
}
