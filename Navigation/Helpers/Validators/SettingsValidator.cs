using Navigation.Services.Reflective;

namespace Navigation.Helpers.Validators;

public static class SettingsValidator
{
    public static void Validate(ReflectiveNavigationSettings settings)
    {
        if (settings == null)
            throw new ArgumentNullException(nameof(settings), "Locator settings must be not null");
        NotNullValidator.Validate(settings.ViewModelNamespace);
        NotNullValidator.Validate(settings.ViewNamespace);
        NotNullValidator.Validate(settings.ViewModelSuffix);
        NotNullValidator.Validate(settings.ViewSuffix);
        NotNullValidator.Validate(settings.ViewAssembly);
        NotNullValidator.Validate(settings.ViewModelAssembly);
    }
}
