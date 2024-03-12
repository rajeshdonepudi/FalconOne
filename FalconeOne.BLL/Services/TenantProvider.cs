using FalconeOne.BLL.Helpers;
using FalconeOne.BLL.Interfaces;
using FalconOne.DAL.Contracts;
using FalconOne.Helpers.Helpers;
using Microsoft.AspNetCore.Http;

namespace FalconeOne.BLL.Services
{
    public class TenantProvider : ITenantProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppConfigService _appConfigService;

        public TenantProvider(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, IAppConfigService appConfigService)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            _appConfigService = appConfigService;
        }

        public async Task<Guid> GetTenantId()
        {
            bool useLocalTenantId = Convert.ToBoolean(await _appConfigService.GetValueAsync("useLocalTenantId"));

            if (useLocalTenantId)
            {
                return Guid.Parse(await _appConfigService.GetValueAsync("localTenantId"));
            }
            else
            {
                string referer = _httpContextAccessor.HttpContext.Request.Headers["Referer"].ToString();

                Uri uri = new(referer);

                if (string.IsNullOrEmpty(uri.Host))
                {
                    throw new ApiException(ErrorMessages.INVALID_REQUEST);
                }

                var tenant = await _unitOfWork.TenantRepository.FindAsync(x => x.Host.Equals(uri.Host), CancellationToken.None);

                if (tenant is null)
                {
                    throw new ApiException(ErrorMessages.INVALID_REQUEST);
                }
                return tenant.Id;
            }
            throw new ApiException(ErrorMessages.INVALID_REQUEST);
        }
    }
}
