using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using WebApi.UnitTests.TestsSetup;

namespace WebApi.UnitTests.Application.GenreOperations.Commands.DeleteGenre
{
	public class DeleteGenreCommandValidatorTest : IClassFixture<CommonTestFixture>
	{
		[Theory]
		[InlineData(-10)]
		public void WhenInvalidId_Validator_ShouldBeReturnErrors(int genreId)
		{
			//arrange(Hazırlık)
			DeleteGenreCommand command = new DeleteGenreCommand(null);
			command.GenreId = genreId;

			var validator = new DeleteGenreCommandValidator();
			var result = validator.Validate(command);

			//act & assert (çalıştırma)
			result.Errors.Count.Should().BeGreaterThan(0);
		}
	}
}
