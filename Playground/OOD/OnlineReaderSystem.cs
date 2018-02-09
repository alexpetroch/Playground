using System.Collections.Generic;

#pragma warning disable CS0169

namespace Playground.OOD
{
    class OnlineReaderSystem
    {
        Library library;

    }

    class User
    {

    }

    public class BookReaderProgress
    {
        int id;
        Book book;
        User user;

        void StartReading()
        {

        }

        void SetPage(int page)
        {

        }
    }


    public class Library
    {
        List<Book> _books = new List<Book>();
        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public IEnumerable<Book> Find(IBookSeach strategy, Dictionary<string, object> values)
        {
            return strategy.Seach(_books, values);
        }
    }

    public class Book
    {

    }

    public interface IBookSeach
    {
        IEnumerable<Book> Seach(IEnumerable<Book> books, Dictionary<string, object> parameters);
    }

    public class TitleSeach : IBookSeach
    {
        public IEnumerable<Book> Seach(IEnumerable<Book> books, Dictionary<string, object> parameters)
        {
            // search by title
            return new List<Book>();
        }
    }

    public class AuthorSeach : IBookSeach
    {

        public IEnumerable<Book> Seach(IEnumerable<Book> books, Dictionary<string, object> parameters)
        {
            // search by title
            return new List<Book>();
        }
    }

    public class CompoundSearch : IBookSeach
    {
        List<IBookSeach> _seaches = new List<IBookSeach>();
        public void AddSeach(IBookSeach bookSeach)
        {
            _seaches.Add(bookSeach);
        }

        public IEnumerable<Book> Seach(IEnumerable<Book> books, Dictionary<string, object> parameters)
        {
            IEnumerable<Book> res = books;
            foreach(var seachAlgo in _seaches)
            {
                res = seachAlgo.Seach(res, parameters);
            }

            return res;
        }
    }

}
