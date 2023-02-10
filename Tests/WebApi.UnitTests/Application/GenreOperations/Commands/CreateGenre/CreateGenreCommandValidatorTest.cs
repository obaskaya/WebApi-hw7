using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.UnitTests.TestsSetup;

namespace WebApi.UnitTests.Application.GenreOperations.Commands.CreateGenre
{
	public class CreateGenreCommandValidatorTest : IClassFixture<CommonTestFixture>
	{
		[Theory]
		[InlineData(" ")]
		public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name)
		{
			//arrange
			CreateGenreCommand command = new CreateGenreCommand(null);
			command.Model = new CreateGenreModel()
			{
				Name = name

			};

			//act
			CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
			var result = validator.Validate(command);

			//assert
			result.Errors.Count.Should().BeGreaterThan(0);

		}
	}
}
