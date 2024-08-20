namespace BOOKS_.Models.Repository
{
	public interface IBookReaderRepository
	{
		List<ReaderBook> DetailsReadersWithBooks();
		List<ReaderBook> MoreDetails(int id);
		List<ReaderBook> GetById(int id);
		List<ReaderBook> RemoveByCategoryId(int categoryId);
	}
}
