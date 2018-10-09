using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Newtonsoft.Json;
using Serilog;
using SerilogLab.Model;

namespace SerilogLab.Middleware
{
    public class PerformanceMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Stopwatch _sw = new Stopwatch();

        public PerformanceMiddleware(RequestDelegate next)
        {
            _next = next;
            
        }

        public async Task Invoke(HttpContext context)
        {
            var pflog = new LogHelper.LogHelper().CreatePFLogDetail("i am remark");
            pflog.StartTime = DateTime.Now;
            
            _sw.Reset();
            _sw.Start();
            
            await _next(context);
            
            _sw.Stop();
            pflog.TimeLength = _sw.ElapsedMilliseconds;
            
            GetHttpContextDetail(context, pflog);

            Log.Logger.Information("Request completed {@pflog}", pflog);
        }

        private void GetHttpContextDetail(HttpContext context, PFLogDetail pflog)
        {
            var httpRequestFeature = context.Features[typeof(IHttpRequestFeature)] as IHttpRequestFeature;
            pflog.Path = httpRequestFeature?.Path;
            pflog.HttpMethod = httpRequestFeature?.Method;
        }
    }
}