using CommunityToolkit.Mvvm.ComponentModel;
using InspectorTextBox.Example.Validators;

namespace InspectorTextBox.Example.ViewModel;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private InspectorContainer _mainContainer;

    public MainWindowViewModel()
    {
        var validators = new List<IInspectorValidator>()
        {
            new NullValidator(),
            new EmptyValidator(),
            new MinStringLengthValidator(3),
            new MaxStringLengthValidator(10)
        };

        MainContainer = new InspectorContainer(validators, "Hello");

        validators.Add(new NoHelloValidator());
    }
}
