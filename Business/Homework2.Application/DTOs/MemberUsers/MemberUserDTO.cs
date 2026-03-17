namespace Homework2.Application.DTOs.MemberUsers
{
    public class MemberUserDTO
    {
        public int Id { set; get; }
        public required string Name { set; get; } = string.Empty;
        public string LastName { set; get; } = string.Empty;
        public string PhoneNumber { set; get; } = string.Empty;
        public string Email { set; get; } = string.Empty;
        public string Location { set; get; } = string.Empty;
    }
}
