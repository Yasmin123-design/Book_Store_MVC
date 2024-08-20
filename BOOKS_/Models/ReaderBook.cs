
namespace BOOKS_.Models
{
    public class ReaderBook
    {
        public int ReaderId { get; set; }
        public int BookId { get; set; }
        public DateTime DateTime { get; set; }
        public Reader Reader { get; set; }
        public Book Book { get; set; }

    }
}
