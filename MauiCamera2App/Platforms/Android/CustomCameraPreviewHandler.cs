using Android.Content;
using Microsoft.Maui.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiCamera2App.Platforms.Android
{
    public class CustomCameraPreviewHandler : ViewHandler<CustomCameraPreview, Camera2Preview>
    {
        public CustomCameraPreviewHandler(IPropertyMapper mapper, CommandMapper? commandMapper = null) : base(mapper, commandMapper)
        {
        }
        public CustomCameraPreviewHandler() : base(PropertyMapper)
        {
        }

        public static PropertyMapper<CameraPreview, CameraPreviewHandler> PropertyMapper = new PropertyMapper<CameraPreview, CameraPreviewHandler>(ViewHandler.ViewMapper)
        {
            // Fügen Sie hier Mapping-Code hinzu, falls benötigt
        };

        protected override Camera2Preview CreatePlatformView()
        {
            return new Camera2Preview(Context);
        }
    }
}
