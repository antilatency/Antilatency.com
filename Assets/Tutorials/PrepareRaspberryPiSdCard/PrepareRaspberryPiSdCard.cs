using Csml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public partial class Tutorials : Scope {
    public static LanguageSelector<IMaterial> PrepareRaspberryPiSdCard => new LanguageSelector<IMaterial>();

    public partial class PrepareRaspberryPiSdCard_Assets : Scope {       
        public static Code WpaSupplicantConf => new Code(
            @"echo -e 'ctrl_interface=DIR=/var/run/wpa_supplicant GROUP=netdev
update_config=1
country=GB

network={
    ssid=""Antilatency_5G""
    psk = ""standardpassword""
}

network={
    ssid=""Antilatency""
    psk=""standardpassword""
}' | sudo tee /etc/wpa_suplicant.conf"
            , ProgrammingLanguage.Cpp);
        public static Code RpiOsOkGpioPinRcLocal => new Code(
            @"/usr/bin/gpio mode 2 output
/usr/bin/gpio write 2 1"
            , ProgrammingLanguage.Cpp);
        public static Code AptUpdate => new Code(
            $"sudo apt update && sudo apt upgrade"
            , ProgrammingLanguage.PowerShell);
        public static Code GpioShutdown => new Code(
            $"echo 'dtoverlay=gpio-shutdown,gpio_pin=2' | sudo tee -a /boot/config.txt"
            , ProgrammingLanguage.PowerShell);
        public static Code RcLocal => new Code(
            $"sudo nano /etc/rc.local"
            , ProgrammingLanguage.PowerShell);
        public static Code RpiOffOkGpioPinSystemD => new Code(
            @"echo -e '#!/bin/sh
gpio mode 3 output
gpio write 2 1
sleep 1
exit 0' | sudo tee /lib/systemd/system-shutdown/rpi_off_ok.sh > /dev/null"
            , ProgrammingLanguage.PowerShell);
        public static Code CreateOptAntilatencyDir => new Code(
            $"sudo mkdir -p /opt/antilatency/bin /opt/antilatency/lib /opt/antilatency/etc && sudo chown -R pi:pi /opt/antilatency"
            , ProgrammingLanguage.PowerShell);
        public static Code AntilatencyUdevRules => new Code($"echo 'SUBSYSTEM==\"usb\", ATTRS{{idVendor}}==\"3237\", MODE=\"0666\", GROUP=\"pi\"' | sudo tee /etc/udev/rules.d/66-antilatency.rules", ProgrammingLanguage.PowerShell);
    }
}