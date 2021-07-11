using MafiaAPI.Database;
using MafiaAPI.Jobs;
using MafiaAPI.Models;
using MafiaAPI.Repositories;
using MafiaAPI.Service;
using MafiaAPI.Services.Messages;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Quartz;
using System.Text;

namespace MafiaAPI
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
            //Enable CORS
            services.AddCors(c =>
                {
                    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
                });

            //JSON Initializer
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft
                .Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver =
                new DefaultContractResolver());

            //Connection String
            services.AddDbContext<MafiaDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("MafiaAppCon")));

            //Repositories
            services.AddTransient<IAgentRepository, AgentRepository>()
                .AddTransient<IMissionRepository, MissionRepository>()
                .AddTransient<IBossRepository, BossRepository>()
                .AddTransient<IPerformingMissionRepository, PerformingMissionRepository>()
                .AddTransient<IMessageRepository, MessageRepository>()
                .AddTransient<IPlayerRepository, PlayerRepository>();
          
            //Services
            services.AddTransient<IMissionService, MissionService>()
                .AddTransient<IPerformingMissionService, PerformingMissionService>()
                .AddTransient<IAgentService, AgentService>();
                .AddTransient<IAuthService, AuthService>()
                .AddTransient<IMessageService, MessageService>();


            //Security
            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = "http://localhost:53191",
                        ValidAudience = "http://localhost:53191",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JavorNajlepszyJest"))
                    };
                });

            services.Configure<QuartzOptions>(Configuration.GetSection("Quartz"));

            services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionJobFactory();
            });
            services.AddQuartzServer(options =>
            {
                options.WaitForJobsToComplete = true;
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
