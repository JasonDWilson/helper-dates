using Microsoft.Extensions.Configuration;
using System;

namespace jwpro.DateHelper.Extensions
{
	public static class ConfigurationExtensions
	{
		/// <summary>
		/// Retrieves an instance of the setting class from the configuration
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="config"></param>
		/// <returns></returns>
		public static T GetSettings<T>(this IConfiguration config)
		{
			T settings = (T)Activator.CreateInstance(typeof(T));
			config.Bind(typeof(T).Name, settings);
			return settings;
		}
	}
}
