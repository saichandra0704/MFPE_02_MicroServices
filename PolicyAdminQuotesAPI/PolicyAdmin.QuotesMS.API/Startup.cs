using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PolicyAdmin.QuotesMS.API.Data;
using PolicyAdmin.QuotesMS.API.Repository;
using PolicyAdmin.QuotesMS.API.DataLayer;
using PolicyAdmin.QuotesMS.API.Services;
using PolicyAdmin.QuotesMS.API.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;

namespace PolicyAdmin.QuotesMS.API
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
                services.AddDbContext<QuotesContext>(options => options.UseInMemoryDatabase("PolicyAdmin_Quotes"));
                _log4net.Info("Initialized In-Memory DB");
            }
            else
            {
                try
                {
                    services.AddDbContext<QuotesContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Database")));
                    _log4net.Info("Initialized SQL DB");
                }
                catch (Exception e)
                {
                    _log4net.Error("Error In Connection to Databse : " + e.Message);
                }

            }

            services.AddTransient<IQuotesDBService,QuotesDBService>();
            services.AddTransient<IQuoteRepository,QuoteRepository>();


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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PolicyAdmin.QuotesMS.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PolicyAdmin.QuotesMS.API v1"));
            }
            try
            {
                _log4net.Info("Data Seding for In-Memory DB Started");
                if (Configuration.GetValue<bool>("InMemoryDatabase"))
                {
                    var scopeeee = app.ApplicationServices.CreateScope();
                    var context = scopeeee.ServiceProvider.GetRequiredService<QuotesContext>();
                    DataGenerator.Initialize(context);

                }
                _log4net.Info("Data Seding for In-Memory DB Completed");
            }
            catch(Exception e)
            {
                _log4net.Error("Exception in Data Seeding: "+  e.Message);

            }
            

            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
