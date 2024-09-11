using Android.App;
using Android.Content.PM;
using Android.OS;

namespace TellarknightApp
{
    [Activity(
        Theme = "@style/Maui.SplashTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density,
        ScreenOrientation = ScreenOrientation.SensorLandscape)] // Use SensorLandscape for both horizontal orientations
    public class MainActivity : MauiAppCompatActivity
    {
    }
}
