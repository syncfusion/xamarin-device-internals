# Device Internals #

Device internals is a simple Xamarin.Forms application that accesses the device native behaviors such as Bluetooth, WiFi, accelerometer, and geolocation to visualize and monitor those values using Syncfusion Xamarin UI controls. This project uses the following patterns and features:

* XAML UI
* Custom controls
* Data binding
* MVVM

This project uses the following plugins:

* [Bluetooth LE plugin for Xamarin](https://github.com/xabre/xamarin-bluetooth-le) for accessing Bluetooth.
* [Xamarin.Essentials](https://github.com/xamarin/Essentials) for accessing device location and accelerometer.

And the following Syncfusion controls:

* [Charts](https://www.syncfusion.com/products/xamarin/charts)
* [Gauges](https://www.syncfusion.com/products/xamarin/circular-gauge)
* [Listview](https://www.syncfusion.com/products/xamarin/listview)
* [Maps](https://www.syncfusion.com/products/xamarin/maps)
* [Tabs](https://www.syncfusion.com/products/xamarin/tabs)


## Key features ##

* Get accelerometer values and visualize them using charts and gauges.
* Get nearby WiFi and Bluetooth devices and show them in list view.
* Get device's current location and plot it in maps.

## Supported platforms: ##

| Platforms | Supported versions |
| --------- | ------------------ |
| Android   | API level 19 and later versions |
| iOS | iOS 9.0 and later versions |

Please refer to the link for more information:

<https://help.syncfusion.com/xamarin/installation-and-upgrade/system-requirements>

## Requirements to run the demo ##

* [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/).
* Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

## How to run the sample ##
  
  
1. Clone the sample and open it in Visual Studio.

   *Note: If you download the sample using the "Download ZIP" option, right-click it, select Properties, and then select Unblock.*

2. Register your license key in App.cs as shown below.

        public App()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");

            InitializeComponent();

            MainPage = new MasterDetail();
        } 

   Refer this [link](https://help.syncfusion.com/common/essential-studio/licensing/license-key#xamarinforms) for more information.

3. Set any one of the platform specific projects (iOS, Android, UWP, macOS) as a startup project.
4. Clean and build the application.
5. Run the application.

## License ##

Syncfusion has no liability for any damage or consequence that may arise by the use or viewing of the samples. The samples are for demonstrative purposes and if you choose to use or access the samples you agree to not hold Syncfusion liable, in any form, for any damage that is related to use, accessing or otherwise viewing the samples. By accessing, viewing, or otherwise seeing the samples you acknowledge and agree Syncfusion’s samples will not allow you to seek injunctive relief in any form for any claim related to the sample. If you do not agree to this, do not view, access, utilize or otherwise do anything with Syncfusion’s samples.


## Support and Feedback ##

* For using the Syncfusion controls, refer the following User Guide links.

   * [Xamarin.Forms](https://help.syncfusion.com/xamarin/introduction/overview)
   * [Xamarin.Android](https://help.syncfusion.com/xamarin-android/introduction/overview)
   * [Xamarin.iOS](https://help.syncfusion.com/xamarin-ios/introduction/overview)

* For any other queries, reach our [Syncfusion support team](https://www.syncfusion.com/support/directtrac/incidents/newincident) or post the queries through the [community forums](https://www.syncfusion.com/forums).

* To renew the subscription, click [here](https://www.syncfusion.com/sales/products) or contact our sales team at <salessupport@syncfusion.com>.
