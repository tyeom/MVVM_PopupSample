using MVVM_PopupSample.Enums;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace MVVM_PopupSample.Controls;

public class MessagePopUpBox : UserControl
{
    public event RoutedEventHandler? OKClick;
    public event RoutedEventHandler? NoClick;
    public event RoutedEventHandler? YesClick;

    public MessagePopUpBox()
    {
        DefaultStyleKey = typeof(MessagePopUpBox);
    }

    #region Control Dependency Properties
    public static readonly DependencyProperty MessagePopUpBoxTypeProperty =
      DependencyProperty.Register("MessagePopUpBoxType", typeof(EMessagePopUpBoxType), typeof(MessagePopUpBox));
    public EMessagePopUpBoxType MessagePopUpBoxType
    {
        get { return (EMessagePopUpBoxType)this.GetValue(MessagePopUpBoxTypeProperty); }
        set { this.SetValue(MessagePopUpBoxTypeProperty, value); }
    }

    public static readonly DependencyProperty MessagePopUpIconTypeProperty =
      DependencyProperty.Register("MessagePopUpIconType", typeof(EMessagePopUpIconType), typeof(MessagePopUpBox));
    public EMessagePopUpIconType MessagePopUpIconType
    {
        get { return (EMessagePopUpIconType)this.GetValue(MessagePopUpIconTypeProperty); }
        set { this.SetValue(MessagePopUpIconTypeProperty, value); }
    }

    public static readonly DependencyProperty IsOpenProperty =
      DependencyProperty.Register("IsOpen", typeof(bool), typeof(MessagePopUpBox));
    public bool IsOpen
    {
        get { return (bool)this.GetValue(IsOpenProperty); }
        set { this.SetValue(IsOpenProperty, value); }
    }

    public static readonly DependencyProperty IsBackgroundDisableProperty =
      DependencyProperty.Register("IsBackgroundDisable", typeof(bool), typeof(MessagePopUpBox), new PropertyMetadata(false));
    public bool IsBackgroundDisable
    {
        get { return (bool)this.GetValue(IsBackgroundDisableProperty); }
        set { this.SetValue(IsBackgroundDisableProperty, value); }
    }

    public static readonly DependencyProperty MsgBoxPlacementTargetProperty =
        DependencyProperty.Register(
            "MsgBoxPlacementTarget",
            typeof(UIElement),
            typeof(MessagePopUpBox),
            new FrameworkPropertyMetadata(
                null, OnMsgBoxPlacementTargetPropertyChanged
                ));
    public UIElement MsgBoxPlacementTarget
    {
        get { return (UIElement)this.GetValue(MsgBoxPlacementTargetProperty); }
        set { this.SetValue(MsgBoxPlacementTargetProperty, (object)value); }
    }

    public static readonly DependencyProperty VAlignmentProperty =
      DependencyProperty.Register("VAlignment", typeof(VerticalAlignment), typeof(MessagePopUpBox), new PropertyMetadata(VerticalAlignment.Bottom));
    public VerticalAlignment VAlignment
    {
        get { return (VerticalAlignment)this.GetValue(VAlignmentProperty); }
        set { this.SetValue(VAlignmentProperty, value); }
    }

    public static readonly DependencyProperty HAlignmentProperty =
      DependencyProperty.Register("HAlignment", typeof(HorizontalAlignment), typeof(MessagePopUpBox), new PropertyMetadata(HorizontalAlignment.Right));
    public HorizontalAlignment HAlignment
    {
        get { return (HorizontalAlignment)this.GetValue(HAlignmentProperty); }
        set { this.SetValue(HAlignmentProperty, value); }
    }

    public static readonly DependencyProperty ConfirmTextProperty =
      DependencyProperty.Register("ConfirmText", typeof(String), typeof(MessagePopUpBox), new PropertyMetadata("확인"));
    public String ConfirmText
    {
        get { return (String)this.GetValue(ConfirmTextProperty); }
        set { this.SetValue(ConfirmTextProperty, value); }
    }

    public static readonly DependencyProperty YesTextProperty =
      DependencyProperty.Register("YesText", typeof(String), typeof(MessagePopUpBox), new PropertyMetadata("예"));
    public String YesText
    {
        get { return (String)this.GetValue(YesTextProperty); }
        set { this.SetValue(YesTextProperty, value); }
    }

    public static readonly DependencyProperty NoTextProperty =
      DependencyProperty.Register("NoText", typeof(String), typeof(MessagePopUpBox), new PropertyMetadata("아니오"));
    public String NoText
    {
        get { return (String)this.GetValue(NoTextProperty); }
        set { this.SetValue(NoTextProperty, value); }
    }

    public static readonly DependencyProperty YesBtnColorProperty =
      DependencyProperty.Register("YesBtnColor", typeof(Brush), typeof(MessagePopUpBox), new PropertyMetadata((SolidColorBrush)(new BrushConverter().ConvertFrom("#FFD84C72"))!));
    public Brush YesBtnColor
    {
        get { return (Brush)this.GetValue(YesBtnColorProperty); }
        set { this.SetValue(YesBtnColorProperty, value); }
    }

