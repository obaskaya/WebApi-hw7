using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.BookOperations.Commands.DeleteComand;
using WebApi.Application.BookOperations.Commands.UpdateCommand;
using WebApi.UnitTests.TestsSetup;

namespace WebApi.UnitTests.Application.BookOperations.Commands.DeleteBookCommands
{
	public class DeleteBookCommandValidatorTest : IClassFixture<CommonTestFixture>
	{
		[Theory]
		[InlineData(-10)]
		public void WhenInvalidId_Validator_ShouldBeReturnErrors(int bookId)
		{
			//arrange(Hazırlık)
			DeleteBookCommand command = new DeleteBookCommand(null);
			command.BookId = bookId;

			var validator = new DeleteBookCommandValidator();
			var result = validator.Validate(command);

			//act & assert (çalıştırma)
			result.Errors.Count.Should().BeGreaterThan(0);
		}
	}
}
