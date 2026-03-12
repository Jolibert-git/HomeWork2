namespace Homework2.DTOs
{
    public class AuthorWithBooksDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<TitleBookDTO> Books { get; set; } = new List<TitleBookDTO>();
    }

    public class TitleBookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
