using System.Windows;
using HandyControl.Properties.Langs;

namespace HandyControl.Controls;

public partial class CalendarWithClock
{
    public static readonly DependencyProperty ConfirmButtonTextProperty = DependencyProperty.Register(
          "ConfirmButtonText", typeof(string), typeof(CalendarWithClock), new PropertyMetadata(Lang.Confirm));

    public string ConfirmButtonText
    {
        get => (string) GetValue(ConfirmButtonTextProperty);
        set => SetValue(ConfirmButtonTextProperty, value);
    }
}
