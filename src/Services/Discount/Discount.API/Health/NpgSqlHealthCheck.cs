using Dapper;
using Discount.API.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Npgsql;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Discount.API.Health
{
    public class NpgSqlHealthCheck : IHealthCheck
    {
        private readonly IConfiguration _configuration;

        public NpgSqlHealthCheck(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var connection = new NpgsqlConnection
                (_configuration.GetValue<string>("DbSettings:ConnectionString"));

                var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>("SELECT * FROM Coupon");

                return HealthCheckResult.Healthy();
            }
            catch (Exception exception)
            {
                return HealthCheckResult.Unhealthy(exception: exception);
            }
        }
    }
}
