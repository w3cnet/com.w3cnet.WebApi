using com.w3cnet.WebApi.Common;
using com.w3cnet.WebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace com.w3cnet.WebApi.Controllers
{
    /// <summary>
    /// 控制器示例(示例)
    /// </summary>
    public class HomeController : BaseController
    {
        /// <summary>
        /// 自定义路由
        /// </summary>
        /// <returns></returns>
        [Route("/")]
        [HttpGet]
        public string Index()
        {
            // appsettings读取测试
            var connectionStrings1 = AppSettings.Configuration["ConnectionStrings:DefaultConnection"];
            var connectionStrings2 = AppSettings.Get("ConnectionStrings", "DefaultConnection");
            var connectionStrings3 = AppSettings.List<string>("Servers");

            return "Hello world.";
        }

        /// <summary>
        /// 默认路由:home/defaultroute
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string DefaultRoute([FromBody] UserModel user = null)
        {
            return "Default route.";
        }
    }
}
