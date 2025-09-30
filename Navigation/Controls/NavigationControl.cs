using Navigation.Base;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Navigation.Controls;

/// <summary>
///     If the class instance receives an instance of the <see cref="INotifyPropertyChanged"/> implementation as its <see cref="ViewModel"/>,
///     it will set the Content to the instance of the View class obtained using the static <see cref="INavigationService"/>.
/// </summary>
public class NavigationControl : UserControl
{
    public INotifyPropertyChanged ViewModel
    {
        get => (INotifyPropertyChanged)GetValue(ViewModelProperty);
        set => SetValue(ViewModelProperty, value);
    }

    //TODO Адаптировать под человеческое внедрение зависимостей.
    public static INavigationService NavigationService;

    private static void NavigationCollectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        NavigationControl sender = (NavigationControl)d;

        if (e.NewValue is not null && e.NewValue is INotifyPropertyChanged viewModel)
        {
            var view = NavigationService.LocateView(viewModel.GetType());
            view.DataContext = viewModel;
            sender.Content = view;
        }
        else
            sender.Content = null;
    }

    #region DependencyProperties
    public static readonly DependencyProperty ViewModelProperty;

    static NavigationControl()
    {
        ViewModelProperty = DependencyProperty.Register(
            "ViewModel",
            typeof(INotifyPropertyChanged),
            typeof(NavigationControl),
            new FrameworkPropertyMetadata(
                new PropertyChangedCallback(NavigationCollectionChanged)));
    }
    #endregion
}
