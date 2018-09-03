using Syncfusion.SfMaps.XForms;
using System.Reflection;
using Xamarin.Forms;

namespace DeviceInternals
{
    public class CustomMarker : MapMarker
    {
        public ImageSource ImageName { get; set; }

        public CustomMarker()
        {
            if (Device.RuntimePlatform == Device.UWP)
                ImageName = ImageSource.FromResource("DeviceInternals.Images.marker.png", typeof(CustomMarker).GetTypeInfo().Assembly);
            else
                ImageName = ImageSource.FromResource("DeviceInternals.Images.marker.png");
        }
    }
}