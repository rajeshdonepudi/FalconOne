using AutoMapper;
using FalconOne.DLL;
using FalconOne.DLL.Entities;
using FalconOne.DLL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Utilities.DTOs;

namespace FalconeOne.BLL.Services
{
    public class BaseService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BaseService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        
        protected List<BusinessError> PrepareErrors(IEnumerable<IdentityError> identityErrors)
        {
            return identityErrors.Select(x => new BusinessError { Code = x.Code, Description = x.Description }).ToList();
        }
    }
}
