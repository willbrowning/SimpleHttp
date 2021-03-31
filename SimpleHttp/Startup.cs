using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleHttp
{
	public class Startup
	{
		private Regex _statusCodeRegex = new Regex(@"^/(?<StatusCode>\d{3})");

		public void ConfigureServices(IServiceCollection services)
		{
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.Run(async (context) =>
			{
				var urlPath = context.Request.Path.Value;
				var statusCodeMatch = _statusCodeRegex.Match(urlPath);

				var statusCode = StatusCodes.Status200OK;

				if (statusCodeMatch.Success)
				{
					statusCode = int.Parse(statusCodeMatch.Groups["StatusCode"].Value);
				}

				context.Response.StatusCode = statusCode;
				await context.Response.WriteAsync(statusCode.ToString());
			});
		}
	}
}
