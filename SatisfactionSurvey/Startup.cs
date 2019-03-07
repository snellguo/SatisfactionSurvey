using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using SmartFramwork.Core.Service;
using SmartFramwork.Domain.SatisfactionSurvey;
using SmartFramwork.Domain.SatisfactionSurvey.Resources;
using SmartFramwork.Web.Filter;

namespace SatisfactionSurvey
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            GlobalVariable.configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //页面输出 文本而不是 ￥#323;
            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));
            //配置多语言
            services.AddLocalization();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc(options =>
            {
                //options.Filters.Add<AuthorizationFilter>();
                options.Filters.Add<ModelStateActionFilter>();
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            #region 配置多语言
			//修改返回数据风格  和 后台属性一样    默认为首字母小写
			.AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver())
            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization(options =>
            {
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                {
                    if (type.FullName.IndexOf("SmartFramwork.Domain.SatisfactionSurvey") > -1)
                    {
                        return factory.Create(typeof(SatisfactionSurveyResource));
                    }
                    else
                    {
                        return null;
                    }
                };
            });
            #endregion

            Class1 n = new Class1();

            //批量注册
            services.AddDomainService<IDomainService>();

            //扩展HttpContext
            //services.AddHttpContext();
            services.AddLogging(configure =>
            {
                configure.AddLog4Net();
                //configure.AddFilter("Microsoft", LogLevel.Warning);
                //configure.AddFilter("System", LogLevel.Error);
            });
            services.AddGlobalVariable();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=SatisfactionSurvey}/{action=Index}/{id?}");
        //template: "{controller=Home}/{action=Index}/{id?}");
            });

            var supportedCultures = new[]
            {
                new CultureInfo("zh-CN"),
                //new CultureInfo("en-US"),

            };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {

                DefaultRequestCulture = new RequestCulture("zh-CN"),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });
        }
    }
}
