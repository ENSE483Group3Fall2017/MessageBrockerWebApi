using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ENSE483Group3Fall2017.MessageBrokerWebApi.Infrastructure.Messaging;
using AutoMapper;
using MediatR;

namespace ENSE483Group3Fall2017.MessageBrokerWebApi
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
            services.AddMvc();
            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(Startup));
            services.AddSingleton((sp) => new AzureMessageQeueRelayConfiguration(Configuration["AzureMessageQeue:ConnectionString"], Configuration["AzureMessageQeue:QueueName"]));
            services.AddSingleton(typeof(IMessageQueueRelay<>), typeof(AzureMessageQeueRelay<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
