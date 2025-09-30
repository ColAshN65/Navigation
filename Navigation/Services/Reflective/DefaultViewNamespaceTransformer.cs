using Navigation.Services.Reflective.Base;
using System.Text;

namespace Navigation.Services.Reflective;

public class DefaultViewNamespaceTransformer : IPathTransformer
{
    public DefaultViewNamespaceTransformer(ReflectiveNavigationSettings settings)
        => this.settings = settings;
    public StringBuilder Transform(StringBuilder boundNamespace)
    {
        boundNamespace.Replace(settings.ViewModelNamespace, settings.ViewNamespace);
        return boundNamespace;
    }

    private ReflectiveNavigationSettings settings;
}
