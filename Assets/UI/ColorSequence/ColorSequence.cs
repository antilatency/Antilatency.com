using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace Csml {
    public abstract class ColorSequence<T> : Element<T> where T : ColorSequence<T> {

        public abstract string GetGradient();
        public abstract float TotalDuration { get; }
        public override IEnumerable<HtmlNode> Generate(Context context) {
            yield return HtmlNode.CreateNode("<div>").Do(x => {
                x.AddClass("color-sequence");
                x.SetAttributeValue("style", $"background:linear-gradient(to right, {GetGradient()}); animation: animatedBackgroundPositionHorizontal {TotalDuration}s linear infinite;");
            });
        }
    }

    public class ColorSequence : ColorSequence<ColorSequence> {
        private struct ColorDuration {
            public string color;
            public float duration;
        }
        List<ColorDuration> Elements = new List<ColorDuration>();
        public override float TotalDuration => Elements.Sum(x => x.duration);

        public ColorSequence() { }
        public ColorSequence this[string color, float duration] {
            get {
                if (duration <= 0) {
                    Log.Error.OnCaller("Invalid duration");
                }
                Elements.Add(new ColorDuration(){ color = color,duration = duration });
                return this;
            }
        }
        public ColorSequence this[Color color, float duration] {
            get {                
                return this["#" + color.ToRgba().ToString("x8"), duration];
            }
        }
        

        public override string GetGradient() {
            StringBuilder stringBuilder = new StringBuilder();
            var totalDuration = TotalDuration;
            float currentPosition = 0;
            foreach (var e in Elements) {
                if (currentPosition > 0) stringBuilder.Append(',');
                stringBuilder.Append($"{e.color} {100 * currentPosition / totalDuration}%,");
                currentPosition += e.duration;
                stringBuilder.Append($"{e.color} {100 * (currentPosition) / totalDuration }%");                
            }
            return stringBuilder.ToString();
        }
    }

    public class ColorSequenceCos : ColorSequence<ColorSequenceCos>{
        float UserGefinedDuration;
        public override float TotalDuration => UserGefinedDuration;
        Color Min;
        Color Max;
        public ColorSequenceCos(Color min, Color max, float duration) {
            UserGefinedDuration = duration;
            Min = min;
            Max = max;
        }

        public override string GetGradient() {
            StringBuilder stringBuilder = new StringBuilder();
            int numSteps = 20;
            for (int i = 0; i <= numSteps; i++) {
                float p = i / (float)numSteps;
                float a = 2 * MathF.PI * p;
                var y = 0.5f * MathF.Cos(a) + 0.5f;
                var color = Min.Lerp(Max, y);
                if (i > 0) stringBuilder.Append(',');
                stringBuilder.Append($"#{color.ToRgb().ToString("x6")} {100 * p}%");
            }

            
            return stringBuilder.ToString();
        }
    }
}

