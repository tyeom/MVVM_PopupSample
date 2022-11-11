using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Messaging;
using MVVM_PopupSample.Base;
using MVVM_PopupSample.ViewModels.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_PopupSample.ViewModels;

internal class ShellViewModel : ViewModelBase<IViewAction>
{
    private object? _currentDataContext;

    public ShellViewModel(IViewAction view) : base(view)
    {
        WeakReferenceMessenger.Default.Register<ShowMessageBoxMessage>(this, this.ShowMessageBox);
        WeakReferenceMessenger.Default.Register<object, string>(this, "CloseMsg", this.CloseMessageBox);

        CurrentDataContext = Ioc.Default.GetService<MainViewModel>();
    }

    public object? CurrentDataContext
    {
        get => _currentDataContext;
        set => SetProperty(ref _currentDataContext, value);
    }

    private void ShowMessageBox(object recipient, ShowMessageBoxMessage requestMessage)
    {
        if (requestMessage.Value.Callback == null)
        {
            base.View.ShowMessageBox(requestMessage.Value.MessageText,
                requestMessage.Value.MessagePopUpIconType,
                requestMessage.Value.YesText,
                requestMessage.Value.YesBtnColor,
                requestMessage.Value.ConfirmCallback);
        }
        else
        {
            base.View.ShowYesNoMessageBox(requestMessage.Value.MessageText,
                requestMessage.Value.MessagePopUpIconType,
                requestMessage.Value.YesText,
                requestMessage.Value.NoText,
                requestMessage.Value.YesBtnColor,
                requestMessage.Value.NoBtnColor,
                requestMessage.Value.Callback);
        }
    }

    private void CloseMessageBox(object recipient, object closeMsg)
    {
        base.View.CloseMessageBox();
    }
}