using Csml;
using HtmlAgilityPack;
using System.Collections.Generic;


partial class Root {
    static AntilatencyLogo Logo40Black => new AntilatencyLogo("40px", "black");

}


class AntilatencyLogo : Element<AntilatencyLogo> {
    public static System.UInt32 PrimatyColor => 0xacc435;
    private string Size;
    private string Color;
    public AntilatencyLogo(string cssSize, string cssColor) {
        Size = cssSize;
        Color = cssColor;
    }
    public override IEnumerable<HtmlNode> Generate(Context context) {
        yield return Root.Index.Generate(context).Single().Do((x) => {
            x.AddClass("noselect");
            x.InnerHtml = "";
            x.SetAttributeValue("style", $"font-family: 'antilatency' !important; font-size: {Size}; color: {Color};");
            x.Add($"<span>").Do(x => {
                x.SetAttributeValue("style", $"color: #{PrimatyColor.ToString("X6")}");
                x.Add("a");

            });
            x.Add($"<span>").Do(x => {
                x.Add("l");
            });
        });
    }
}