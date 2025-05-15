using jwpro.DateHelper.Configuration;
using jwpro.DateHelper.Managers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace jwpro.DateHelper.Extensions
{
	public static class HostApplicationBuilderExtensions
	{
		/// <summary>
		/// Extension method that adds the default service entry used for HawkBom functionality
		/// </summary>
		/// <param name="builder"></param>
		/// <param name="configuration"></param>
		public static void UseHelperDatesManager(this IHostApplicationBuilder builder, IConfiguration configuration)
		{
			builder.Services.AddSingleton(configuration.GetSettings<BusinessDateManagerConfiguration>());
			builder.Services.AddSingleton<IBusinesDateManager, BusinesDateManager>();
		}
	}
}
