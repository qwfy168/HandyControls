using System.Windows;
using HandyControl.Themes;

namespace HandyControl.Controls;
public partial class TabPanel
{
    public void UpdateMeasure()
    {
        ForceUpdate = true;
        Measure(new Size(DesiredSize.Width, ActualHeight));
        ForceUpdate = false;
        foreach (var item in ItemDic.Values)
        {
            item.TabPanel = this;
        }
    }

    // Fix https://github.com/ghost1372/HandyControls/issues/53
    // This fix should come with OnThemeChanged of the TabControl.cs
    private void OnThemeChanged(ThemeManager sender, object args)
    {
        UpdateMeasure();
    }
}
