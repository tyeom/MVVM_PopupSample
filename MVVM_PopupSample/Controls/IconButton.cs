using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace MVVM_PopupSample.Controls;

public class IconButton : Button
{
    public IconButton()
    {
        DefaultStyleKey = typeof(IconButton);
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
    }

    public static readonly DependencyProperty? IconImageProperty =
      DependencyProperty.Register("IconImage", typeof(ImageSource), typeof(IconButton));
    public ImageSource? IconImage
    {
        get { return base.GetValue(IconImageProperty) as ImageSource; }
        set { base.SetValue(IconImageProperty, value); }
    }

    public static readonly DependencyProperty? TextProperty =
      DependencyProperty.Register("Text", typeof(String), typeof(IconButton));
    public string? Text
    {
        get { return base.GetValue(TextProperty) as String; }
        set { base.SetValue(TextProperty, value); }
    }
}