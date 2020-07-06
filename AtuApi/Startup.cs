using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AtuApi.AutoMapper;
using AtuApi.Hubs;
using AtuApi.Interfaces;
using AtuApi.Models;
using AtuApi.Repositories;
using AutoMapper;
using DataContextHelper;
using DataModels.Iterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SapDataAccess;

namespace AtuApi
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

            services.AddCors(); // Make sure you call this previous to AddMvc
            services.AddMvc()/*.AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).SetCompatibilityVersion(CompatibilityVersion.Latest)*/;
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            services.AddSignalR();
 

            services.AddControllers(setupActin =>
            {
                setupActin.ReturnHttpNotAcceptable = true;
                setupActin.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            });

            IConfigurationSection appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            AppSettings appSettings = appSettingsSection.Get<AppSettings>();

            var connection = $"Server=tcp:{appSettings.SqlServerHostName},{appSettings.SqlServerPost};Initial Catalog={appSettings.SqlServerCatalog};Persist Security Info=False;User ID={appSettings.SqlServerUser};Password={appSettings.SqlServerPassword};MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;";

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(connection);
            });



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Atu API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
        "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement(){
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {Type = ReferenceType.SecurityScheme,Id = "Bearer"},
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
        new List<string>()
    }
});
            });

            services.AddAutoMapper(c => c.AddProfile<AutoMapperProfile>(), typeof(Startup));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBranchRepository, BranchRepositry>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddSingleton<IDiManager>(x => new DiManager(appSettings.SqlServerHostName, appSettings.SapDbServerType, appSettings.SapUserName, appSettings.SapPassword, appSettings.SapCompanyDb));


            var serviceProvider = services.BuildServiceProvider();
            var dataBaseConector = serviceProvider.GetService<IUnitOfWork>();
            var permissions = dataBaseConector.PermissionRepository.GetAll();

            services.AddAuthorization(options =>
            {
                foreach (var permission in permissions)
                {

                    options.AddPolicy(permission.PermissionName, policy => policy.RequireClaim(permission.PermissionName));
                }

            });

            var keyBytes = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(opts =>
            {
                opts.DefaultAuthenticateScheme = "JwtBearer";
                opts.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            }).AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = appSettings.AppId;
                facebookOptions.AppSecret = appSettings.AppSecret;
            });

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

          

            app.UseCors(
        optionsx => optionsx.WithOrigins("*").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
            app.UseCors("AllowSpecificOrigin");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ApprovalHub>("/ApprovalHub");
            });
        }
    }
}
