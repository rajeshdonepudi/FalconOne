namespace FalconeOne.BLL.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateJWTToken<T, T1>(T type, T1 claims);
    }
}
