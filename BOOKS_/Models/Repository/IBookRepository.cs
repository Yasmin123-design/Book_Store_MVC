namespace BOOKS_.Models.Repository
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book GetById(int id);
        void Insert(Book book);
        void Update(int id, Book book);
        void Delete(int id);
        List<Book> GetBooksInSpecificCategory(int categoryId);
    }
}