    public static readonly DependencyProperty NoBtnColorProperty =
      DependencyProperty.Register("NoBtnColor", typeof(Brush), typeof(MessagePopUpBox), new PropertyMetadata((SolidColorBrush)(new BrushConverter().ConvertFrom("#FF303A4D"))!));
    public Brush NoBtnColor
    {
        get { return (Brush)this.GetValue(NoBtnColorProperty); }
        set { this.SetValue(NoBtnColorProperty, value); }
    }
    #endregion  // Control Dependency Properties

    #region Command attached properties
    public ICommand NoCommand
    {
        get
        {
            return (ICommand)GetValue(NoCommandProperty);
        }
        set
        {
            SetValue(NoCommandProperty, value);
        }
    }

    public object NoCommandParameter
    {
        get { return (object)this.GetValue(NoCommandParameterProperty); }
        set { this.SetValue(NoCommandParameterProperty, value); }
    }

    public ICommand YesCommand
    {
        get
        {
            return (ICommand)GetValue(YesCommandProperty);
        }
        set
        {
            SetValue(YesCommandProperty, value);
        }
    }

    public object YesCommandParameter
    {
        get { return (object)this.GetValue(YesCommandParameterProperty); }
        set { this.SetValue(YesCommandParameterProperty, value); }
    }

    public ICommand ConfirmCommand
    {
        get
        {
            return (ICommand)GetValue(ConfirmCommandProperty);
        }
        set
        {
            SetValue(ConfirmCommandProperty, value);
        }
    }

    public object ConfirmCommandParameter
    {
        get { return (object)this.GetValue(ConfirmCommandParameterProperty); }
        set { this.SetValue(ConfirmCommandParameterProperty, value); }
    }

    #endregion  // Command attached properties

    #region Command Dependency Properties

    public static readonly DependencyProperty NoCommandProperty =
        DependencyProperty.Register(
            "NoCommand",
            typeof(ICommand),
            typeof(MessagePopUpBox),
            new UIPropertyMetadata(null));

    public static readonly DependencyProperty NoCommandParameterProperty =
        DependencyProperty.RegisterAttached(
            "NoCommandParameter",
            typeof(object),
            typeof(MessagePopUpBox),
            new UIPropertyMetadata(null));

    public static readonly DependencyProperty YesCommandProperty =
        DependencyProperty.Register(
            "YesCommand",
            typeof(ICommand),
            typeof(MessagePopUpBox),
            new UIPropertyMetadata(null));

    public static readonly DependencyProperty YesCommandParameterProperty =
        DependencyProperty.RegisterAttached(
            "YesCommandParameter",
            typeof(object),
            typeof(MessagePopUpBox),
            new UIPropertyMetadata(null));

    public static readonly DependencyProperty ConfirmCommandProperty =
        DependencyProperty.Register(
            "ConfirmCommand",
            typeof(ICommand),
            typeof(MessagePopUpBox),
            new UIPropertyMetadata(null));

    public static readonly DependencyProperty ConfirmCommandParameterProperty =
        DependencyProperty.RegisterAttached(
            "ConfirmCommandParameter",
            typeof(object),
            typeof(MessagePopUpBox),
            new UIPropertyMetadata(null));

    #endregion  // Command Dependency Properties

    private static void OnMsgBoxPlacementTargetPropertyChanged(
        DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        MessagePopUpBox messagePopUpBox = d as MessagePopUpBox;
        messagePopUpBox.MsgBoxPlacementTarget.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(messagePopUpBox.OnClick), true);

        //MouseDevice mouseDevice = Mouse.PrimaryDevice;
        //MouseButtonEventArgs mouseButtonEventArgs = new MouseButtonEventArgs(mouseDevice, 0, MouseButton.Left);
        //mouseButtonEventArgs.RoutedEvent = Mouse.MouseDownEvent;
        //mouseButtonEventArgs.Source = messagePopUpBox.MsgBoxPlacementTarget;
        //messagePopUpBox.MsgBoxPlacementTarget.RaiseEvent(mouseButtonEventArgs);
    }

    private void OnClick(object sender, RoutedEventArgs e)
    {
        // IsOpen = true;
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        Button? okBtn = GetTemplateChild("xOKBtn") as Button;
        okBtn!.Click += new RoutedEventHandler(delegate (Object s, RoutedEventArgs e)
        {
            IsOpen = false;
            if (OKClick != null)
                OKClick(this, new RoutedEventArgs());
        });

        Button? yesBtn = GetTemplateChild("xYesBtn") as Button;
        yesBtn!.Click += new RoutedEventHandler(delegate (Object s, RoutedEventArgs e)
        {
            IsOpen = false;
            if (YesClick != null)
                YesClick(this, new RoutedEventArgs());
        });

        Button? noBtn = GetTemplateChild("xNoBtn") as Button;
        noBtn!.Click += new RoutedEventHandler(delegate (Object s, RoutedEventArgs e)
        {
            IsOpen = false;
            if (NoClick != null)
                NoClick(this, new RoutedEventArgs());
        });
    }
}