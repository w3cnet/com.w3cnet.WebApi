using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace com.w3cnet.WebApi.Common
{
    /// <summary>
    /// Swagger模块
    /// </summary>
    public static class SwaggerModule
    {
        /// <summary>
        /// API接口名称
        /// </summary>
        public const string ApiName = "WebApi脚手架";

        /// <summary>
        /// 注册方法
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("V1", new OpenApiInfo()
                {
                    Title = $"{ApiName}接口文档",
                    Version = "v1",
                    Description = $"{ApiName} HTTP API v1"
                });

                options.OrderActionsBy(o => o.RelativePath);
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "com.w3cnet.WebApi.xml"), true);
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "com.w3cnet.WebApi.Model.xml"), false);

                // 在header中添加token，传递到后台
                options.OperationFilter<SecurityRequirementsOperationFilter>();

                #region Token绑定到ConfigureServices
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey
                });
                #endregion
            });
        }
    }
}
