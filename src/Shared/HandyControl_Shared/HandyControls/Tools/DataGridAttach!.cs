using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using HandyControl.Data;

namespace HandyControl.Controls;

public partial class DataGridAttach
{
    internal static readonly DependencyProperty IsSelectAllProperty =
            DependencyProperty.RegisterAttached("IsSelectAll", typeof(bool), typeof(DataGridAttach), new PropertyMetadata(false,
                (o, e) =>
                {
                    var dg = GetCurrentDataGrid(o);
                    ToggleButton tg = o as ToggleButton;

                    if (dg.SelectionMode != DataGridSelectionMode.Single)
                    {
                        if (dg.SelectedItems.Count < 2)
                        {
                            tg.IsChecked = true;
                        }

                        if (tg.IsChecked == true)
                        {
                            dg.SelectAll();
                        }
                        else
                        {
                            dg.UnselectAll();
                        }
                    }

                }));
    internal static bool GetIsSelectAll(DependencyObject obj)
    {
        return (bool) obj.GetValue(IsSelectAllProperty);
    }

    internal static void SetIsSelectAll(DependencyObject obj, bool value)
    {
        obj.SetValue(IsSelectAllProperty, value);
    }

    internal static readonly DependencyProperty CurrentDataGridProperty =
        DependencyProperty.RegisterAttached("CurrentDataGrid", typeof(DataGrid), typeof(DataGridAttach), new PropertyMetadata(null));

    internal static DataGrid GetCurrentDataGrid(DependencyObject obj)
    {
        return (DataGrid) obj.GetValue(CurrentDataGridProperty);
    }

    internal static void SetCurrentDataGrid(DependencyObject obj, DataGrid value)
    {
        obj.SetValue(CurrentDataGridProperty, value);
    }

    public static DependencyProperty ShowRowNumberProperty = DependencyProperty.RegisterAttached("ShowRowNumber",
        typeof(bool), typeof(DataGridAttach),
        new FrameworkPropertyMetadata(ValueBoxes.FalseBox, FrameworkPropertyMetadataOptions.Inherits, OnShowRowNumberChanged));

    public static bool GetShowRowNumber(DependencyObject target) => (bool) target.GetValue(ShowRowNumberProperty);

    public static void SetShowRowNumber(DependencyObject target, bool value) => target.SetValue(ShowRowNumberProperty, ValueBoxes.BooleanBox(value));

    private static void OnShowRowNumberChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
    {
        if (target is not DataGrid dataGrid) return;
        var show = (bool) e.NewValue;

        if (show)
        {
            dataGrid.LoadingRow += DataGrid_LoadingRow;
            dataGrid.ItemContainerGenerator.ItemsChanged += ItemContainerGeneratorItemsChanged;
        }
        else
        {
            dataGrid.LoadingRow -= DataGrid_LoadingRow;
            dataGrid.ItemContainerGenerator.ItemsChanged -= ItemContainerGeneratorItemsChanged;
        }

        void ItemContainerGeneratorItemsChanged(object sender, ItemsChangedEventArgs e)
        {
            var generator = dataGrid.ItemContainerGenerator;
            var itemsCount = dataGrid.Items.Count;

            if (show)
            {
                for (var i = 0; i < itemsCount; i++)
                {
                    var row = (DataGridRow) generator.ContainerFromIndex(i);
                    if (row != null)
                    {
                        row.Header = (i + 1).ToString();
                    }
                }
            }
            else
            {
                for (var i = 0; i < itemsCount; i++)
                {
                    var row = (DataGridRow) generator.ContainerFromIndex(i);
                    if (row != null)
                    {
                        row.Header = null;
                    }
                }
            }
        }
    }
}
