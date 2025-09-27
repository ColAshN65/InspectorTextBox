namespace InspectorTextBox.Example.Validators;

public class NoHelloValidator : IInspectorValidator, IDisposable
{
    //It only for example
    public void Dispose()
    {

    }

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
