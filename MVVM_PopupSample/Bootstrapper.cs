using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MVVM_PopupSample.Services;
using MVVM_PopupSample.ViewModels;
using System;

namespace MVVM_PopupSample;

internal class Bootstrapper
{
    public Bootstrapper()
    {
        var services = ConfigureServices();
        Ioc.Default.ConfigureServices(services);
    }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        // Services
        services.AddSingleton<IDialogService, DialogService>();

        // Viewmodels
        services.AddTransient<MainViewModel>();

        return services.BuildServiceProvider();
    }
}