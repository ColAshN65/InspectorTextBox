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
        /*public Style TextBoxStyle
        {
            get => (Style)GetValue(TextBoxStyleProperty);
            set => SetValue(TextBoxStyleProperty, value);
        }

        public Style RegularTextBoxStyle
        {
            get => (Style)GetValue(RegularTextBoxStyleProperty);
            set => SetValue(RegularTextBoxStyleProperty, value);
        }
        public Style NotReadyTextBoxStyle
        {
            get => (Style)GetValue(NotReadyTextBoxStyleProperty);
            set => SetValue(NotReadyTextBoxStyleProperty, value);
        }
        public Style NotificationStyle
        {
            get => (Style)GetValue(NotificationStyleProperty);
            set => SetValue(NotificationStyleProperty, value);
        }*/

        public InspectorBox()
        {
            //State = InspectorState.Ready;
            /*TextBoxStyle = new Style();
            NotificationStyle = new Style();*/
            InitializeComponent();
        }

        /*public void ReloadStyles()
        {
            if (ValueContainer is null)
                return;

            switch (ValueContainer.State)
            {
                case InspectorState.Validating:
                    break;
                case InspectorState.Ready:
                    InputTextBox.Style = RegularTextBoxStyle;
                    break;
                case InspectorState.Error:
                    InputTextBox.Style = NotReadyTextBoxStyle;
                    break;
                case InspectorState.Locked:
                    break;
            }
        }*/


        #region DependencyProperties

        public static readonly DependencyProperty ValueContainerProperty;
        public static readonly DependencyProperty StateProperty;

        public static readonly DependencyProperty TextBoxStyleProperty;
        public static readonly DependencyProperty NotificationStyleProperty;
        /*public static readonly DependencyProperty TextBoxStyleProperty;
        public static readonly DependencyProperty RegularTextBoxStyleProperty;
        public static readonly DependencyProperty NotReadyTextBoxStyleProperty;

        public static readonly DependencyProperty NotificationStyleProperty;*/

        static InspectorBox()
        {
            ValueContainerProperty = DependencyProperty.Register(
                        "ValueContainer",
                        typeof(InspectorContainer),
                        typeof(InspectorBox),
                        new FrameworkPropertyMetadata(
                            new InspectorContainer(),
                            FrameworkPropertyMetadataOptions.AffectsMeasure |
                            FrameworkPropertyMetadataOptions.AffectsRender,
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

            /*TextBoxStyleProperty = DependencyProperty.Register(
                "TextBoxStyle",
                typeof(Style),
                typeof(InspectorBox),
                new FrameworkPropertyMetadata(
                    new Style(),
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    new PropertyChangedCallback(Temp)));

            NotificationStyleProperty = DependencyProperty.Register(
                "NotificationStyle",
                typeof(Style),
                typeof(InspectorBox),
                new FrameworkPropertyMetadata(
                    new Style(),
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    new PropertyChangedCallback(Temp)));*/


            /*RegularTextBoxStyleProperty = DependencyProperty.Register(
                        "RegularTextBoxStyle",
                        typeof(Style),
                        typeof(InspectorTextBox),
                        new FrameworkPropertyMetadata(
                            new Style(),
                            FrameworkPropertyMetadataOptions.AffectsMeasure |
                            FrameworkPropertyMetadataOptions.AffectsRender,
                            new PropertyChangedCallback(TextBoxStyleChanged)));
            NotReadyTextBoxStyleProperty = DependencyProperty.Register(
                        "NotReadyTextBoxStyle",
                        typeof(Style),
                        typeof(InspectorTextBox),
                        new FrameworkPropertyMetadata(
                            new Style(),
                            FrameworkPropertyMetadataOptions.AffectsMeasure |
                            FrameworkPropertyMetadataOptions.AffectsRender,
                            new PropertyChangedCallback(TextBoxStyleChanged)));
            NotificationStyleProperty = DependencyProperty.Register(
                        "NotificationStyle",
                        typeof(Style),
                        typeof(InspectorTextBox),
                        new FrameworkPropertyMetadata(
                            new Style(),
                            FrameworkPropertyMetadataOptions.AffectsMeasure |
                            FrameworkPropertyMetadataOptions.AffectsRender,
                            new PropertyChangedCallback(NotificationStyleChanged)));*/
        }

        private static void Temp(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        /*private static void TextBoxStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            InspectorTextBox sender = (InspectorTextBox)d;
            sender.ReloadStyles();
        }*/

        private static void ContainerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            InspectorContainer newValue = (InspectorContainer)e.NewValue;
            ((InspectorContainer)e.OldValue).Dispose();

            InspectorBox sender = (InspectorBox)d;

            newValue.StateChanged += sender.OnStateChanged;
            //sender.ReloadStyles();
        }

        private void OnStateChanged(object sender, InspectorEventArgs e)
        {
            State = e.State;
        }
        /*private static void NotificationStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
{
   InspectorTextBox sender = (InspectorTextBox)d;
   sender.NotifyLabel.Style = (Style)e.NewValue;
}*/
        #endregion
    }
}
