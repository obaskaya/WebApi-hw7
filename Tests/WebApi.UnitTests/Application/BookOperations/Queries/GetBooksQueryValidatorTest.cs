using AutoMapper;
using FluentAssertions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.BookOperations.Commands.Query;
using WebApi.Application.BookOperations.Commands.UpdateCommand;
using WebApi.DBOperations;
using WebApi.UnitTests.TestsSetup;

namespace WebApi.UnitTests.Application.BookOperations.Queries
{
	public class GetBooksQueryValidatorTest : IClassFixture<CommonTestFixture>
	{
		private readonly BookStoreDbContext _context;
		private readonly IMapper _mapper;


		public GetBooksQueryValidatorTest(CommonTestFixture testFixture)
		{
			_context = testFixture.Context;
			_mapper = testFixture.Mapper;

		}
		[Theory]
		[InlineData(-10)]
		public void WhenInvalidId_Validator_ShouldBeReturnErrors(int bookId)
		{
			//arrange(Hazırlık)
			GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
			query.BookId = bookId;

			var validator = new GetBooksQueryValidator();
			var result = validator.Validate(query);

			//act & assert (çalıştırma)
			result.Errors.Count.Should().BeGreaterThan(0);
		}
	
	}
}
