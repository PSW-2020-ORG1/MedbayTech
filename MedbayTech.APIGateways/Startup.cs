using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace MedbayTech.APIGateways
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                            .SetIsOriginAllowed(_ => true)
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });
            services.AddOcelot();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("QKcOa8xPopVOliV6tpvuWmoKn4MOydSeIzUt4W4r1UlU2De7dTUYMlrgv3rU"));
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {            
            string stage = Environment.GetEnvironmentVariable("STAGE") ?? "development";

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


             if (stage.Equals("development"))
             {
                 app.UseStaticFiles(new StaticFileOptions
                 {
                     FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "dist"))
                 });
             }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
            app.UseCors("AllowAll");
            app.UseOcelot();
            app.UseAuthentication();
        }
    }
}
