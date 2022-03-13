using System.Windows;

namespace HandyControl.Controls;

public partial class DateTimePicker
{
    public static readonly DependencyProperty ConfirmButtonTextProperty =
           CalendarWithClock.ConfirmButtonTextProperty.AddOwner(typeof(DateTimePicker));

    public string ConfirmButtonText
    {
        get { return (string) GetValue(ConfirmButtonTextProperty); }
        set { SetValue(ConfirmButtonTextProperty, value); }
    }
}
