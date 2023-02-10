using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.DBOperations;
using WebApi.UnitTests.TestsSetup;

namespace WebApi.UnitTests.Application.GenreOperations.Commands.CreateGenre
{
	public class CreateGenreCommandTest : IClassFixture<CommonTestFixture>
	{
		private readonly BookStoreDbContext _context;
		public CreateGenreCommandTest(CommonTestFixture testFixture)
		{
			_context = testFixture.Context;
		}
		//this is a test

		[Fact]
		public void WhenValidInputsAreGiven_ShouldBeCreated()
		{
			//arrange(Hazırlık)
			CreateGenreCommand command = new CreateGenreCommand(_context);

			CreateGenreModel model = new CreateGenreModel() { Name = "Documentary" };
			command.Model = model;


			//act 
			FluentActions.Invoking(() => command.Handle()).Invoke();

			//assert
			var genre = _context.Genres.FirstOrDefault(genre => genre.Name == model.Name);
			genre.Name.Should().Be(model.Name);

		}

	}
}
