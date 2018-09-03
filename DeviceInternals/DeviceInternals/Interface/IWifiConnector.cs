using System.Collections.ObjectModel;

namespace DeviceInternals
{
    public interface IWifiConnector
    {
        ObservableCollection<WifiModel> GetWifiList();
    }
}