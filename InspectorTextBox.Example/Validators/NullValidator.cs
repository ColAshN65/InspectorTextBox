
namespace InspectorTextBox.Example.Validators;

public class NullValidator : IInspectorValidator
{
    public async Task<string?> ValidateAsync(string value)
    {
        return await Task.Run(() => {
            if (value is null)
                return "Value cannot be null";
            else
                return null;
        });
    }
}
