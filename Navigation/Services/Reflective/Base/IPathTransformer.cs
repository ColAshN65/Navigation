using System.Text;

namespace Navigation.Services.Reflective.Base;

public interface IPathTransformer
{
    public StringBuilder Transform(StringBuilder boundNamespace);
}
