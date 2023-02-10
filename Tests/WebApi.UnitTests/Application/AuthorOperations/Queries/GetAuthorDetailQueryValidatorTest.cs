using AutoMapper;
using FluentAssertions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetails;
using WebApi.Application.BookOperations.Commands.Query;
using WebApi.DBOperations;
using WebApi.UnitTests.TestsSetup;

namespace WebApi.UnitTests.Application.AuthorOperations.Queries
{
	public class GetAuthorDetailQueryValidatorTest : IClassFixture<CommonTestFixture>
	{
		private readonly BookStoreDbContext _context;
		private readonly IMapper _mapper;


		public GetAuthorDetailQueryValidatorTest(CommonTestFixture testFixture)
		{
			_context = testFixture.Context;
			_mapper = testFixture.Mapper;

		}
		[Theory]
		[InlineData(-10)]
		public void WhenInvalidId_Validator_ShouldBeReturnErrors(int authorId)
		{
			//arrange(Hazırlık)
			GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
			query.AuthorId = authorId;

			var validator = new GetAuthorDetailQueryValidator();
			var result = validator.Validate(query);

			//act & assert (çalıştırma)
			result.Errors.Count.Should().BeGreaterThan(0);
		}

	}
}
