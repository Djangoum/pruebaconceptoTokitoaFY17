using Dapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Infrastructure.Middlewares
{
    public class PerformanceDiagnosisMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly PerformanceDiagnosisConfiguration _configuration;
        private readonly IConfiguration _configurationManager;

        public PerformanceDiagnosisMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configurationManager = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            await _next.Invoke(context);
            watch.Stop();
            await LogPerformance(watch.ElapsedMilliseconds);
        }

        private async Task LogPerformance(long ElapsedMiliseconds)
        {
            using (var sqlConnection = new SqlConnection(_configurationManager.GetConnectionString("DefaultConnection")))
            {
                await sqlConnection.OpenAsync();

                await sqlConnection.ExecuteAsync(
                @"
                    insert Requests (Time) values (@Time);
                ", new { Time = ElapsedMiliseconds });

                sqlConnection.Close();
            }
        }
    }

    public static partial class MiddlewareIssuesmanagerExtensions
    {
        public static IApplicationBuilder UsePerformanceDiagnosis(this IApplicationBuilder app, IConfiguration config)
        {
            return app.UseMiddleware<PerformanceDiagnosisMiddleware>(config);
        }
    }

    public class PerformanceDiagnosisConfiguration
    {
        public bool Processor { get; set; }
        public bool Memory { get; set; }
        public bool RequestsTiming { get; set; }
        public bool RequestNumber { get; set; }
    }
}