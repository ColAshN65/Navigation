using System.Windows;

namespace Navigation.Base;

/// <summary>
///     This service must provide an instance of the View class corresponding to the ViewModel type.
/// </summary>
public interface INavigationService
{
    public FrameworkElement LocateView(Type viewModelType);
}
