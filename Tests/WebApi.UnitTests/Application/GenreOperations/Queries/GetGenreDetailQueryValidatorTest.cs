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
	public class GetGenreDetailQueryValidatorTest : IClassFixture<CommonTestFixture>
	{
		private readonly BookStoreDbContext _context;
		private readonly IMapper _mapper;


		public GetGenreDetailQueryValidatorTest(CommonTestFixture testFixture)
		{
			_context = testFixture.Context;
			_mapper = testFixture.Mapper;

		}
		[Theory]
		[InlineData(-10)]
		public void WhenInvalidId_Validator_ShouldBeReturnErrors(int genreId)
		{
			//arrange(Hazırlık)
			GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
			query.GenreId = genreId;

			var validator = new GetGenreDetailQueryValidator();
			var result = validator.Validate(query);

			//act & assert (çalıştırma)
			result.Errors.Count.Should().BeGreaterThan(0);
		}

	}
}
