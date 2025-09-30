using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Navigation.Services;

namespace Navigation.Example.ViewModel;

public partial class ControlPanelViewModel : ObservableObject
{
    [ObservableProperty]
    private int _selectedIndex;


    //Example of a collection of child ViewModels.
    public NavigationCollection<OutputItemHViewModel> OutputTabs { get; set; }
        = new NavigationCollection<OutputItemHViewModel>();

    [RelayCommand]
    private void Add()
    {
        if(OutputTabs.Count < 10)
            OutputTabs.Add( //You can place any ViewModel instance here, as long as the corresponding View is accessible to the NavigationService.
                new OutputItemHViewModel(
                    Guid.NewGuid().ToString() //This generates a random value for clarity.
                    ));
    }

    [RelayCommand]
    private void Remove()
    {
        if (OutputTabs.Count > 1)
            OutputTabs.RemoveAt(SelectedIndex);
    }
}
