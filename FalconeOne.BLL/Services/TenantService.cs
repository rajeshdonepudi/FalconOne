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

            var uri = new Uri(referer);
            var host = uri.Host;

            if (!string.IsNullOrEmpty(host))
            {
                if (host == "localhost")
                {
                    return Guid.Parse(await _appConfigService.GetValue("DefaultTenantId"));
                }
                else
                {
                    try
                    {
                        foreach (var item in await _unitOfWork.TenantRepository.GetAllAsync())
                        {
                            await Console.Out.WriteLineAsync(item.Host);
                        }

                        var s = await _unitOfWork.TenantRepository.FindAsync(x => x.Host.Equals(host));

                        FalconOne.Models.Entities.Tenant? tenant = await _unitOfWork.TenantRepository.FindAsync(x => x.Host.Trim().ToLower() == host.Trim().ToLower());
                        if (tenant is null)
                        {
                            throw new AppException("Unable to determine the tenant information.");
                        }
                        return tenant.Id;
                    }
                    catch (Exception e)
                    {

                        throw;
                    }

                    
                }
            }
            throw new AppException("Invalid request.");
        }
    }
}
