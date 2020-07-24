using Microsoft.AspNetCore.Builder;

namespace Toxic.AspNetCore
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseMeasureProcessingTime(this IApplicationBuilder app)
        {
            app.UseMiddleware<MeasureProcessingTimeMiddleware>();
        }
    }
}