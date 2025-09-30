using CommunityToolkit.Mvvm.ComponentModel;

namespace Navigation.Example.ViewModel;

public partial class OutputItemHViewModel : ObservableObject
{
    [ObservableProperty]
    private string _output;

    //It just outputs the value.
    public OutputItemHViewModel(string value)
        => Output = value;
}
