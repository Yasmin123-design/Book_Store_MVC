using BOOKS_.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace BOOKS_.Models.Repository
{
	public class BookDetailsRepository : IBookDetailsRepository
	{
		BookContext context;
		public BookDetailsRepository(BookContext con)
		{
			context = con;
		}
		public BookDetails GetById(int id)
		{
			var result = context.Books.Where(x => x.Id == id).Include(x => x.Category).FirstOrDefault();
			BookDetails details = new BookDetails() { Id = result.Id , 
				Title = result.Title , Description = result.Description , Author = result.Author,
			   CategoryName = result.Category.Name};
			return details;
		}
	}
}
