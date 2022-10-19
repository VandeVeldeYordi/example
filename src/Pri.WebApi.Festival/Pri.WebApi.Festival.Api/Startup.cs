using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Pri.Festivals.Core.Entities;
using Pri.Festivals.Core.InterFaces.Repositories;
using Pri.Festivals.Core.InterFaces.Services;
using Pri.Festivals.Core.Services;
using Pri.Festivals.Infrastructure;
using Pri.Festivals.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pri.WebApi.Festival.Api
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
            //configure identity
            services.AddIdentity<ApplicationUser, IdentityRole>(
                options =>
                {
                    options.SignIn.RequireConfirmedEmail = false;//only for development!
                    //only for development
                    //set some flexible password rules
                    options.Password.RequireDigit = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequiredLength = 3;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddHttpContextAccessor();
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("FestivalsDatabase")));

            services.AddCors(options =>
           options.AddDefaultPolicy(builder =>
           {
               builder.AllowAnyOrigin();
               builder.AllowAnyMethod();
               builder.AllowAnyHeader();
           }));
            //add authentication and authorization
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateActor = true,
                    ValidateAudience = true,
                    ValidIssuer = Configuration["JWTConfiguration:Issuer"],
                    ValidAudience = Configuration["JWTConfiguration:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                        Configuration["JWTConfiguration:SigninKey"]))
                };
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("admin", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "admin");
                });
                //must be admin or customer
                options.AddPolicy("customer", policy =>
                {
                    policy.RequireAssertion(context =>
                    {
                        if (context.User.HasClaim(ClaimTypes.Role, "admin")
                        || context.User.HasClaim(ClaimTypes.Role, "customer"))
                        {
                            return true;
                        }
                        return false;
                    });
                });
            });

            //repositories
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<IFestivalRepository, FestivalRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IOrganizerRepository, OrganizerRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            //services
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<IFestivalService, FestivalService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IOrganizerService, OrganizerService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddControllers();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJwtService, JwtService>();
 
            services.AddSwaggerGen(c =>
            {
                {
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "Enter the token below:"
                    });
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] { }
                        }
                    });
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pri.WebApi.Festival.Api", Version = "v1" });
                }

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pri.WebApi.Festival.Api v1"));
            }
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseCors();

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
