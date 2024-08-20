using Microsoft.EntityFrameworkCore;

namespace BOOKS_.Models.Repository
{
	public class BookReaderRepository : IBookReaderRepository
	{
		BookContext context;
		public BookReaderRepository(BookContext con)
		{
			context = con;
		}
		public List<ReaderBook> DetailsReadersWithBooks()
		{
			return context.ReaderBooks.Include(x => x.Reader).Include(x => x.Book).ToList();
		}
		public List<ReaderBook> MoreDetails(int id)
		{
			return context.ReaderBooks.Include(x => x.Reader)
				.Include(x => x.Book).Include(x => x.Book.Category).Where(x => x.Reader.Id == id).ToList();
		}
		public List<ReaderBook> GetById(int id)
		{
			return context.ReaderBooks.Where(x => x.ReaderId == id).ToList();
		}
		public List<ReaderBook> RemoveByCategoryId(int categoryId)
		{ 
			return	context.ReaderBooks.Where(x => x.Book.Category.Id == categoryId).ToList();
		}
	}
}
