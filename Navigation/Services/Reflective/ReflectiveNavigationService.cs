using Navigation.Base;
using Navigation.Helpers.Exceptions;
using Navigation.Services.Reflective.Base;
using System.Text;
using System.Windows;

namespace Navigation.Services.Reflective;

/// <summary>
///     This implementation of <see cref="INavigationService"/> will search for matching View types using reflection.
/// </summary>
public class ReflectiveNavigationService : INavigationService
{
    public ReflectiveNavigationSettings Settings;
    private IPathTransformer NamespaceTransformer;
    private IPathTransformer NameTransformer;

    public ReflectiveNavigationService(
        ReflectiveNavigationSettings settings, 
        IPathTransformer namespaceTransformer, 
        IPathTransformer nameTransformer)
    {
        if (settings is null)
            throw new ArgumentNullException(nameof(settings));

        Settings = settings;
        NamespaceTransformer = namespaceTransformer;
        NameTransformer = nameTransformer;
    }

    public FrameworkElement LocateView(Type viewModelType)
    {
        StringBuilder path = new StringBuilder(viewModelType.Namespace);
        if (NamespaceTransformer != null)
            path = NamespaceTransformer.Transform(path);
        path.Append(".");

        StringBuilder viewName = new StringBuilder(viewModelType.Name);
        if (NameTransformer != null)
            viewName = NameTransformer.Transform(viewName);
        path.Append(viewName);

        var stringPath = path.ToString();
        var type = Settings.ViewAssembly.GetType(stringPath);

        if (type == null)
            throw new InstanceInitializeFailException($"View type not found. ({stringPath})");

        var constructors = type.GetConstructors();

        try
        {
            var result = constructors[0].Invoke([]);
            return (FrameworkElement)result;
        }
        catch (Exception ex)
        {
            throw new InstanceInitializeFailException($"The Instance of {type} cannot be initialized.");
        }
    }
}
