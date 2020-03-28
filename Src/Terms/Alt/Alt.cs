using Csml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Csml.Utils.Static;



partial class Root {


    MultiLanguageGroup Alt => new MultiLanguageGroup();


    public Material Alt_ru => new Material(Alt.Title, null, $"");


    /*public partial class Alt : Name<Alt> {

        public static Image AltAndUsbSocket0 =>
            Backup(() => new Image("./AltAndUsbSocket0.jpg"));
        public static Image AltAndUsbSocket1 =>
            Backup(() => new Image("./AltAndUsbSocket1.jpg"));

        

        public static List<Image> AllImages => Backup(() =>
            Directory.GetFiles(ThisDirectory(), "*.jpg").Select(x => new Image(x)).ToList());

        public static List<Image> AllDeclaredImages => Backup(() => typeof(Alt).GetPropertiesPublicStatic()
        .Where(x => x.PropertyType == typeof(Image)).Select(x => x.GetValue(null) as Image).ToList());


        public static Material ru = new Material(Title, AltAndUsbSocket1,
@$"{Reference} - это трекер который работает с {Antilatency_Device_Network.Reference}.
The first is an averaged received signal strength indicator. The 'averageRssi' metric can detect ineffective positions. The smaller the RSSI, the weaker the signal, and the more susceptible it is to interference.

The second shows radio packets loss rate.The 'packetLossRate'  indicator displays the ratio of lost radio packets.It is expressed as a number from 0 to 1.For example, a coefficient of 0.1 will mean that a tenth of the packets were lost.

The 'ExtendedMetrics' option includes a larger number of indicators: the number of sent and received radio packets, the amount of sent and received data, additional RSSI values, and more.
"        
            )
            
            [AllDeclaredImages]
            [AllDeclaredImages]
            ;
    }*/
}