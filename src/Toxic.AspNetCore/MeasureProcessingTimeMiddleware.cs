using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Toxic.AspNetCore
{
    /// <summary>
    /// 计算请求时长的中间件
    /// </summary>
    public sealed class MeasureProcessingTimeMiddleware
    {
        private readonly RequestDelegate _next;

        public MeasureProcessingTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            var watch = new Stopwatch();
            context.Response.OnStarting(state =>
            {
                var httpContext = (HttpContext)state;
                watch.Stop();
                var elapsedMilliseconds = watch.ElapsedMilliseconds.ToString("N");
                httpContext.Response.Headers.Add("X-Processing-Time-Milliseconds", elapsedMilliseconds);
                return Task.CompletedTask;
            }, context);
            watch.Start();
            return _next(context);
        }
    }
}