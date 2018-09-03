using System.Collections.ObjectModel;
using System.Reflection;
using Android.Content;
using Android.Net.Wifi;
using Xamarin.Forms;

namespace DeviceInternals.Droid
{
    public class WifiConnector : IWifiConnector
    {

        public ObservableCollection<WifiModel> GetWifiList()
        {
            var list = new ObservableCollection<WifiModel>();
			Assembly assembly = typeof(HomePage).GetTypeInfo().Assembly;
            var wifiManager = (WifiManager)Android.App.Application.Context
                        .GetSystemService(Context.WifiService);

            int numberOfLevels = 5;
            var wifiInfo = wifiManager.ConnectionInfo;

            foreach (var scanResult in wifiManager.ScanResults)
            {
                int signalLevel = WifiManager.CalculateSignalLevel(scanResult.Level, numberOfLevels);
                var name = scanResult.Ssid;
                var ipAddress = scanResult.Bssid;

                switch (signalLevel)
                {
                    case 0:
                        list.Add(new WifiModel() { WifiNetworkName = name, NetworkAddress = ipAddress, NetworkImage = ImageSource.FromResource("DeviceInternals.Images.Network0.png", assembly) });
                        break;
                    case 1:
                        list.Add(new WifiModel() { WifiNetworkName = name, NetworkAddress = ipAddress, NetworkImage = ImageSource.FromResource("DeviceInternals.Images.Network1.png", assembly) });
                        break;
                    case 2:
                        list.Add(new WifiModel() { WifiNetworkName = name, NetworkAddress = ipAddress, NetworkImage = ImageSource.FromResource("DeviceInternals.Images.Network2.png", assembly) });
                        break;
                    case 3:
                        list.Add(new WifiModel() { WifiNetworkName = name, NetworkAddress = ipAddress, NetworkImage = ImageSource.FromResource("DeviceInternals.Images.Network3.png", assembly) });
                        break;
                    default:
                        list.Add(new WifiModel() { WifiNetworkName = name, NetworkAddress = ipAddress, NetworkImage = ImageSource.FromResource("DeviceInternals.Images.Network4.png", assembly) });
                        break;
                }
            }

            return list;
        }

    }
}