using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.BookOperations.Commands.DeleteComand;
using WebApi.Application.BookOperations.Commands.UpdateCommand;
using WebApi.DBOperations;
using WebApi.UnitTests.TestsSetup;

namespace WebApi.UnitTests.Application.BookOperations.Commands.DeleteBookCommands
{
	public class DeleteBookCommandTest : IClassFixture<CommonTestFixture>
	{
		private readonly BookStoreDbContext _context;


		public DeleteBookCommandTest(CommonTestFixture testFixture)
		{
			_context = testFixture.Context;

		}
		[Theory]
		
		[InlineData(400)]
		public void WhenBookIsNull_InvalidOperationException_ShouldBeReturn(int bookId)
		{
			// setting bookId 
			DeleteBookCommand command = new DeleteBookCommand(_context);
			command.BookId = bookId;

			//act & assert (çalıştırma)
			FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book is not found");
		}
	}
}