using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PolicyAdmin.ConsumerMS.API.Data;
using PolicyAdmin.ConsumerMS.API.DataLayer;
using PolicyAdmin.ConsumerMS.API.Interface;
using PolicyAdmin.ConsumerMS.API.Provider;
using PolicyAdmin.ConsumerMS.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyAdmin.ConsumerMS.API
{
    public class Startup
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger("RollingFile");
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _log4net.Info("Initializing Program");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder
                                          .AllowAnyHeader()
                                          .AllowAnyOrigin()
                                          .AllowAnyMethod();
                                  });
            });
            if (Configuration.GetValue<bool>("InMemoryDatabase"))
            {
                services.AddDbContext<ConsumerContext>(options => options.UseInMemoryDatabase("PolicyAdmin_Quotes"));
                _log4net.Info("Initialized In-Memory DB");
            }
            else
            {
                try
                {
                    services.AddDbContext<ConsumerContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Database")));
                    _log4net.Info("Initialized SQL DB");
                }catch(Exception e)
                {
                    _log4net.Error("Error In Connection to Databse : "+e.Message);
                }
                
            }

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Secret"]))
                    };
                });
            services.AddCors(c => c.AddPolicy("POD_1_Policy", builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            }));

            services.AddTransient<IConsumerDBService, ConsumerDBService>();
            services.AddTransient<IConsumerRepository, ConsumerRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PolicyAdmin.ConsumerMS.API", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PolicyAdmin.ConsumerMS.API v1"));
            }

            if (Configuration.GetValue<bool>("InMemoryDatabase"))
            {
                try
                {
                    _log4net.Info("Data Seding for In-Memory DB Started");
                    var scopeeee = app.ApplicationServices.CreateScope();
                    var context = scopeeee.ServiceProvider.GetRequiredService<ConsumerContext>();
                    PropertyMasterDataGenerator.Initialize(context);
                    businessMasterDataGenerator.Initialize(context);
                    BusinessDataGenerator.Initialize(context);
                    ConsumerDataGenerator.Initialize(context);
                    PropertyDataGenerator.Initialize(context);
                }
                catch (Exception e)
                {
                    _log4net.Error("Exception in Data Seeding: " + e.Message);

                }


            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
