using FalconOne.Helpers.Helpers;
using FalconOne.Models.Dtos.System;
using FalconOne.Models.Entities;

namespace FalconeOne.BLL.Interfaces
{
    public interface ISystemLogsService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task SaveRequestInfoAsync(RequestInformationDto model);

        Task<PagedList<SystemLog>> GetAllAsync(PageParams pageParams);
    }
}
