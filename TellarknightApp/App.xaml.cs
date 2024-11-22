using CommunityToolkit.Maui.Core;

namespace TellarknightApp
{
    public partial class App : Application
    {
        string version = AppInfo.Current.Version.ToString();

        public App()
        {

            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);
            window.Title = $"Tellarknight Statistics v{version}";

            return window;
        }
    }
}
