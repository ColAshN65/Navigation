using Navigation.Base;
using Navigation.Services.Reflective;

namespace Navigation.Factories;

public class DefaultReflectiveNavigationFactory : INavigationServiceFactory
{
    private ReflectiveNavigationSettings settings;

    public DefaultReflectiveNavigationFactory(ReflectiveNavigationSettings settings)
        => this.settings = settings;

    public INavigationService CreateService()
    {
        return new ReflectiveNavigationService(
            settings,
            new DefaultViewNamespaceTransformer(settings),
            new DefaultViewNameTransformer(settings));
    }
}
