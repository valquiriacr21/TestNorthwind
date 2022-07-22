using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TestNorthwind.Configuration;
using TestNorthwind.Data;

namespace TestNorthwind
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
            //Cors
            services.AddCors();

            //JWT Configuring
            services.Configure<JwtConfig>(Configuration.GetSection("JWTSettings"));


            //Database Configuring
            services.AddDbContext<NorthwindContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Database Identity Configuring
            services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(
          Configuration.GetConnectionString("DefaultConnection2")));


            //JWT Configuring
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                      .AddJwtBearer(jwt =>
                      {
                          var key = Encoding.ASCII.GetBytes(Configuration["JwtConfig:Secret"]);

                          jwt.SaveToken = true;
                          jwt.TokenValidationParameters = new TokenValidationParameters
                          {
                              ValidateIssuerSigningKey = true,
                              IssuerSigningKey = new SymmetricSecurityKey(key),
                              ValidateIssuer = false,
                              ValidateAudience = false,
                              ValidateLifetime = true,
                              RequireExpirationTime = false
                          };
                      });

            //Identity Configuring
            //services.AddDefaultIdentity<ApplicationDbContext>(options =>
            //options.SignIn.RequireConfirmedAccount = true)
            //.AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TestNorthwind", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            string[] origens = new string[1];
            origens[0] = "http://localhost:4200";
            //origens[1] = "http://localhost:4200/gateway";
            //origens[2] = "http://localhost:4200/device";

            app.UseCors(options =>
            {
                options.WithOrigins(origens);
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestNorthwind v1"));
            }

            app.UseHttpsRedirection();

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
