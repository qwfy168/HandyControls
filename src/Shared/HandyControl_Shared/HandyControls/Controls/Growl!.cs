using System.Windows;
using HandyControl.Data;

namespace HandyControl.Controls;
public partial class Growl
{
    public static readonly DependencyProperty ShowPersianDateTimeProperty = DependencyProperty.Register(
        "ShowPersianDateTime", typeof(bool), typeof(Growl), new PropertyMetadata(ValueBoxes.FalseBox));

    public bool ShowPersianDateTime
    {
        get => (bool) GetValue(ShowPersianDateTimeProperty);
        set => SetValue(ShowPersianDateTimeProperty, ValueBoxes.BooleanBox(value));
    }

}
