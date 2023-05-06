using FalconeOne.BLL.Helpers;
using Utilities.DTOs;
using Utilities.Helpers;

namespace FalconeOne.BLL.Interfaces
{
    public interface IRequestInformationService
    {
        Task SaveRequestInfoAsync(RequestInformationDTO model);

        Task<ApiResponse> GetAllAsync(PageParams pageParams);
    }
}
