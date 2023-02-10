﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.Commands.Query
{
	public class GetBookDetailQuery
	{
		private readonly IBookStoreDbContext _dbContext;
		private readonly IMapper _mapper;

		public int BookId { get; set; }

		public GetBookDetailQuery(IBookStoreDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}
		public BookDetailViewModel Handle()
		{
			var book = _dbContext.Books.Include(x => x.Genre).Include(x => x.Author).Where(x => x.Id == BookId).FirstOrDefault();

			if (book is null) { throw new InvalidOperationException("Book is not found"); }

			BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);

			return vm;
		}
	}
	public class BookDetailViewModel
	{
		public string Title { get; set; }
		public string Genre { get; set; }
		public int PageCount { get; set; }
		public string PublishDate { get; set; }
		public string Author { get; set; }
	}
}
