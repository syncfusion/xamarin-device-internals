using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DeviceInternals
{
    public class HomePageViewModel : INotifyPropertyChanged
    {
        #region Fields

        IBluetoothLE bluetoothBLE;
        IAdapter adapter;

        private ObservableCollection<IDevice> availableBluetoothSignals;
        private ObservableCollection<WifiModel> availableWifiNetworks;
        private ObservableCollection<ChartModel> accerelationValues;
        private DateTime currentTime;
        private double xAccelerationValue, yAccelerationValue, zAccelerationValue;
        private string latitude = string.Empty, longitude = string.Empty;
        #endregion

        #region Properties


        public double XAccelerationValue
        {

            get { return xAccelerationValue; }
            set
            {
                xAccelerationValue = value;
                OnPropertyChanged("XAccelerationValue");
            }
        }


        public double YAccelerationValue
        {

            get { return yAccelerationValue; }
            set
            {
                yAccelerationValue = value;
                OnPropertyChanged("YAccelerationValue");
            }
        }


        public double ZAccelerationValue
        {

            get { return zAccelerationValue; }
            set
            {
                zAccelerationValue = value;
                OnPropertyChanged("ZAccelerationValue");
            }
        }


        public ObservableCollection<IDevice> AvailableBluetoothSignals
        {
            get
            {
                return availableBluetoothSignals;
            }

            set
            {
                this.availableBluetoothSignals = value;
                OnPropertyChanged("AvailableBluetoothSignals");
            }
        }

        public ObservableCollection<ChartModel> AccerelationValues
        {
            get
            {
                return accerelationValues;
            }

            set
            {
                this.accerelationValues = value;
                OnPropertyChanged("AccerelationValues");
            }
        }

        public ObservableCollection<WifiModel> AvailableWifiNetworks
        {
            get
            {
                return availableWifiNetworks;
            }

            set
            {
                this.availableWifiNetworks = value;
                OnPropertyChanged("AvailableWifiNetworks");
            }
        }       

        public ICommand WifiNetworksCommand { get; set; }

        public ICommand BluetoothSignalsCommand { get; set; }

        public ICommand AccerelationStopCommand { get; set; }

        public ICommand AccerelationStartCommand { get; set; }

        #endregion

        #region Interface Member

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        #region Constructor

        public HomePageViewModel()
        {
            WifiNetworksCommand = new Command(GetAvailableWifiDevices);
            BluetoothSignalsCommand = new Command(GetAvailableBluetoothSignals);
            AccerelationStartCommand = new Command((object speed) =>
            {
                Accelerometer.Start(SensorSpeed.Ui);
            });
            AccerelationStopCommand = new Command(() =>
            {
                Accelerometer.Stop();
            });
            AccerelationValues = new ObservableCollection<ChartModel>();

            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;           
        }

        #endregion

        #region Methods
        private void Accelerometer_ReadingChanged(AccelerometerChangedEventArgs e)
        {
            var data = e.Reading;
            XAccelerationValue = data.Acceleration.X;
            YAccelerationValue = data.Acceleration.Y;
            ZAccelerationValue = data.Acceleration.Z;
            var diff = ((DateTime.Now - currentTime).TotalMilliseconds) / 1000.0;
            AccerelationValues.Add(new ChartModel
            {
                AccelerationTime = diff,
                XAccelerationValue = data.Acceleration.X,
                YAccelerationValue = data.Acceleration.Y,
                ZAccelerationValue = data.Acceleration.Z
            });

            if (diff > 40)
            {
                AccerelationValues.Clear();
                currentTime = DateTime.Now;
            }
        }

        private void GetAvailableWifiDevices()
        {
            AvailableWifiNetworks = new ObservableCollection<WifiModel>();

            if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.UWP)
            {
                AvailableWifiNetworks = DependencyService.Get<IWifiConnector>().GetWifiList();
            }
        }

        void GetAvailableBluetoothSignals()
        {
            AvailableBluetoothSignals = new ObservableCollection<IDevice>();
            bluetoothBLE = CrossBluetoothLE.Current;
            adapter = CrossBluetoothLE.Current.Adapter;
            SearchDevice();
        }

        private async void SearchDevice()
        {
            if (bluetoothBLE.State == BluetoothState.Off)
            {
                await Application.Current.MainPage.DisplayAlert(" Attention ", " Bluetooth disabled ", " OK ");
            }
            else
            {
                availableBluetoothSignals.Clear();

                adapter.ScanTimeout = 20000;
                adapter.ScanMode = ScanMode.Balanced;

                adapter.DeviceDiscovered += (obj, a) =>
                {
                    var data = a.Device;
                    if (!availableBluetoothSignals.Contains(data))
                        availableBluetoothSignals.Add(data);
                };

                await adapter.StartScanningForDevicesAsync();
            }
        }
       
        #endregion
    }
}
