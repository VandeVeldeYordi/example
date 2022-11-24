using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Pin.Spoticlone.Blazor.Models;
using Pin.Spoticlone.Blazor.Services;
using Pin.Spoticlone.Blazor.Services.Api;
using Pin.Spoticlone.Blazor.Services.Interfaces;

namespace Pin.Spoticlone.Blazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddScoped<HttpClient>();
            builder.Services.AddTransient<IArtistsApiService, ArtistsApiService>();
            builder.Services.AddTransient<IAlbumsApiService, AlbumApiService>();
            builder.Services.AddTransient<ICRUDService<Track>, TracksApiService>();
            builder.Services.AddTransient<IStatisticsApiService, StatisticsApiService>();
            builder.Services.AddHttpClient();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}