using Android.Hardware.Camera2;

namespace MauiCamera2App
{
    public class CameraCaptureStateListener : CameraCaptureSession.StateCallback
    {
        public Action<CameraCaptureSession> OnConfigureFailedAction { get; set; }
        public Action<CameraCaptureSession> OnConfiguredAction { get; set; }

        public override void OnConfigureFailed(CameraCaptureSession session)
        {
            OnConfigureFailedAction?.Invoke(session);
        }

        public override void OnConfigured(CameraCaptureSession session)
        {
            OnConfiguredAction?.Invoke(session);
        }
    }
}
