using Android.App;
using Android.Content.PM;
using Android.OS;

namespace TellarknightApp
{
    [Activity(
        Theme = "@style/Maui.SplashTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var resourceId = Resources?.GetIdentifier("status_bar_height", "dimen", "android");
            if (resourceId > 0)
            {
                var statusBarHeight = Resources!.GetDimensionPixelSize(resourceId.Value);
                var density = Resources.DisplayMetrics?.Density ?? 1f;
                var statusBarDp = statusBarHeight / density;

                Microsoft.Maui.Controls.Application.Current!.Dispatcher.Dispatch(() =>
                {
                    if (Microsoft.Maui.Controls.Application.Current.MainPage is MainPage mainPage)
                        mainPage.Padding = new Thickness(0, statusBarDp, 0, 0);
                });
            }
        }
    }
}