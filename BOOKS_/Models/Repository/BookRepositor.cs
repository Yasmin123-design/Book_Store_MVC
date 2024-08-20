namespace BOOKS_.Models.Repository
{
    public class BookRepositor : IBookRepository
    {
        IBookReaderRepository bookReaderRepository;
        BookContext context;
        public BookRepositor(BookContext con , IBookReaderRepository bookReaderRepository)
        {
            context = con;
            this.bookReaderRepository = bookReaderRepository;
        }
        public void Delete(int id)
        {
            List<ReaderBook> readerBooks = bookReaderRepository.GetById(id);
            Book book = GetById(id);
            context.RemoveRange(readerBooks);
            context.Remove(book);
            context.SaveChanges();
        }

        public List<Book> GetAll()
        {
            return context.Books.ToList();
        }

        public Book GetById(int id)
        {
            return context.Books.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Insert(Book book)
        {
            context.Add(book);
            context.SaveChanges();
        }

        public void Update(int id, Book book)
        {
            Book newbook = GetById(id);
            newbook.Title = book.Title;
            newbook.Description = book.Description;
            newbook.Author = book.Author;
            newbook.AddOn = book.AddOn;
            newbook.CategoryId = book.CategoryId;
            context.SaveChanges();
        }
        public List<Book> GetBooksInSpecificCategory(int categoryId)
        {
            return context.Books.Where(x => x.CategoryId == categoryId).ToList();
        }
	}
}
