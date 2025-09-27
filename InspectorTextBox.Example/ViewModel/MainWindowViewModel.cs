using CommunityToolkit.Mvvm.ComponentModel;
using InspectorTextBox.Events;
using InspectorTextBox.Example.Validators;
using System.Diagnostics;

namespace InspectorTextBox.Example.ViewModel;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private InspectorContainer _mainContainer;

    public MainWindowViewModel()
    {
        //Collection is declared in a lower-level class that is responsible for disposing of specific validators.
        //It may be used in multiple InspectorBoxes.
        var validators = new List<IInspectorValidator>()
        {
            new NullValidator(),
            new EmptyValidator(),
            new MinStringLengthValidator(3),
            new MaxStringLengthValidator(10)
        };

        MainContainer = new InspectorContainer(validators, "Hello");

        //Сollection may be modified or replaced.
        validators.Add(new NoHelloValidator());

        //Container can notify a lower-level class about changes.
        MainContainer.ValueChanged += OnValueChanged;
        MainContainer.StateChanged += OnStateChanged;
    }

    private void OnStateChanged(object sender, InspectorEventArgs e)
    {
        Debug.WriteLine("New STATE: " + e.State);
    }

    private void OnValueChanged(object sender, InspectorEventArgs e)
    {
        Debug.WriteLine("New VALUE: " + e.Value);
    }
}
