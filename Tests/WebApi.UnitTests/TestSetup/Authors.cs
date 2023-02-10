using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DBOperations;
using WebApi.Entitites;

namespace WebApi.UnitTests.TestSetup
{
	public static class Authors
	{
		public static void AddAuthors(this BookStoreDbContext context)
		{
			context.Authors.AddRange(
				new Author
				{
					Name = "Tolstoy",
					BirthDay = "20.11.1910"
				},
				new Author
				{
					Name = "Orhan Pamuk",
					BirthDay = "07.06.1952"
				},
				new Author
				{
					Name = "Yaşar Kemal",
					BirthDay = "28.02.1923"
				},
				new Author
				{
					Name = "Sabahattin Ali",
					BirthDay = "25.02.1907"
				}
				);
		}
	}
}
