namespace FalconeOne.BLL.DTOs
{
    public class BaseDTO
    {
        public string Message { get; set; }
        public List<BusinessError> Errors { get; set; }
    }

}
