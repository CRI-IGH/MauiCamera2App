using Android.Hardware.Camera2;
using Android.Views;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using System.Collections.Generic;
using System;
using Android.App;
using Android.Graphics;
using View = Android.Views.View;
using Android.OS;

namespace MauiCamera2App
{
    public class Camera2Fragment : Fragment
    {
        CameraDevice cameraDevice;
        CaptureRequest.Builder previewBuilder;
        CameraCaptureSession captureSession;
        SurfaceView surfaceView;
        SurfaceTexture surfaceTexture;
        Size previewSize;

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            surfaceView = new SurfaceView(Context);
            StartPreview();
        }

        void StartPreview()
        {
            if (cameraDevice == null || surfaceTexture == null || previewSize == null) return;

            try
            {
                surfaceTexture.SetDefaultBufferSize((int)previewSize.Width, (int)previewSize.Height);
                Surface surface = new Surface(surfaceTexture);

                previewBuilder = cameraDevice.CreateCaptureRequest(CameraTemplate.Preview);
                previewBuilder.AddTarget(surface);

                cameraDevice.CreateCaptureSession(new List<Surface> { surface },
                    new CameraCaptureStateListener
                    {
                        OnConfigureFailedAction = session => { },
                        OnConfiguredAction = session =>
                        {
                            if (cameraDevice == null) return;

                            captureSession = session;
                            UpdatePreview();
                        }
                    }, null);
            }
            catch (CameraAccessException ex)
            {
                Console.WriteLine("Failed to start camera preview: " + ex);
            }
        }

        void UpdatePreview()
        {
            if (cameraDevice == null) return;

            captureSession.SetRepeatingRequest(previewBuilder.Build(), null, null);
        }
    }
}
