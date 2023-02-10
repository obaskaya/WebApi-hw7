using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetails;
using WebApi.Application.GenreOperations.Queries.GetGenreDetails;
using WebApi.DBOperations;
using WebApi.UnitTests.TestsSetup;

namespace WebApi.UnitTests.Application.GenreOperations.Queries
{
	public class GetGenreDetailQueryTest : IClassFixture<CommonTestFixture>
	{
		private readonly IBookStoreDbContext _context;
		private readonly IMapper _mapper;


		public GetGenreDetailQueryTest(CommonTestFixture testFixture)
		{
			_context = testFixture.Context;
			_mapper = testFixture.Mapper;

		}
		[Theory]

		[InlineData(200)]
		public void WhenAuthorIsNull_InvalidOperationException_ShouldBeReturn(int genreId)
		{
			// setting bookId 
			GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
			query.GenreId = genreId;

			//act & assert (çalıştırma)
			FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Genre couldn't found");
		}

	}
}
