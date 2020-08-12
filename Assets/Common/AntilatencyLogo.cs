using Csml;
using Htmlilka;
using System.Collections.Generic;
using System.Drawing;

partial class Root {
    public static Color AntilatencyColor => Color.FromArgb( 0xacc435);
    public static AntilatencyLogo LogoGreenBlack => new AntilatencyLogo(AntilatencyColor,Color.Black);
    public static AntilatencyLogo LogoGreenWhite => new AntilatencyLogo(AntilatencyColor, Color.White);
    public static AntilatencyLogo LogoWhiteBlack => new AntilatencyLogo(Color.White, Color.Black);
}


public class AntilatencyLogo : Element<AntilatencyLogo> {
    readonly Color PrimaryColor;
    readonly Color SecondaryColor;
    public AntilatencyLogo(Color primaryColor, Color secondaryColor) {
        PrimaryColor = primaryColor;
        SecondaryColor = secondaryColor;
    }
    public override Node Generate(Context context) {
        var result = Root.Index.Generate(context) as Tag;
        result.Children = new List<Node>();
        result
            .AddClasses("AntilatencyLogo")
            .Attribute("style", $"font-family: 'antilatency' !important;")
            .AddTag("span", x => {
                x
                .Attribute("style", $"color: #{PrimaryColor.ToRgbString()}")
                .AddText("a");
            })
            .AddTag("span", x => {
                x
                .Attribute("style", $"color: #{SecondaryColor.ToRgbString()}")
                .AddText("l");
            });
        return result;
        /*yield return Root.Index.Generate(context).Single().Do((x) => {
            x.AddClass("AntilatencyLogo");
            x.InnerHtml = "";
            x.SetAttributeValue("style", $"font-family: 'antilatency' !important;");
            x.Add($"<span>").Do(x => {
                x.SetAttributeValue("style", $"color: #{PrimaryColor.ToRgbString()}");
                x.Add("a");

            });
            x.Add($"<span>").Do(x => {
                x.SetAttributeValue("style", $"color: #{SecondaryColor.ToRgbString()}");
                x.Add("l");
            });
        });*/
    }
}