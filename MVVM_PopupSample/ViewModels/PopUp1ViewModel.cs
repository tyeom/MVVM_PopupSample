using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace MVVM_PopupSample.ViewModels;

internal class PopUp1ViewModel : ObservableObject
{
    public string Text { get; set; } = "PopUp1 View";
}