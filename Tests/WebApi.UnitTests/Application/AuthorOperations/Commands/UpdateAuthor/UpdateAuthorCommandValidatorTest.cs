using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.UnitTests.TestsSetup;

namespace WebApi.UnitTests.Application.AuthorOperations.Commands.UpdateAuthor
{
	public class UpdateAuthorCommandValidatorTest : IClassFixture<CommonTestFixture>
	{
		[Theory]
		[InlineData(" ")]
		public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name)
		{
			//arrange
			UpdateAuthorCommand command = new UpdateAuthorCommand(null);
			command.Model = new UpdateAuthorModel()
			{
				Name = name

			};

			//act
			UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
			var result = validator.Validate(command);

			//assert
			result.Errors.Count.Should().BeGreaterThan(0);

		}
	}
}
