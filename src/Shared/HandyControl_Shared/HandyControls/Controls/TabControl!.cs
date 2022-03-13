using HandyControl.Themes;

namespace HandyControl.Controls;

public partial class TabControl
{
    public TabControl()
    {
        ThemeManager.Current.ActualApplicationThemeChanged += OnThemeChanged;
    }

    private void OnThemeChanged(ThemeManager sender, object args)
    {
        // Fix https://github.com/HandyOrg/HandyControl/issues/738
        Items.Refresh();
    }
}

