using Database.Module1;
using Database.Module2;
using Marten;
using Marten.Events.Daemon.Resiliency;
using Marten.Events.Projections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Database;

public static class Database
{
	public static IServiceCollection AddDatabase(this IServiceCollection services)
	{
		services.AddMarten(options =>
			{
				options
					.MultiTenantedWithSingleServer("User ID=postgres;Password=p;Host=localhost;Port=5432;Database=postgres;Include Error Detail=true")
					.WithTenants("module1", "module2");

				// i would like this documents schema to be in module1-tenant (for possibility of moving it to another database)
				options.Schema.Include<Module1Registry>();

				// i would like this documents schema to be in module2-tenant (for possibility of moving it to another database)
				options.Schema.Include<Module2Registry>();

				// options.Connection(configuration["DB_CONNECTION_STRING"]!);

				// i would like this stream's schema to be in module1-tenant (for possibility of moving it to another database)
				options.Projections.Add(new Module1Projection(), ProjectionLifecycle.Async);

				// i would like this stream's schema to be in module2-tenant (for possibility of moving it to another database)
				options.Projections.Add(new Module2Projection(), ProjectionLifecycle.Async);
			})
			.UseLightweightSessions()
			.OptimizeArtifactWorkflow()
			.ApplyAllDatabaseChangesOnStartup()
			.AddAsyncDaemon(DaemonMode.Solo);

		return services;
	}
}
