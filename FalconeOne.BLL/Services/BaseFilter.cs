using AutoMapper;
using FalconeOne.BLL.Interfaces;

namespace FalconeOne.BLL.Services
{
    public class BaseFilter
    {
        private readonly IRequestInformationService _requestInformationService;
        private readonly IMapper _mapper;

        public BaseFilter(IRequestInformationService requestInformationService, IMapper mapper)
        {
            _requestInformationService = requestInformationService;
            _mapper = mapper;
        }
    }
}
