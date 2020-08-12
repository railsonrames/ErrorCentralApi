using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ErrorCentralApi.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ErrorCentralApi.Services;
using Microsoft.OpenApi.Models;

namespace ErrorCentralApi
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
      services.AddDbContext<ErrorCentralDataContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("AzureErrorCentralDataBaseServer")));
      services.AddControllers();
      services.AddSwaggerGen(
        x => x.SwaggerDoc("v1", 
        new OpenApiInfo 
        {
          Title = "ErrorCentralAPI",
          Version = "v1",
          Description = "Projeto API de uma Central de Logs - Wiz e Codenation"
        })
      );
      services.AddAutoMapper(typeof(Startup));
      services.AddScoped<IErrorService, ErrorService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseSwagger();
      app.UseSwaggerUI(c => 
        {
          c.SwaggerEndpoint(url:"/swagger/v1/swagger.json", name:"ErrorCenter API v1");
        });

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
