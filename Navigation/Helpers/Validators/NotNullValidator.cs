

namespace Navigation.Helpers.Validators;

public static class NotNullValidator
{
    public static void Validate(object value)
    {
        if (value is null)
            throw new ArgumentNullException(nameof(value), "Value can not be null");
    }
}
