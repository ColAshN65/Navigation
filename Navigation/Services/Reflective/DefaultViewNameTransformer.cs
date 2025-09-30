using Navigation.Services.Reflective.Base;
using System.Text;

namespace Navigation.Services.Reflective;

public class DefaultViewNameTransformer : IPathTransformer
{
    public DefaultViewNameTransformer(ReflectiveNavigationSettings settings)
        => this.settings = settings;

    public StringBuilder Transform(StringBuilder boundName)
    {
        boundName.Replace(settings.ViewModelSuffix, settings.ViewSuffix);
        return boundName;
    }

    private ReflectiveNavigationSettings settings;
}
