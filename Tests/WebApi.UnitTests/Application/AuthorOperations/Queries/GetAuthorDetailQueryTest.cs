using AutoMapper;
using FluentAssertions;
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
	public class GetAuthorDetailQueryTest : IClassFixture<CommonTestFixture>
	{
		private readonly IBookStoreDbContext _context;
		private readonly IMapper _mapper;


		public GetAuthorDetailQueryTest(CommonTestFixture testFixture)
		{
			_context = testFixture.Context;
			_mapper = testFixture.Mapper;

		}
		[Theory]

		[InlineData(200)]
		public void WhenAuthorIsNull_InvalidOperationException_ShouldBeReturn(int authorId)
		{
			// setting bookId 
			GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
			query.AuthorId = authorId;

			//act & assert (çalıştırma)
			FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Author couldn't found");
		}

	}
}
