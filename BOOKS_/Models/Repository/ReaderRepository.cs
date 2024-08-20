namespace BOOKS_.Models.Repository
{
    public class ReaderRepository : IReaderRepository
    {
        BookContext context;
        IBookReaderRepository bookReaderRepository;
        public ReaderRepository(BookContext con , IBookReaderRepository bookReaderRepository)
        {
            context = con;
            this.bookReaderRepository = bookReaderRepository;
        }
        public void Delete(int id)
        {
 
            Reader reader = GetById(id);
            List<ReaderBook> readerBooks = bookReaderRepository.GetById(id);
            context.RemoveRange(readerBooks);
            context.Remove(reader);
            context.SaveChanges();
        }

        public List<Reader> GetAll()
        {
            return context.Readers.ToList();
        }

        public Reader GetById(int id)
        {
            return context.Readers.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Insert(Reader reader)
        {
            context.Add(reader);
            context.SaveChanges();
        }

        public void Update(int id, Reader reader)
        {
            Reader newreader = GetById(id);
            newreader.Name = reader.Name;
            newreader.Age = reader.Age;
            newreader.Image = reader.Image;
            context.SaveChanges();
        }


	}
}
