using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace DeviceInternals.iOS
{
    public class WifiConnector : IWifiConnector
    {

        public ObservableCollection<WifiModel> GetWifiList()
        {
            var list = new ObservableCollection<WifiModel>();

            return null;
        }
    }
}