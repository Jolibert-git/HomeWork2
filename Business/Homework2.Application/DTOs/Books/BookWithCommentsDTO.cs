namespace Homework2.Application.DTOs.Books
{
    public class BookWithCommentsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime PublicationYear { get; set; }
        public short NumberPage { get; set; }
        public string Category { get; set; } = string.Empty; // Puedes pasarlo a string para que el cliente lo entienda mejor
        public string Publisher { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        // Aquí está la clave: una lista del DTO de comentarios, no de la entidad
        public List<BodyCommentDTO> Comments { get; set; } = new List<BodyCommentDTO>();
    }

    public class BodyCommentDTO
    {
        public DateTime Date { get; set; }
        public string Body { get; set; } = string.Empty;
    }

}
