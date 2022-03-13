using System.Windows;
using System.Windows.Media;

namespace HandyControl.Controls;
public partial class SideMenu
{
    public Brush SubSideBrush
    {
        get => (Brush) GetValue(SubSideBrushProperty);
        set => SetValue(SubSideBrushProperty, value);
    }
    public static readonly DependencyProperty SubSideBrushProperty =
        DependencyProperty.RegisterAttached("SubSideBrush", typeof(Brush), typeof(SideMenu), new FrameworkPropertyMetadata(default(Brushes), FrameworkPropertyMetadataOptions.Inherits));

    public Brush SideBrush
    {
        get => (Brush) GetValue(SideBrushProperty);
        set => SetValue(SideBrushProperty, value);
    }
    public static readonly DependencyProperty SideBrushProperty =
        DependencyProperty.RegisterAttached("SideBrush", typeof(Brush), typeof(SideMenu), new FrameworkPropertyMetadata(default(Brushes), FrameworkPropertyMetadataOptions.Inherits));

}
