namespace FalconeOne.BLL.DTOs
{
    public class VerifyEmailDTO
    {
        public string UserId { get; set; }
        public string EmailConfirmationToken { get; set; }
    }
}
