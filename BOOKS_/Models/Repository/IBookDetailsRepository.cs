using BOOKS_.ViewModels;

namespace BOOKS_.Models.Repository
{
	public interface IBookDetailsRepository
	{
		BookDetails GetById(int id);
	}
}
