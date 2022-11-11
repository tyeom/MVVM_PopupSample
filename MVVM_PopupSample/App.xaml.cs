using CommunityToolkit.Mvvm.DependencyInjection;
using MVVM_PopupSample.Enums;
using MVVM_PopupSample.Services;
using MVVM_PopupSample.Views.Windows;
using System.Windows;

namespace MVVM_PopupSample;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        new Bootstrapper();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        Current.ShutdownMode = ShutdownMode.OnLastWindowClose;

        // 팝업 다이얼로그 호스트 등록
        var dialogService = Ioc.Default.GetService<IDialogService>();
        dialogService!.Register(EDialogHostType.BasicType, typeof(PopupWindow1));
        dialogService!.Register(EDialogHostType.AnotherType, typeof(PopUpWindow2));

        var shellWindow = new MainWindow();
        shellWindow.ShowDialog();

        if (Current != null)
            Current.Shutdown();
    }
}