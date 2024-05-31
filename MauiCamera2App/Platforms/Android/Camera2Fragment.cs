using Android.OS;
using Android.Views;
using Android.Widget; // Hinzugefügt für SurfaceView
using AndroidX.Fragment.App;
using View = Android.Views.View; // Hinzugefügt für Fragment

namespace MauiCamera2App.Platforms.Android
{
    public class Camera2Fragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Erstellen und initialisieren Sie Ihre Ansicht hier
            return new SurfaceView(Activity);
        }
    }
}