using MVVM_PopupSample.Base;
using MVVM_PopupSample.Controls;
using MVVM_PopupSample.Enums;
using MVVM_PopupSample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVM_PopupSample;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, IViewAction
{
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = new ShellViewModel(this);
    }

    public void CloseMessageBox()
    {
        this.xMsgBox_OK.IsOpen = false;
        this.xMsgBox_YesNo.IsOpen = false;
    }

    private bool _isConfirmMsgFirstEventHandler = false;
    private Action? _messageBoxConfirmResultCallback;

    public void ShowMessageBox(string messageText,
        EMessagePopUpIconType messagePopUpIconType = EMessagePopUpIconType.None,
        string confirmText = "확인",
        Brush? confirmBtnColor = null,
        Action? callback = null)
    {
        _messageBoxConfirmResultCallback = callback;

        if (_isConfirmMsgFirstEventHandler == false)
        {
            _isConfirmMsgFirstEventHandler = true;
            this.xMsgBox_OK.OKClick += (s, e) =>
            {
                if (_messageBoxConfirmResultCallback != null)
                    _messageBoxConfirmResultCallback();
                _messageBoxConfirmResultCallback = null;
            };
        }

        this.xTxtMsgBox.Text = messageText;
        this.xMsgBox_OK.ConfirmText = confirmText;
        if (confirmBtnColor == null)
        {
            this.xMsgBox_OK.YesBtnColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFD84C72")!);
        }
        else
        {
            this.xMsgBox_OK.YesBtnColor = confirmBtnColor;
        }
        this.xMsgBox_OK.MessagePopUpIconType = messagePopUpIconType;
        this.xMsgBox_OK.IsOpen = true;
    }

    private bool _isYesNoMsgFirstEventHandler = false;
    private Action<bool?>? _messageBoxResultCallback;

    public void ShowYesNoMessageBox(string messageText,
        EMessagePopUpIconType messagePopUpIconType = EMessagePopUpIconType.None,
        string yesText = "예",
        string noText = "아니오",
        Brush? yesBtnColor = null,
        Brush? noBtnColor = null,
        Action<bool?>? callback = null)
    {
        _messageBoxResultCallback = callback;

        if (_isYesNoMsgFirstEventHandler == false)
        {
            _isYesNoMsgFirstEventHandler = true;
            this.xMsgBox_YesNo.YesClick += (s, e) =>
            {
                if (_messageBoxResultCallback != null)
                    _messageBoxResultCallback(true);
                _messageBoxResultCallback = null;
            };
            this.xMsgBox_YesNo.NoClick += (s, e) =>
            {
                if (_messageBoxResultCallback != null)
                    _messageBoxResultCallback(false);
                _messageBoxResultCallback = null;
            };
        }

        this.xTxtMsgBoxYesNo.Text = messageText;
        this.xMsgBox_YesNo.YesText = yesText;
        this.xMsgBox_YesNo.NoText = noText;
        if (yesBtnColor == null)
        {
            this.xMsgBox_YesNo.YesBtnColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFD84C72")!);
        }
        else
        {
            this.xMsgBox_YesNo.YesBtnColor = yesBtnColor;
        }
        if (noBtnColor == null)
        {
            this.xMsgBox_YesNo.NoBtnColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF303A4D")!);
        }
        else
        {
            this.xMsgBox_YesNo.NoBtnColor = noBtnColor;
        }
        this.xMsgBox_YesNo.MessagePopUpIconType = messagePopUpIconType;
        this.xMsgBox_YesNo.IsOpen = true;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        this.xMsgBox_OK.IsOpen = true;
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        this.xMsgBox_YesNo.IsOpen = true;
    }
}