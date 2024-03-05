using FalconeOne.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace FalconOne.API.Controllers
{
    [AllowAnonymous]
    public class BaseAccountController : BaseController
    {
        protected readonly IAccountService _accountService;

        public BaseAccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
    }
}
