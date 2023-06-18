using FalconeOne.BLL.Interfaces;

namespace FalconeOne.BLL.Services
{
    public class BaseFilter
    {
        private readonly ISystemLogsService _requestInformationService;
        public BaseFilter(ISystemLogsService requestInformationService)
        {
            _requestInformationService = requestInformationService;
        }
    }
}
