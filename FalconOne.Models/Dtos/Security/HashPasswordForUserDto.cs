namespace FalconOne.Models.DTOs.Security
{
    public record HashPasswordForUserDto
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
