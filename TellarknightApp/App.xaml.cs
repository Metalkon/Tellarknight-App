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

            window.Width = 640;
            window.Height = 800;
            //window.MaximumWidth = 640;
            //window.MaximumHeight = 800;
            //window.MinimumWidth = 640;
            //window.MinimumHeight = 800;
            return window;

        }
    }
}
