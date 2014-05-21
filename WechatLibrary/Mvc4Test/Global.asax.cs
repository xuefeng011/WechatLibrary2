﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using WechatLibrary.ProcessPipeline;
using WechatLibrary.Model.Message.Response;

namespace Mvc4Test
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<WechatLibrary.Model.WechatEntities>());

            WechatLibrary.Wechat.SetDefaultValueEnd += Wechat_GetHttpRequestAndHttpResponseing;

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        void Wechat_GetHttpRequestAndHttpResponseing(object sender, EventArgs e)
        {
            var x = sender as ProcessPipeline;
            (x.ResponseResult as TextResult).Content = "50000000000000";
            int a = 10;
        }
    }
}