using System;
using System.Collections.Generic;
using System.Text;

namespace com.w3cnet.WebApi.Model
{
    /// <summary>
    /// JWT令牌
    /// </summary>
    public class TokenModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public string Role { get; set; }
    }
}
