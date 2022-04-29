using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace com.w3cnet.WebApi.Controllers
{
    /// <summary>
    /// 控制器基类
    /// </summary>
    [Route("[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
    }
}
