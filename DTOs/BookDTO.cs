namespace Homework2.DTOs
{
    public class BookDTO
    {
        public int Id { set; get; }
        public string Title { set; get; } = string.Empty;
        public short NumberPage { set; get; }
        public int WriterId { set; get; }
    }
}
