using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public interface IRepository
    {
        IEnumerable<Book> GetAll();

        Book GetById(int Id);

        void Save(Book obj);

        void Edit(int Id, Book obj);

        void Delete(int Id);
    }
}
