using Csml;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Drawing;

partial class Root {
    public static Color AntilatencyColor => Color.FromArgb( 0xacc435);
    public static AntilatencyLogo LogoGreenBlack => new AntilatencyLogo(AntilatencyColor,Color.Black);
    public static AntilatencyLogo LogoGreenWhite => new AntilatencyLogo(AntilatencyColor, Color.White);
    public static AntilatencyLogo LogoWhiteBlack => new AntilatencyLogo(Color.White, Color.Black);
}


public class AntilatencyLogo : Element<AntilatencyLogo> {
    Color PrimaryColor;
    Color SecondaryColor;
    private string Color;
    public AntilatencyLogo(Color primaryColor, Color secondaryColor) {
        PrimaryColor = primaryColor;
        SecondaryColor = secondaryColor;
    }
    public override IEnumerable<HtmlNode> Generate(Context context) {
        yield return Root.Index.Generate(context).Single().Do((x) => {
            x.AddClass("AntilatencyLogo");
            x.InnerHtml = "";
            x.SetAttributeValue("style", $"font-family: 'antilatency' !important; color: {Color};");
            x.Add($"<span>").Do(x => {
                x.SetAttributeValue("style", $"color: #{PrimaryColor.ToRgbString()}");
                x.Add("a");

            });
            x.Add($"<span>").Do(x => {
                x.SetAttributeValue("style", $"color: #{SecondaryColor.ToRgbString()}");
                x.Add("l");
            });
        });
    }
}