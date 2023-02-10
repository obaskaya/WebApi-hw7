using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.BookOperations.Commands.CreateCommand;
using WebApi.UnitTests.TestsSetup;
using static WebApi.Application.BookOperations.Commands.CreateCommand.CreateBookCommand;

namespace WebApi.UnitTests.Application.AuthorOperations.Commands.CreateAuthor
{
	public class CreateAuthorCommandValidatorTest : IClassFixture<CommonTestFixture>
	{
		[Theory]
		[InlineData(" ")]
		public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name)
		{
			//arrange
			CreateAuthorCommand command = new CreateAuthorCommand(null);
			command.Model = new CreateAuthorModel()
			{
				Name= name

			};

			//act
			CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
			var result = validator.Validate(command);

			//assert
			result.Errors.Count.Should().BeGreaterThan(0);

		}
	}
}
