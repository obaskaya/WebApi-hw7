using FluentAssertions;
using WebApi.Application.BookOperations.Commands.CreateCommand;
using WebApi.UnitTests.TestsSetup;
using static WebApi.Application.BookOperations.Commands.CreateCommand.CreateBookCommand;

namespace WebApi.UnitTests.Application.BookOperations.Commands.CreateBookCommands
{
	public class CreateBookCommandValidatorTest : IClassFixture<CommonTestFixture>
	{
		[Theory]
		[InlineData("Game of Thrones", 0, 0, 0)]
		[InlineData("Game of Thrones", 1, 0, 0)]
		[InlineData("Game of Thrones", 0, 1, 0)]
		[InlineData("Game of Thrones", 0, 0, 1)]
		[InlineData("", 0, 0, 0)]
		[InlineData("", 10, 0, 0)]
		[InlineData("", 0, 1, 0)]
		[InlineData("", 0, 0, 1)]
		[InlineData("Gam", 10, 1, 1)]
		[InlineData("Game", 10, 1, 0)]
		[InlineData("Game", 0, 1, 1)]
		[InlineData(" ", 10, 1, 1)]
		public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title, int pageCount, int genreId, int authorId)
		{
			//arrange
			CreateBookCommand command = new CreateBookCommand(null, null);
			command.Model = new CreateBookModel()
			{
				AuthorId = authorId,
				GenreID = genreId,
				PageCount = pageCount,
				PublishDate = DateTime.Now.AddYears(-1),
				Title = title,

			};

			//act
			CreateBookCommandValidator validator = new CreateBookCommandValidator();
			var result = validator.Validate(command);

			//assert
			result.Errors.Count.Should().BeGreaterThan(0);

		}
		[Fact]
		public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
		{
			//arrange
			CreateBookCommand command = new CreateBookCommand(null, null);
			command.Model = new CreateBookModel()
			{
				AuthorId = 1,
				GenreID = 1,
				PageCount = 100,
				PublishDate = DateTime.Now.Date,
				Title = "Game Of Thrones"
			};

			//act assert
			CreateBookCommandValidator validator = new CreateBookCommandValidator();
			var result = validator.Validate(command);

			result.Errors.Count.Should().BeGreaterThan(0);

		}
		// all true
		[Fact]
		public void WhenValidInputAreGiven_Validator_ShouldnotBeReturnError()
		{
			//arrange
			CreateBookCommand command = new CreateBookCommand(null, null);
			command.Model = new CreateBookModel()
			{
				AuthorId = 1,
				GenreID = 1,
				PageCount = 100,
				PublishDate = DateTime.Now.Date.AddYears(-1),
				Title = "Game Of Thrones"
			};

			//act assert
			CreateBookCommandValidator validator = new CreateBookCommandValidator();
			var result = validator.Validate(command);

			result.Errors.Count.Should().Be(0);

		}
	}
}
