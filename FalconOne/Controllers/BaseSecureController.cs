using FalconOne.API.Attributes;
namespace FalconOne.API.Controllers
{
    [ApiAuthorize]
    public class BaseSecureController : BaseController
    {
        public BaseSecureController() : base()
        {
        }
    }
}
