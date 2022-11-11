using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MVVM_PopupSample.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_PopupSample.Base;

/// <summary>
/// Popup Dialog ViewModelBase <para/>
/// 팝업 다이얼로그 뷰모델로 사용
/// </summary>
public class PopupDialogViewModelBase : ObservableObject
{
    private ObservableObject? _popupVM;

    public ObservableObject? PopupVM
    {
        get => _popupVM;
        set => SetProperty(ref _popupVM, value);
    }

    private RelayCommand? _closeCommand;
    public RelayCommand? CloseCommand
    {
        get
        {
            return _closeCommand ??
                (_closeCommand = new RelayCommand(
                    () =>
                    {
                        PopupVM = null;
                    }));
        }
    }

    public virtual void Cleanup()
    {
        WeakReferenceMessenger.Default.Cleanup();
    }
}