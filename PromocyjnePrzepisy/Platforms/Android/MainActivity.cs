using Android.App;
using Android.Content.PM;
using Android.OS;

namespace PromocyjnePrzepisy
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

        }
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        { System.Diagnostics.Debug.WriteLine(e.ToString()); }
    }
}
