using CommunityToolkit.Mvvm.ComponentModel;
using MVVM_PopupSample.Enums;
using MVVM_PopupSample.ViewModels.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MVVM_PopupSample.Controls.MessagePopUpBox;

namespace MVVM_PopupSample.Base;

internal interface IViewAction
{
    /// <summary>
    /// 확인 메세지 박스 표시
    /// </summary>
    /// <param name="messageText"></param>
    /// <param name="messagePopUpIconType"></param>
    /// <param name="confirmText"></param>
    /// <param name="yesBtnColor"></param>
    /// <param name="callback"></param>
    public void ShowMessageBox(string messageText,
        EMessagePopUpIconType messagePopUpIconType = EMessagePopUpIconType.None,
        string confirmText = "확인",
        System.Windows.Media.Brush? confirmBtnColor = null,
        Action? callback = null);

    /// <summary>
    /// [예][아니오] 메세지 박스 표시
    /// </summary>
    /// <param name="messageText"></param>
    /// <param name="messageBoxType"></param>
    /// <param name="messagePopUpIconType"></param>
    /// <param name="yesText"></param>
    /// <param name="noText"></param>
    /// <param name="yesBtnColor"></param>
    /// <param name="noBtnColor"></param>
    /// <param name="callback"></param>
    public void ShowYesNoMessageBox(string messageText,
            EMessagePopUpIconType messagePopUpIconType = EMessagePopUpIconType.None,
            string yesText = "예",
            string noText = "아니오",
            System.Windows.Media.Brush? yesBtnColor = null,
            System.Windows.Media.Brush? noBtnColor = null,
            Action<bool?>? callback = null);

    public void CloseMessageBox();
}

// TODO : View에서 해당 View에 대한 액션 추상화를 ViewModel로 전달하는 용도로 사용
internal abstract class ViewModelBase<TViewAction> : ObservableObject
    where TViewAction : IViewAction
{
    public ViewModelBase(TViewAction view)
    {
        View = view;
    }

    public TViewAction View { get; private set; }
}