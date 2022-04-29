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
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnModel Login(string role)
        {
            string jwtStr = string.Empty;
            bool suc = false;

            if (!string.IsNullOrEmpty(role))
            {
                TokenModel tokenModel = new TokenModel { Uid = Guid.NewGuid().ToString(), Roles = role };
                jwtStr = JwtModule.IssueJwt(tokenModel); // 登录，获取到一定规则的 Token 令牌
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
