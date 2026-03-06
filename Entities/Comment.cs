namespace Homework2.Entities
{
    public class Comment: IHasId
    {
        public int Id { set; get; }
        public string Body { set; get; } = string.Empty;
        public DateTime Date { set; get; } = DateTime.Now; 
        public int BookId { set; get; }
        public Book? Book { set; get; }
    }
}
