using CommunityToolkit.Mvvm.ComponentModel;
using InspectorTextBox.Example.Validators;

namespace InspectorTextBox.Example.ViewModel;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private InspectorContainer _mainContainer;

    public MainWindowViewModel()
    {
        MainContainer = new InspectorContainer([
            new NullValidator(),
            new EmptyValidator(),
            new MinStringLengthValidator(3),
            new NoHelloValidator(),
            new MaxStringLengthValidator(10)],
            "Hello");
    }
}
