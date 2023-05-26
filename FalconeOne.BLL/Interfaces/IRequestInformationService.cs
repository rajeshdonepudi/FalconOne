using FalconeOne.BLL.Helpers;
using FalconOne.Helpers.Helpers;
using FalconOne.Models.DTOs;

namespace FalconeOne.BLL.Interfaces
{
    public interface IRequestInformationService
    {
        Task SaveRequestInfoAsync(RequestInformationDTO model);

        Task<ApiResponse> GetAllAsync(PageParams pageParams);
    }
}
