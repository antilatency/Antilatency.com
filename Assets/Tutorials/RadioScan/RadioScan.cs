using Csml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


partial class Tutorials: Scope {
    public static LanguageSelector<IMaterial> RadioScan => new LanguageSelector<IMaterial>();
    public partial class RadioScan_Assets : Scope {

        public static Downloadable Exe => new Downloadable("RadioScanner", "Files");

        public static Image Output1 => new Image("Images/Output1.png");
        public static Image Output2 => new Image("Images/Output2.png");

        public static Image Process => new Image("Images/Process.gif");

        public static Image ResultFile => new Image("Images/ResultFile.png");
        public static Image Result => new Image("Images/Result.png");

        public static ExternalReference MsLibsRef => new ExternalReference("https://support.microsoft.com/en-us/help/2977003/the-latest-supported-visual-c-downloads", "Microsoft Visual C++ Redistributable for Visual Studio 2015, 2017 and 2019");

        public static ExternalReference RadioInterferenceRef => new ExternalReference("https://en.wikipedia.org/wiki/2.4_GHz_radio_use#Wi-Fi", "2.4 GHz radio use");

        public static ExternalReference WiFiChannelsRef => new ExternalReference("https://https://en.wikipedia.org/wiki/List_of_WLAN_channels", "2.4 GHz (802.11b/g/n/ax) channels");


        public static ExternalReference WiFiAnalyzerRef => new ExternalReference("https://play.google.com/store/apps/details?id=abdelrahman.wifianalyzerpro&hl=en", "WiFi Analyzer");

        public static ExternalReference GoogleDocsRef => new ExternalReference("https://docs.google.com", "Google docs");



    }
}