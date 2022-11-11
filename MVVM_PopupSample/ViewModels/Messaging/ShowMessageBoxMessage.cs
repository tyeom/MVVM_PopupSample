using CommunityToolkit.Mvvm.Messaging.Messages;
using MVVM_PopupSample.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MVVM_PopupSample.ViewModels.Messaging;

public class MessageBoxInfo
{
    public String MessageText { get; set; }
    public EMessagePopUpIconType MessagePopUpIconType { get; set; }
    public string YesText { get; set; }
    public string NoText { get; set; }
    public Brush? YesBtnColor { get; set; }
    public Brush? NoBtnColor { get; set; }
    public Action? ConfirmCallback { get; set; }
    public Action<bool?>? Callback { get; set; }
}

public class ShowMessageBoxMessage : ValueChangedMessage<MessageBoxInfo>
{
    public ShowMessageBoxMessage(MessageBoxInfo messageBoxInfo) : base(messageBoxInfo) { }
}