namespace HandyControl.Controls;

public partial class ColorPicker
{
    internal static ColorPicker cPicker;

    public static void IsCheckedToggleButtonDropper(bool value)
    {
        ColorPicker.cPicker._toggleButtonDropper.IsChecked = value;
    }
}
