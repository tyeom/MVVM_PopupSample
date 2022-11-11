using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MVVM_PopupSample.Enums;
using MVVM_PopupSample.Services;
using MVVM_PopupSample.ViewModels.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM_PopupSample.ViewModels;

internal class MainViewModel : ObservableObject
{
    private readonly IDialogService _dialogService;

    public MainViewModel(IDialogService dialogService)
    {
        _dialogService = dialogService;
    }

    private RelayCommand? _showConfirmMsg;
    public RelayCommand ShowConfirmMsg
    {
        get
        {
            return _showConfirmMsg ??
                (_showConfirmMsg = new RelayCommand(this.ShowConfirmMsgExecute));
        }
    }

    private RelayCommand? _showConfirmMsg2;
    public RelayCommand ShowConfirmMsg2
    {
        get
        {
            return _showConfirmMsg2 ??
                (_showConfirmMsg2 = new RelayCommand(this.ShowConfirmMsg2Execute));
        }
    }

    private RelayCommand? _showYesNoMsg;
    public RelayCommand ShowYesNoMsg
    {
        get
        {
            return _showYesNoMsg ??
                (_showYesNoMsg = new RelayCommand(this.ShowYesNoMsgExecute));
        }
    }

    private RelayCommand? _showPopup1;
    public RelayCommand ShowPopup1
    {
        get
        {
            return _showPopup1 ??
                (_showPopup1 = new RelayCommand(() =>
                {
                    if (_dialogService.CheckActivate("팝업1") is true)
                    {
                        // CheckActivate에서 해당 팝업 창 활성화
                    }
                    else
                    {
                        _dialogService.SetVM(new PopUp1ViewModel(), "팝업1", 500, 650, EDialogHostType.BasicType);
                    }
                }));
        }
    }

    private RelayCommand? _showPopup2;
    public RelayCommand ShowPopup2
    {
        get
        {
            return _showPopup2 ??
                (_showPopup2 = new RelayCommand(() =>
                {
                    if (_dialogService.CheckActivate("팝업2") is true)
                    {
                        // CheckActivate에서 해당 팝업 창 활성화
                    }
                    else
                    {
                        _dialogService.SetVM(new PopUp2ViewModel(), "팝업2", 500, 650, EDialogHostType.AnotherType, false);
                    }
                }));
        }
    }

    private void ShowConfirmMsgExecute()
    {
        WeakReferenceMessenger.Default.Send(
            new ShowMessageBoxMessage(new MessageBoxInfo()
            {
                MessageText = "메세지창 내용",
                MessagePopUpIconType = Enums.EMessagePopUpIconType.None,
                YesText = "확인",
                YesBtnColor = null,
                ConfirmCallback = () =>
                {
                    MessageBox.Show("1");
                }
            }));
    }

    private void ShowConfirmMsg2Execute()
    {
        WeakReferenceMessenger.Default.Send(
            new ShowMessageBoxMessage(new MessageBoxInfo()
            {
                MessageText = "메세지창 내용2",
                MessagePopUpIconType = Enums.EMessagePopUpIconType.Warning,
                YesText = "확인2",
                YesBtnColor = null,
                ConfirmCallback = () =>
                {
                    MessageBox.Show("2");
                }
            }));
    }

    private void ShowYesNoMsgExecute()
    {
        WeakReferenceMessenger.Default.Send(
            new ShowMessageBoxMessage(new MessageBoxInfo()
            {
                MessageText = "메세지창 내용",
                MessagePopUpIconType = Enums.EMessagePopUpIconType.None,
                YesText = "좋다",
                YesBtnColor = null,
                NoText = "싫다",
                Callback = (result) =>
                {
                    MessageBox.Show(result.ToString());
                }
            }));

        // 메세지 박스 닫기
        //WeakReferenceMessenger.Default.Send<object, string>("CloseMsg");
    }
}