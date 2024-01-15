namespace TellarknightApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);

            const int newWidth = 1400;
            const int newHeight = 750;

            window.Width = newWidth;
            window.Height = newHeight;
            window.MinimumWidth = newWidth;
            window.MinimumHeight = newHeight;
            window.MaximumWidth = newWidth;
            window.MaximumHeight = newHeight;

            return window;
        }
    }
}
