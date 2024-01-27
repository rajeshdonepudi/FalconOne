using FalconeOne.BLL.Helpers;
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
            bool useLocalTenantId = Convert.ToBoolean(await _appConfigService.GetValue("useLocalTenantId"));

            if (useLocalTenantId)
            {
                return Guid.Parse(await _appConfigService.GetValue("localTenantId"));
            }
            else
            {
                string referer = _httpContextAccessor.HttpContext.Request.Headers["Referer"].ToString();

                Uri uri = new(referer);

                if (string.IsNullOrEmpty(uri.Host))
                {
                    throw new ApiException(MessageHelper.INVALID_REQUEST);
                }

                var tenant = await _unitOfWork.TenantRepository.FindAsync(x => x.Host.Equals(uri.Host), CancellationToken.None);

                if (tenant is null)
                {
                    throw new ApiException(MessageHelper.INVALID_REQUEST);
                }
                return tenant.Id;
            }
            throw new ApiException(MessageHelper.INVALID_REQUEST);
        }
    }
}
