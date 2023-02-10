using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.BookOperations.Commands.Query;
using WebApi.DBOperations;
using WebApi.UnitTests.TestsSetup;

namespace WebApi.UnitTests.Application.BookOperations.Queries
{
	public class GetBookDetailQueryTest : IClassFixture<CommonTestFixture>
	{
		private readonly BookStoreDbContext _dbContext;
		private readonly IMapper _mapper;


		public GetBookDetailQueryTest(CommonTestFixture testFixture)
		{
			_dbContext = testFixture.Context;
			_mapper = testFixture.Mapper;

		}
		[Theory]
		
		[InlineData(700)]
		public void WhenBookIsNull_InvalidOperationException_ShouldBeReturn(int bookId)
		{
			// setting bookId 
			GetBookDetailQuery query = new GetBookDetailQuery(_dbContext, _mapper);
			query.BookId = bookId;
			
			//act & assert (çalıştırma)
			FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book is not found");
		}

	}
}
