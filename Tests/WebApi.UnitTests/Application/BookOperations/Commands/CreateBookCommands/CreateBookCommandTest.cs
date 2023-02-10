using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.BookOperations.Commands.CreateCommand;
using WebApi.DBOperations;
using WebApi.Entitites;
using WebApi.UnitTests.TestsSetup;
using Xunit;
using static WebApi.Application.BookOperations.Commands.CreateCommand.CreateBookCommand;

namespace WebApi.UnitTests.Application.BookOperations.Commands.CreateCommands
{
	public class CreateBookCommandTest : IClassFixture<CommonTestFixture>
	{
		private readonly BookStoreDbContext _context;
		private readonly IMapper _mapper;


		public CreateBookCommandTest(CommonTestFixture testFixture)
		{
			_context = testFixture.Context;
			_mapper = testFixture.Mapper;

		}
		//this is a test
		
		[Fact]
		public void WhenValidInputsAreGiven_ShouldBeCreated()
		{
			//arrange(Hazırlık)
			CreateBookCommand command = new CreateBookCommand(_context, _mapper);

			CreateBookModel model = new CreateBookModel() { Title = "WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn", PageCount = 100, PublishDate = DateTime.Now.Date.AddYears(-1), GenreID = 1, AuthorId = 1 };
			command.Model = model;


			//act 
			FluentActions.Invoking(() => command.Handle()).Invoke();

			//assert
			var book = _context.Books.FirstOrDefault(book => book.Title == model.Title);
			book.PublishDate.Should().Be(model.PublishDate);
			book.Title.Should().Be(model.Title);
			book.GenreId.Should().Be(model.GenreID);
			book.AuthorId.Should().Be(model.AuthorId);
			book.PageCount.Should().Be(model.PageCount);
		}
		[Fact]
		public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
		{
			//arrange(Hazırlık)
			var book = new Book() { Title = "WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn", PageCount = 100, PublishDate = new System.DateTime(2000, 1, 1), GenreId = 1, AuthorId = 1 };
			_context.Books.Add(book);
			_context.SaveChanges();

			CreateBookCommand command = new CreateBookCommand(_context, _mapper);
			command.Model = new CreateBookModel() { Title = book.Title };

			//act & assert (çalıştırma)
			FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book is already in database");
		}

	}
}
