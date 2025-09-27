namespace InspectorTextBox.Example.Validators;

public class NoHelloValidator : IInspectorValidator
{
    public async Task<string?> ValidateAsync(string value)
    {
        return await Task.Run(() => {
            if (value is "Hello")
                return "-_-";
            else
                return null;
        });
    }
}
