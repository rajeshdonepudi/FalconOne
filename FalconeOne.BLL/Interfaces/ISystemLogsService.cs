using FalconOne.Helpers.Helpers;
using FalconOne.Models.DTOs;
using FalconOne.Models.Entities;

namespace FalconeOne.BLL.Interfaces
{
    public interface ISystemLogsService
    {
        Task SaveRequestInfoAsync(RequestInformationDto model);

        Task<PagedList<SystemLog>> GetAllAsync(PageParams pageParams);
    }
}
