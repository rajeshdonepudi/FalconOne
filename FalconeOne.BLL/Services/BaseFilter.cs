using FalconeOne.BLL.Interfaces;

namespace FalconeOne.BLL.Services
{
    public class BaseFilter
    {
        private readonly IRequestInformationService _requestInformationService;
        public BaseFilter(IRequestInformationService requestInformationService)
        {
            _requestInformationService = requestInformationService;
        }
    }
}
