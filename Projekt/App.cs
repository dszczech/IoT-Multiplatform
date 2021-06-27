using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.MobileBlazorBindings;
using Projekt.Pages;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Net.Http;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;

namespace Projekt
{
    public class App : Application
    {
        public App(IFileProvider fileProvider = null)
        {
            var hostBuilder = MobileBlazorBindingsHost.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    // Adds web-specific services such as NavigationManager
                    services.AddBlazorHybrid();

                    // Register app-specific services
                    services.AddSingleton<CounterState>();
                    services.AddSingleton<GameModelService>();
                    services.AddSingleton<GameHub>();

                })
                .UseWebRoot("wwwroot");



            if (fileProvider != null)
            {
                hostBuilder.UseStaticFiles(fileProvider);

            }
            else
            {
                hostBuilder.UseStaticFiles();
            }

            var host = hostBuilder.Build();

            MainPage = new ContentPage { Title = "My Application" };
            host.AddComponent<Main>(parent: MainPage);        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

    }


}
