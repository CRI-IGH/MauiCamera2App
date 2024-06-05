using MauiCamera2App.Platforms.Android;

namespace MauiCamera2App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await RequestPermissionsAsync();
        }

        private async Task RequestPermissionsAsync()
        {
            var cameraStatus = await Permissions.CheckStatusAsync<Permissions.Camera>();
            if (cameraStatus != PermissionStatus.Granted)
            {
                cameraStatus = await Permissions.RequestAsync<Permissions.Camera>();
            }

            if (cameraStatus != PermissionStatus.Granted)
            {
                await DisplayAlert("Permission Denied", "Unable to access the camera.", "OK");
                return;
            }

            var audioStatus = await Permissions.CheckStatusAsync<Permissions.Microphone>();
            if (audioStatus != PermissionStatus.Granted)
            {
                audioStatus = await Permissions.RequestAsync<Permissions.Microphone>();
            }

            if (audioStatus != PermissionStatus.Granted)
            {
                await DisplayAlert("Permission Denied", "Unable to access the microphone.", "OK");
                return;
            }

            var storageStatus = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();
            if (storageStatus != PermissionStatus.Granted)
            {
                storageStatus = await Permissions.RequestAsync<Permissions.StorageWrite>();
            }

            if (storageStatus != PermissionStatus.Granted)
            {
                await DisplayAlert("Permission Denied", "Unable to access storage.", "OK");
                return;
            }

            StartCamera();
        }

        private void StartCamera()
        {
            var cameraPreview = new CustomCameraPreview();
            cameraView.Content = cameraPreview;
        }
    }
}