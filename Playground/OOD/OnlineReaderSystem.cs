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

    class BookReaderProgress
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


    class Library
    {
        Dictionary<int, Book> library;
        public void AddBook(Book book)
        {

        }

        public Book Find(IBookSeach strategy, Dictionary<string, object> values)
        {
            return strategy.Seach(values);
        }
    }

    class Book
    {

    }

    interface IBookSeach
    {
        Book Seach(Dictionary<string, object> parameters);
        
    }

    class TitleSeach : IBookSeach
    {
        public Book Seach(Dictionary<string, object> parameters)
        {
            throw new System.NotImplementedException();
        }
    }

    class AuthorSeach : IBookSeach
    {
        public Book Seach(Dictionary<string, object> parameters)
        {
            throw new System.NotImplementedException();
        }
    }

}
