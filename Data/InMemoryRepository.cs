using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class InMemoryRepository : IRepository
    {
        private List<Book> _BookList;
        public InMemoryRepository()
        {
            _BookList = new List<Book>();

            _BookList.Add(new Book { Id = 1, Author = "Jack Roberts", CoverImage = "image1.jpg", Description = "A love story", Title = "Titanic on Plane", Price = 20.50});
            _BookList.Add(new Book { Id = 2, Author = "Blake Roberts", CoverImage = "image2.jpg", Description = "A thriller story", Title = "Monkey on Plane", Price = 120.50 });
            _BookList.Add(new Book { Id = 3, Author = "Tim cook", CoverImage = "image3.jpg", Description = "A horror story", Title = "Titanic on Plane", Price = 890.00 });
            _BookList.Add(new Book { Id = 4, Author = "Albert Smith", CoverImage = "image4.jpg", Description = "A love story", Title = "Titanic on Plane", Price = 67.00 });
            _BookList.Add(new Book { Id = 5, Author = "Jimmy Billy", CoverImage = "image5.jpg", Description = "A horror story", Title = "Titanic on Plane", Price = 93.50 });
        }
        
        
        
        public void Delete(int Id)
        {
            var obj = _BookList.FirstOrDefault(x => x.Id == Id);
            if (obj != null)
                _BookList.Remove(obj);
        }

        public void Edit(int Id, Book obj)
        {
            if (Id == obj.Id)
            {
                var curObj = _BookList.FirstOrDefault(x => x.Id == obj.Id);
                if (curObj != null)
                    _BookList[_BookList.FindIndex(x => x.Id == Id)] = obj;
            }
        }

        public IEnumerable<Book> GetAll()
        {
            return _BookList.OrderBy(x => x.Id);
        }

        public Book GetById(int Id)
        {
            return _BookList.FirstOrDefault(x => x.Id == Id);
        }

        public void Save(Book obj)
        {
            _BookList.Add(obj);
        }


        
    }
}
