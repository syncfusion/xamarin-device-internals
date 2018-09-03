using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Xamarin.Forms;
using DeviceInternals.Droid;
using Android.Net.Wifi;
using Android.Content;
using System.Reflection;
using Android.Bluetooth;
using Android.Bluetooth.LE;
using System.Linq;
using Java.Util;
using System.Threading;
using System.Threading.Tasks;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE;

[assembly: Dependency(typeof(WifiConnector))]

namespace DeviceInternals.Droid
{
    [Activity(Label = "DeviceInternals", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

        }
    }    
}