using System;
using ElephantLog.Repositories;
using ElephantLog.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Serilog;
using Serilog.Events;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using Dag37.MQ.Lib;

namespace ElephantLog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ILogService, LogService>();
            services.AddMvc();
            services.AddTransient<ILogRepository, LogRepository>();
            services.AddTransient(service => 
                new MongoClient("mongodb://localhost:27017")
                .GetDatabase("logs"));
            services.AddRabbitMQ(new BusOptions { HostName = "localhost", Port = 5672 });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            app.UseRabbitMQ();
            app.UseMvc();
        }
    }
}
