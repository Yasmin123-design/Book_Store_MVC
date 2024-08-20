namespace BOOKS_.Models.Repository
{
    public interface IReaderRepository
    {
        List<Reader> GetAll();
        Reader GetById(int id);
        void Insert(Reader reader);
        void Update(int id, Reader reader);
        void Delete(int id);

        
    }
}
