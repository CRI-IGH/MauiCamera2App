using Android.Content;
using Android.Views;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Android.Widget; // Hinzugefügt für SurfaceView
using AndroidX.Fragment.App; // Hinzugefügt für Fragment

namespace MauiCamera2App.Platforms.Android
{
    public class CameraPreviewHandler : ViewHandler<CameraPreview, FrameLayout>
    {
        public CameraPreviewHandler() : base(PropertyMapper)
        {
        }

        public static PropertyMapper<CameraPreview, CameraPreviewHandler> PropertyMapper = new PropertyMapper<CameraPreview, CameraPreviewHandler>(ViewHandler.ViewMapper)
        {
            // Fügen Sie hier Mapping-Code hinzu, falls benötigt
        };

        protected override FrameLayout CreatePlatformView()
        {
            var context = MauiApplication.Current.ApplicationContext;
            var frameLayout = new FrameLayout(context);

            var fragmentManager = (context as Android.App.Activity).FragmentManager;
            var camera2Fragment = new Camera2Fragment();
            var transaction = fragmentManager.BeginTransaction();
            transaction.Replace(frameLayout.Id, camera2Fragment);
            transaction.Commit();

            return frameLayout;
        }

        protected override void ConnectHandler(FrameLayout platformView)
        {
            base.ConnectHandler(platformView);
            // Fügen Sie hier zusätzlichen Code hinzu, um die plattformspezifische Ansicht zu verbinden
        }

        protected override void DisconnectHandler(FrameLayout platformView)
        {
            base.DisconnectHandler(platformView);
            // Fügen Sie hier zusätzlichen Code hinzu, um die plattformspezifische Ansicht zu trennen
        }
    }
}
