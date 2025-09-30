using Navigation.Helpers.Validators;
using System.Reflection;

namespace Navigation.Services.Reflective;

public class ReflectiveNavigationSettings
{
    #region Backing fields

    private string _viewNamespace;
    private string _viewModelNamespace;
    private string _viewSuffix;
    private string _viewModelSuffix;
    private Assembly _viewAssembly;
    private Assembly _viewModelAssembly;

    #endregion

    #region Properties

    public string ViewNamespace
    {
        get => _viewNamespace;
        set
        {
            NotNullValidator.Validate(value);
            _viewNamespace = value;
        }
    }
    public string ViewModelNamespace
    {
        get => _viewModelNamespace;
        set
        {
            NotNullValidator.Validate(value);
            _viewModelNamespace = value;
        }
    }
    public string ViewSuffix
    {
        get => _viewSuffix;
        set
        {
            NotNullValidator.Validate(value);
            _viewSuffix = value;
        }
    }
    public string ViewModelSuffix
    {
        get => _viewModelSuffix;
        set
        {
            NotNullValidator.Validate(value);
            _viewModelSuffix = value;
        }
    }
    public Assembly ViewAssembly
    {
        get => _viewAssembly;
        set
        {
            NotNullValidator.Validate(value);
            _viewAssembly = value;
        }
    }
    public Assembly ViewModelAssembly
    {
        get => _viewModelAssembly;
        set
        {
            NotNullValidator.Validate(value);
            _viewModelAssembly = value;
        }
    }

    #endregion

    public ReflectiveNavigationSettings(string viewNamespace,
        string viewModelNamespace,
        string viewSuffix, string viewModelSuffix,
        Assembly viewAssembly, Assembly viewModelAssembly)
    {
        ViewNamespace = viewNamespace;
        ViewModelNamespace = viewModelNamespace;
        ViewSuffix = viewSuffix;
        ViewModelSuffix = viewModelSuffix;
        ViewAssembly = viewAssembly;
        ViewModelAssembly = viewModelAssembly;
    }
}
