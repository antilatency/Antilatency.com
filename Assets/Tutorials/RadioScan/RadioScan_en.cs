using Csml;
using System.Net.Sockets;
using static Tutorials.RadioScan_Assets;

partial class Tutorials : Scope {

    public static Material RadioScan_en =>

        new Material(
            "RadioScan",
            null,
        $"A utility to assess radio congestion on the 2.4GHz frequency band")
        
        [$"A lot of devices using the 2.4-2.5GHz band create network interference. {Terms.Antilatency_Radio_Protocol}. {RadioInterferenceRef}. The main source of radio noise is 2.4GHz wireless internet due to its widespread use and relatively high signal strength."]

        [$"You can use applications that will detect wireless networks in the vicinity, for example the {WiFiAnalyzerRef}. You can then match channel numbers with the real frequencies using this table {WiFiChannelsRef} It is better not to use all the channels from this band for devices supporting the {Terms.Antilatency_Radio_Protocol}. However, this approach may result in almost all the channels being busy. It is important to understand that the mere availability of an access point says nothing about the actual levels of radio noise on this channel. The more data is exchanged between wireless devices, the higher radio noise levels will be."]

        [$"The RadioScanner utility will help you build a picture of real-time noise levels on all radio channels. To keep this picture up-to-date you need to run the utility as many times as possible in different locations and at different times. Your channel scans will generate text files with relevant statistics."]

        [new Info()[$"The test will involve two devices. You should place them 1-2 meters apart. Make sure that there are no interfering objects between them, especially those that can carry static electricity (this includes people standing nearby). If possible, exclude all the outside factors that influence device operation because it creates variable conditions for the test depending on the channel."]]
        
        [$"The purpose of the test is to keep changing channels and save the number of errors in radio packet transmission. One scan will take approximately 12 minutes."]

        [new Info()[$"Download and install {MsLibsRef} for the utilities to run correctly."]]
        [new Section("Test launch")
            [new Info($"Make sure that your wireless devices are fully charged.")]
            [new OrderedList()
                [$"Download and unpack {Exe}"]
                [$"Turn off everything."]
                [$"Turn on 1 {Hardware.SocketUsbRadio} and 1 {Hardware.Bracer} or {Hardware.Tag}."]
                [$"For {Hardware.SocketUsbRadio} set `ConnLimit` = `1`"]
                [$"Make sure that the two devices have established a radio connection."]
                [$"Open the console and access the folder with `RadioScanner.exe`"]
                [$"Create a folder to store scan results, for example `Scan`"]
                [@$"Execute: `.\RadioScanner.exe -o Scan/PositionA1.txt` where `Scan` is the name of the folder storing scan results and `PositionA1.txt` is the name of the file with the test results. Your top tip is to include the test location and number in the name of the file)."]
                [@$"Run one or two more scans `.\RadioScanner.exe -o Scan/PositionA2.txt`"]
                [$"Change the test location and repeat steps 8 and 9 (for example, you can name the files `PositionB1.txt` and `PositionB2.txt`)"]]]

        [$@"If the utility stops running prematurely, you need to restore socket properties manually(`RadioChannel`, `MasterSN`, `ChannelsMask`)"]

        [$@"After launch the console will display the following:"]
        [Output1]

        [$@"Similar content will also be written in the file with test results.
Group and analyze all your test results. To generate a summary table, run:
`.\RadioScanner.exe report -i Scan -o scan.txt`
The output will look as follows:"]
        [Output2]

        [$@"You will also get a file named `scan.txt` with approximately this content:"]
        [ResultFile]

        [$@"After that you can do your analysis. A convenient way to carry it out is using {GoogleDocsRef} or similar spreadsheet software."]
        [new OrderedList()
            [$"Copy the entire content of your `scan.txt` file and insert it into the page. "]
            [$"Enter channel numbers from `0` to `140` and make the column narrow for better viewing."]
            [$"Optionally, you can add conditional format for more visual clarity"]]
        [Process]

        [$@"The number in the cell shows how many packets were lost (out of roughly 10,000 packets). Empty cells are channels with missing stats, possibly due to an unstable connection (there were too many losses at the time when the connection was established)."]
        [Result]

        [new Section("Analysis")
            [new UnorderedList()
            [$"As a rule, channels`122-140`(and `0-40`) will be almost loss-free because wireless networks do not use them. However, before using them you should check whether it is legal in your country. "]
            [$"Channels `89-106` appear to be unstable with a lot of losses."]
            [$"Channels `108-121` are your best picks for connection."]]
            [$"Unfortunately, a channel that has minimal losses during the test may deteriorate later on. For example, it may happen because the devices that usually occupy it were off but have come back online. To minimize this risk, you ought to include more data in your analysis. The more scans you run (preferably at different times), the better picture of your radio environment you will get."]]

            ;
}