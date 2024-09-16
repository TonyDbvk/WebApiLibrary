﻿using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Repositories
{
    internal class BookInstanceRepository
    {
        private readonly LibraryContext _context;

        public BookInstanceRepository(LibraryContext context)
        {
            _context = context;
        }
        public async Task<List<Book>> GetAll()
        {
            return await _context.BookInstances
                        .Include(b => b.Book)
                        .ToListAsync();
        }
        public async Task<Book> GetById(Guid id)
        {
            return await _context.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Book> GetByISBN(string isbn)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.ISBN == isbn);
        }

        public async Task<Guid> Update(Book book)
        {
            var existingBook = await _context.Books.FindAsync(book.Id);
            if (existingBook == null)
            {
                throw new ArgumentException("Book not found.");
            }

            _context.Entry(existingBook).CurrentValues.SetValues(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }
        public async Task<Guid> Add(BookInstance bookInstance)
        {
            _context.BookInstances.Add(bookInstance);
            await _context.SaveChangesAsync();
            return bookInstance.Id;
        }

        public async Task<Guid> Update(BookInstance bookInstance)
        {
            _context.BookInstances.Add(bookInstance);
            await _context.SaveChangesAsync();
            return bookInstance.Id;
        }


        public async Task<Guid> Delete(Guid id)
        {
            var bookInstance = await _context.BookInstances.FindAsync(id);
            if (bookInstance == null)
            {
                throw new ArgumentException("BokInstance not found.");
            }

            _context.BookInstances.Remove(bookInstance);
            await _context.SaveChangesAsync();
            return id;
        }

       


    }
}