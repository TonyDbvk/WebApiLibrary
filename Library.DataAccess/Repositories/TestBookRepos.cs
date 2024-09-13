using Library.DataAccess.Interfaces;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Repositories
{
    public class TestBookRepos 
    {
        private List<Book> _books = new List<Book> {
            //new Book(){Id = Guid.NewGuid(),Author = new Author(),Title = "Nikitos",ISBN ="2", Description = "Legenda"},
            //new Book(){Id = Guid.NewGuid(),Author = new Author(),Title = "Toha"  }
        };

        public async Task<Guid> Add(Book book)
        {
            _books.Add(book);
            return book.Id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);

            if (book != null) { 
                _books.Remove(book);
            }
            return id;
        }

        public async Task<List<Book>> GetAll()
        {
            return _books;
        }

        public async Task<Book> GetById(Guid id)
        {
            return _books.FirstOrDefault(b => b.Id == id)! ;
        }

        public Task<Guid> Update(Book book)
        {
            throw new NotImplementedException();
        }


    }
}
