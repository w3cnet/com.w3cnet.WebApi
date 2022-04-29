using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace com.w3cnet.WebApi.Common
{
    /// <summary>
    /// AppSettings读取类
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// AppSetting配置集合
        /// </summary>
        public static IConfiguration Configuration { get; set; }

        static AppSettings()
        {
            string path = "appsettings.json";

            Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .Add(new JsonConfigurationSource
            {
                Path = path,
                ReloadOnChange = true // 当appsettings.json被修改时重新加载
            })
            .Build();
        }

        /// <summary>
        /// 获取节点配置
        /// </summary>
        /// <param name="sections">节点配置</param>
        /// <returns></returns>
        public static string Get(params string[] sections)
        {
            try
            {
                if (sections.Any())
                {
                    return Configuration[string.Join(":", sections)];
                }
            }
            catch (Exception)
            {

            }

            return "";
        }

        /// <summary>
        /// 获取子节点列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sections"></param>
        /// <returns></returns>
        public static List<T> List<T>(params string[] sections)
        {
            var list = new List<T>();
            Configuration.Bind(string.Join(":", sections), list);

            return list;
        }
    }
}
