﻿using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.Commands.DeleteComand
{
    public class DeleteBookCommand
    {
        private readonly IBookStoreDbContext _dbContext;
        public int BookId { get; set; }
        public DeleteBookCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var book = _dbContext.Books.FirstOrDefault(x => x.Id == BookId);
            if (book is null)
            {
                throw new InvalidOperationException("Book is not found");
            }

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();

        }
    }
}