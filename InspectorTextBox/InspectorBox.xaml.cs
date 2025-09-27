using InspectorTextBox.Events;
using System.Windows;
using System.Windows.Controls;

namespace InspectorTextBox
{
    public partial class InspectorBox : UserControl
    {
        public InspectorState State
        {
            get => (InspectorState)GetValue(StateProperty);
            set => SetValue(StateProperty, value);
        }
        public InspectorContainer ValueContainer
        {
            get => (InspectorContainer)GetValue(ValueContainerProperty);
            set => SetValue(ValueContainerProperty, value);
        }


        public Style TextBoxStyle
        {
            get => (Style)GetValue(TextBoxStyleProperty);
            set => SetValue(TextBoxStyleProperty, value);
        }
        public Style NotificationStyle
        {
            get => (Style)GetValue(TextBoxStyleProperty);
            set => SetValue(TextBoxStyleProperty, value);
        }


        public InspectorBox()
        {
            InitializeComponent();
        }

        private void OnStateChanged(object sender, InspectorEventArgs e)
        {
            State = e.State;
        }
        private static void ContainerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            InspectorContainer newValue = (InspectorContainer)e.NewValue;

            InspectorBox sender = (InspectorBox)d;

            newValue.StateChanged += sender.OnStateChanged;
        }

        #region DependencyProperties

        public static readonly DependencyProperty ValueContainerProperty;
        public static readonly DependencyProperty StateProperty;

        public static readonly DependencyProperty TextBoxStyleProperty;
        public static readonly DependencyProperty NotificationStyleProperty;

        static InspectorBox()
        {
            ValueContainerProperty = DependencyProperty.Register(
                        "ValueContainer",
                        typeof(InspectorContainer),
                        typeof(InspectorBox),
                        new FrameworkPropertyMetadata(
                            new InspectorContainer(),
                            new PropertyChangedCallback(ContainerChanged)));

            StateProperty = DependencyProperty.Register(
                "State",
                typeof(InspectorState),
                typeof(InspectorBox));

            TextBoxStyleProperty = DependencyProperty.Register(
                "TextBoxStyle",
                typeof(Style),
                typeof(InspectorBox),
                new FrameworkPropertyMetadata(new Style()));

            NotificationStyleProperty = DependencyProperty.Register(
                "NotificationStyle",
                typeof(Style),
                typeof(InspectorBox),
                new FrameworkPropertyMetadata(new Style()));
        }
        #endregion
    }
}
