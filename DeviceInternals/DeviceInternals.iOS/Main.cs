using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Foundation;
using DeviceInternals.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(WifiConnector))]
namespace DeviceInternals.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
	
}
