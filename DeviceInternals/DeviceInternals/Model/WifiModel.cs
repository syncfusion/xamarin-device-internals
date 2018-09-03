using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace DeviceInternals
{
	public class WifiModel : INotifyPropertyChanged
	{
		#region Fields

		private string wifiNetworkName;
		private ImageSource networkImage;
		private string networkAddress;

		#endregion

		#region Constructor

		public WifiModel()
		{

		}

		#endregion

		#region Properties

		public ImageSource NetworkImage
		{
			get { return networkImage; }
			set
			{
				networkImage = value;
				OnPropertyChanged("NetworkImage");
			}
		}

		public string WifiNetworkName
		{
			get { return wifiNetworkName; }
			set
			{
				wifiNetworkName = value;
				OnPropertyChanged("WifiNetworkName");
			}
		}

		public string NetworkAddress
		{
			get { return networkAddress; }
			set
			{
				networkAddress = value;
				OnPropertyChanged("NetworkAddress");
			}
		}

		#endregion

		#region Interface Member

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged(string name)
		{
			if (this.PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(name));
		}

		#endregion
	}
}
