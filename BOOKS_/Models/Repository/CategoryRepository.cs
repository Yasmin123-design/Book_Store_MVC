namespace BOOKS_.Models.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        IBookRepository bookRepository;
        IBookReaderRepository bookReaderRepository;
        BookContext context;
        public CategoryRepository(BookContext con , IBookRepository bookRepository , IBookReaderRepository bookReaderRepository)
        {
            context = con;
            this.bookRepository = bookRepository;
            this.bookReaderRepository = bookReaderRepository;
        }
        public void Delete(int id)
        {
            // List<ReaderBook> readerBooks = 
            List<Book> books = bookRepository.GetBooksInSpecificCategory(id);
            Category category = GetById(id);
            List<ReaderBook> readerBooks = bookReaderRepository.RemoveByCategoryId(id);
            context.RemoveRange(readerBooks);
            context.RemoveRange(books);
            context.Remove(category);
            context.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return context.Categories.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Insert(Category category)
        {
            context.Add(category);
            context.SaveChanges();
        }

        public void Update(int id, Category category)
        {
            Category newcategory = GetById(id);
            newcategory.Name = category.Name;
            context.SaveChanges();
        }
    }
}
