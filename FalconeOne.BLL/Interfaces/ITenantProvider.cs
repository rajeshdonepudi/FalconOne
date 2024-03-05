namespace FalconeOne.BLL.Interfaces
{
    public interface ITenantProvider
    {
        Task<Guid> GetTenantId();
    }
}
