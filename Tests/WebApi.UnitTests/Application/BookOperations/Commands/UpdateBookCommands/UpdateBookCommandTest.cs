using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.BookOperations.Commands.CreateCommand;
using WebApi.Application.BookOperations.Commands.UpdateCommand;
using WebApi.DBOperations;
using WebApi.Entitites;
using WebApi.UnitTests.TestsSetup;
using static WebApi.Application.BookOperations.Commands.CreateCommand.CreateBookCommand;
using static WebApi.Application.BookOperations.Commands.UpdateCommand.UpdateBookCommand;

namespace WebApi.UnitTests.Application.BookOperations.Commands.UpdateBookCommands
{
	public class UpdateBookCommandTest : IClassFixture<CommonTestFixture>
	{
		private readonly BookStoreDbContext _context;


		public UpdateBookCommandTest(CommonTestFixture testFixture)
		{
			_context = testFixture.Context;

		}

		//this is a  test
		// This will give error because faker will provide us 20 books [InlineData(20)]
		[Theory]
		[InlineData(500)]
		public void WhenBookIsNull_InvalidOperationException_ShouldBeReturn(int bookId)
		{
			// setting bookId 
			UpdateBookCommand command = new UpdateBookCommand(_context);
			command.BookId = bookId;

			//act & assert (çalıştırma)
			FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book is not found");
		}
	}

}
