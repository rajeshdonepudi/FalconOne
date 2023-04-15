namespace FalconeOne.BLL.Interfaces
{
    public interface ITenantService
    {
        Task<Guid> GetTenantId();
    }
}
