using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace com.w3cnet.WebApi.Model.Common
{
    /// <summary>
    /// 统一出参Model
    /// </summary>
    public class ReturnModel
    {
        /// <summary>
        /// 状态
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 返回的数据
        /// </summary>
        public dynamic Data { get; set; }

        /// <summary>
        /// 响应时间
        /// </summary>
        public string ResponseTime { get; set; }
    }
}
