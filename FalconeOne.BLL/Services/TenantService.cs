using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Utilities.Exceptions;

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
            var host = _httpContextAccessor.HttpContext.Request.Host.Host;

            if (!string.IsNullOrEmpty(host))
            {
                if (host == "localhost")
                {
                    return Guid.Parse(await _appConfigService.GetValue("DefaultTenantId"));
                }
                else
                {
                    var tenant = await _unitOfWork.TenantRepository.QueryAsync(x => x.Host == host);

                    if (tenant is null)
                    {
                        throw new AppException("Unable to determine the tenant information.");
                    }
                    return tenant.Id;
                }
            }
            throw new AppException("Invalid request.");
        }
    }
}
