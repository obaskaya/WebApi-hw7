using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using WebApi.Application.BookOperations.Commands.DeleteComand;
using WebApi.UnitTests.TestsSetup;

namespace WebApi.UnitTests.Application.AuthorOperations.Commands.DeleteAuthor
{
	public class DeleteAuthorCommandValidatorTest : IClassFixture<CommonTestFixture>
	{
		[Theory]
		[InlineData(-10)]
		public void WhenInvalidId_Validator_ShouldBeReturnErrors(int authorId)
		{
			//arrange(Hazırlık)
			DeleteAuthorCommand command = new DeleteAuthorCommand(null);
			command.AuthorId = authorId;

			var validator = new DeleteAuthorCommandValidator();
			var result = validator.Validate(command);

			//act & assert (çalıştırma)
			result.Errors.Count.Should().BeGreaterThan(0);
		}
	}
}
