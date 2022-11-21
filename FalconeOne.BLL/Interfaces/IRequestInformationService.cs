using Utilities.DTOs;

namespace FalconeOne.BLL.Interfaces
{
    public interface IRequestInformationService
    {
        Task SaveRequestInfoAsync(RequestInformationDTO model);
    }
}
