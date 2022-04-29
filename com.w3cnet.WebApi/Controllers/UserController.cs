using com.w3cnet.WebApi.Common;
using com.w3cnet.WebApi.Model;
using com.w3cnet.WebApi.Model.Common;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace com.w3cnet.WebApi.Controllers
{
    /// <summary>
    /// 用户控制器(示例)
    /// </summary>
    public class UserController : BaseController
    {
        /// <summary>
        /// 登录(JWT示例)
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnModel Login(UserModel user)
        {
            string jwtStr = string.Empty;
            bool suc = false;

            if (user != null)
            {
                // 将用户id和角色名，作为单独的自定义变量封装进 token 字符串中。
                var roles = new[] { 
                    new {role_id = "1", role_name = "权限1", menu_path = "/test/t1"},
                    new {role_id = "2", role_name = "权限2", menu_path = "/test/t2"},
                    new {role_id = "3", role_name = "权限3", menu_path = "/test/t3"}
                };

                TokenModel tokenModel = new TokenModel { Uid = Guid.NewGuid().ToString(), Role = JsonConvert.SerializeObject(roles) };
                jwtStr = JwtHelper.IssueJwt(tokenModel); // 登录，获取到一定规则的 Token 令牌
                suc = true;
            }
            else
            {
                jwtStr = "login fail!!!";
            }

            return new ReturnModel()
            {
                Code = 200,
                Success = suc,
                Message = "请求成功",
                Data = jwtStr,
                ResponseTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")
            };
        }
    }
}
