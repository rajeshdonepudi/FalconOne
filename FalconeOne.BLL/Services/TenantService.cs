using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Contracts;
using FalconOne.Helpers.Helpers;
using Microsoft.AspNetCore.Http;

namespace FalconeOne.BLL.Services
{
    public class TenantService : ITenantService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppConfigService _appConfigService;

        public TenantService(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, IAppConfigService appConfigService)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            _appConfigService = appConfigService;
        }
        public async Task<Guid> GetTenantId()
        {
            string referer = _httpContextAccessor.HttpContext.Request.Headers["Referer"].ToString();

            Uri uri = new(referer);
            string host = uri.Host;

            if (!string.IsNullOrEmpty(host))
            {
                bool useLocalTenantId = Convert.ToBoolean(await _appConfigService.GetValue("useLocalTenantId"));

                if (useLocalTenantId)
                {
                    return Guid.Parse(await _appConfigService.GetValue("localTenantId"));
                }
                else
                {
                    try
                    {
                        foreach (FalconOne.Models.Entities.Tenant item in await _unitOfWork.TenantRepository.GetAllAsync(CancellationToken.None))
                        {
                            await Console.Out.WriteLineAsync(item.Host);
                        }

                        FalconOne.Models.Entities.Tenant s = await _unitOfWork.TenantRepository.FindAsync(x => x.Host.Equals(host), CancellationToken.None);

                        FalconOne.Models.Entities.Tenant? tenant = await _unitOfWork.TenantRepository.FindAsync(x => x.Host.Trim().ToLower() == host.Trim().ToLower(), CancellationToken.None);
                        if (tenant is null)
                        {
                            throw new AppException("Unable to determine the tenant information.");
                        }
                        return tenant.Id;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            throw new AppException("Invalid request.");
        }
    }
}
