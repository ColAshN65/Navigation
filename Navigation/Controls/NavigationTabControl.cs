using Navigation.Base;
using Navigation.Helpers.Events;
using Navigation.Services;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Navigation.Controls;
/// <summary>
///     If a class instance receives a <see cref="NavigationCollection"/> instance as its <see cref="Collection"/>, 
///     it subscribes to its events. The instance's Items will contain the corresponding <see cref="NavigationCollection"/> instances of View classes, 
///     which it obtains using the static <see cref="INavigationService"/>.
/// </summary>
public class NavigationTabControl : TabControl
{
    public INavigationCollection Collection
    {
        get => (INavigationCollection)GetValue(CollectionProperty);
        set => SetValue(CollectionProperty, value);
    }

    //TODO Адаптировать под человеческое внедрение зависимостей.
    public static INavigationService NavigationService;

    private static void NavigationCollectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue is not null && e.NewValue is INavigationCollection navigationCollection)
        {
            NavigationTabControl sender = (NavigationTabControl)d;
            navigationCollection.ItemAdded += sender.OnViewModelAdded;
            navigationCollection.ItemDeleted += sender.OnViewModelDeleted;
            navigationCollection.ItemInserted += sender.OnViewModelInserted;
        }
    }

    private void OnViewModelAdded(object sender, ItemChangedEventArgs<INotifyPropertyChanged> e)
    {
        TabItem tabItem = (TabItem)NavigationService.LocateView(e.Item.GetType());
        tabItem.DataContext = e.Item;
        Items.Add(tabItem);
    }
    private void OnViewModelInserted(object sender, ItemChangedEventArgs<INotifyPropertyChanged> e)
    {
        TabItem tabItem = (TabItem)NavigationService.LocateView(e.Item.GetType());
        tabItem.DataContext = e.Item;
        Items.Insert(e.Index, tabItem);
    }
    private void OnViewModelDeleted(object sender, ItemChangedEventArgs<INotifyPropertyChanged> e)
    {
        Items.RemoveAt(e.Index);
    }
    
    #region DependencyProperties
    public static readonly DependencyProperty CollectionProperty;

    static NavigationTabControl()
    {
        CollectionProperty = DependencyProperty.Register(
            "Collection",
            typeof(INavigationCollection),
            typeof(NavigationTabControl),
            new FrameworkPropertyMetadata(
                new PropertyChangedCallback(NavigationCollectionChanged)));
    }
    #endregion
}
