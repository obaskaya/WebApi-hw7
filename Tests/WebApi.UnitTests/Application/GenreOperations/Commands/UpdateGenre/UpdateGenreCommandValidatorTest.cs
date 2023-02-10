using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.UnitTests.TestsSetup;

namespace WebApi.UnitTests.Application.GenreOperations.Commands.UpdateGenre
{
	public class UpdateGenreCommandValidatorTest : IClassFixture<CommonTestFixture>
	{
		[Theory]
		[InlineData(" ")]
		public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name)
		{
			//arrange
			UpdateGenreCommand command = new UpdateGenreCommand(null);
			command.Model = new UpdateGenreModel()
			{
				Name = name

			};

			//act
			UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
			var result = validator.Validate(command);

			//assert
			result.Errors.Count.Should().BeGreaterThan(0);

		}
	}
}
