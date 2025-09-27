
namespace InspectorTextBox.Example.Validators;

public class EmptyValidator : IInspectorValidator
{
    public async Task<string?> ValidateAsync(string value)
    {
        return await Task.Run(() => {
            if (value is "")
                return "Value cannot be empty";
            else
                return null;
        });
    }
}
