using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DeviceInternals
{
    public partial class HomePage : ContentPage
    {
        #region Fields
        SensorSpeed speed;
        #endregion

        #region Constructor
        public HomePage()
        {
            InitializeComponent();

            speed = SensorSpeed.Ui;
            startAccerelation.CommandParameter = startAccerelation2.CommandParameter = speed;
            AddMarker();
        }
        #endregion

        #region Methods
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width > 0 || height > 0)
            {
                if (width < height)
                {
                    gaugeGrid.ColumnDefinitions.Clear();
                    gaugeGrid.RowDefinitions = new RowDefinitionCollection() { new RowDefinition(), new RowDefinition(), new RowDefinition() };

                    for (int i = 0; i < gaugeGrid.Children.Count; i++)
                    {
                        Grid.SetRow(gaugeGrid.Children[i], i);
                        Grid.SetColumn(gaugeGrid.Children[i], 0);
                    }
                }
                else
                {
                    gaugeGrid.RowDefinitions.Clear();
                    gaugeGrid.ColumnDefinitions = new ColumnDefinitionCollection() { new ColumnDefinition(), new ColumnDefinition(), new ColumnDefinition() };

                    for (int i = 0; i < gaugeGrid.Children.Count; i++)
                    {
                        Grid.SetRow(gaugeGrid.Children[i], 0);
                        Grid.SetColumn(gaugeGrid.Children[i], i);
                    }
                }
            }
        }

        private async void AddMarker()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location != null)
                {
                    MapContactLocationLayer.Markers[0].Latitude = location.Latitude.ToString();
                    MapContactLocationLayer.Markers[0].Longitude = location.Longitude.ToString();
                }
            }
            catch (Exception ex)
            {
                // Handle not supported on device exception
                await Application.Current.MainPage.DisplayAlert("Alert", ex.Message, "Ok");
            }
        }
        #endregion
    }
}