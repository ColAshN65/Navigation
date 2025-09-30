using CommunityToolkit.Mvvm.ComponentModel;

namespace Navigation.Example.ViewModel;

public partial class MainWindowViewModel : ObservableObject
{
    //Example of a child ViewModel
    [ObservableProperty]
    private ObservableObject _pageViewModel;

    public MainWindowViewModel()
    {
        //You can place any ViewModel instance here, as long as the corresponding View is accessible to the NavigationService.
        PageViewModel = new ControlPanelViewModel();
    }
}
