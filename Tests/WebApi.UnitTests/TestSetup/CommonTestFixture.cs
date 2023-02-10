using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.TestsSetup
{
	public class CommonTestFixture
	{
		public BookStoreDbContext Context { get; set; }
		public IMapper Mapper { get; set; }
		public CommonTestFixture()
		{
			//Creating Context
			var options = new DbContextOptionsBuilder<BookStoreDbContext>().UseInMemoryDatabase(databaseName: "BookStoreDbContext").Options;
			Context = new BookStoreDbContext(options);

			//Making sure context is created
			Context.Database.EnsureCreated();

			Context.AddBooks();
			Context.AddGenres();
			Context.AddAuthors();
			Context.SaveChanges();

			Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();

		}
	}
}
