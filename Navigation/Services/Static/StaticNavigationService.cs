using Navigation.Base;
using Navigation.Helpers.Exceptions;
using System.Windows;

namespace Navigation.Services.Static;

/// <summary>
/// This implementation of <see cref="INavigationService"/> will search for matching View types in the Dictionary.
/// </summary>
public class StaticNavigationService : INavigationService
{
    public StaticNavigationService(Dictionary<Type, Type> mvvmPairs)
    {
        this.mvvmPairs = mvvmPairs;
    }
    public FrameworkElement LocateView(Type viewModelType)
    {
        if (mvvmPairs.TryGetValue(viewModelType, out var viewType))
        {
            var constructors = viewType.GetConstructors();

            try
            {
                var result = constructors[0].Invoke([]);
                return (FrameworkElement)result;
            }
            catch (Exception ex)
            {
                throw new InstanceInitializeFailException($"The Instance of {viewType} cannot be initialized.");
            }
        }
        else
        {
            throw new InstanceInitializeFailException($"No matching View type found for {viewModelType}");
        }

    }

    private Dictionary<Type, Type> mvvmPairs;
}
