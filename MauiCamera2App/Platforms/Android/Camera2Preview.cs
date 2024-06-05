using Android.Content;
using Android.Graphics;
using Android.Hardware.Camera2;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;
using System;


namespace MauiCamera2App.Platforms.Android
{
    public class Camera2Preview : FrameLayout, ISurfaceHolderCallback
    {
        private SurfaceView _surfaceView;
        private ISurfaceHolder _surfaceHolder;
        private CameraDevice _cameraDevice;
        private CaptureRequest.Builder _previewBuilder;
        private CameraCaptureSession _previewSession;
        private string _cameraId;
        private Context _context;

        public Camera2Preview(Context context) : base(context)
        {
            _context = context;
            Initialize();
        }

        private void Initialize()
        {
            _surfaceView = new SurfaceView(_context);
            AddView(_surfaceView);

            _surfaceHolder = _surfaceView.Holder;
            _surfaceHolder.AddCallback(this);
        }

        public void SurfaceChanged(ISurfaceHolder holder, Format format, int width, int height)
        {
        }

        public void SurfaceCreated(ISurfaceHolder holder)
        {
            StartCamera();
        }

        public void SurfaceDestroyed(ISurfaceHolder holder)
        {
            StopCamera();
        }

        private void StartCamera()
        {
            CameraManager manager = (CameraManager)_context.GetSystemService(Context.CameraService);
            try
            {
                _cameraId = manager.GetCameraIdList()[0];
                manager.OpenCamera(_cameraId, new CameraStateCallback(this), null);
            }
            catch (CameraAccessException e)
            {
                Log.Error("Camera2Preview", e.ToString());
            }
        }

        private void StopCamera()
        {
            _cameraDevice.Close();
            _cameraDevice = null;
        }

        private class CameraStateCallback : CameraDevice.StateCallback
        {
            private readonly Camera2Preview _camera2Preview;

            public CameraStateCallback(Camera2Preview camera2Preview)
            {
                _camera2Preview = camera2Preview;
            }

            public override void OnOpened(CameraDevice camera)
            {
                _camera2Preview._cameraDevice = camera;
                _camera2Preview.CreateCameraPreviewSession();
            }

            public override void OnDisconnected(CameraDevice camera)
            {
                camera.Close();
                _camera2Preview._cameraDevice = null;
            }

            public override void OnError(CameraDevice camera, CameraError error)
            {
                camera.Close();
                _camera2Preview._cameraDevice = null;
            }
        }

        private void CreateCameraPreviewSession()
        {
            try
            {
                Surface surface = _surfaceHolder.Surface;
                _previewBuilder = _cameraDevice.CreateCaptureRequest(CameraTemplate.Preview);
                _previewBuilder.AddTarget(surface);

                _cameraDevice.CreateCaptureSession(new List<Surface> { surface },
                    new CameraCaptureSessionCallback(this), null);
            }
            catch (CameraAccessException e)
            {
                Log.Error("Camera2Preview", e.ToString());
            }
        }



        private class CameraCaptureSessionCallback : CameraCaptureSession.StateCallback
        {
            private readonly Camera2Preview _camera2Preview;

            public CameraCaptureSessionCallback(Camera2Preview camera2Preview)
            {
                _camera2Preview = camera2Preview;
            }

            public override void OnConfigureFailed(CameraCaptureSession session)
            {
                Log.Error("Camera2Preview", "Failed to configure camera.");
            }

            public override void OnConfigured(CameraCaptureSession session)
            {
                if (_camera2Preview._cameraDevice == null)
                    return;

                _camera2Preview._previewSession = session;
                _camera2Preview._previewBuilder.Set(CaptureRequest.ControlMode, new Integer((int)ControlMode.Auto));

                try
                {
                    _camera2Preview._previewSession.SetRepeatingRequest(_camera2Preview._previewBuilder.Build(), null, null);
                }
                catch (CameraAccessException e)
                {
                    Log.Error("Camera2Preview", e.ToString());
                }
            }
        }
    }
}