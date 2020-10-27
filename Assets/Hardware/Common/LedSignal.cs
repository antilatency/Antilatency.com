using Csml;
using System;
using System.Collections.Generic;


partial class Hardware : Scope {

    public class LedSignal {
        //public System.FormattableString name;
        public System.FormattableString description;
        public System.FormattableString indication;

        public LedSignal(FormattableString indication, FormattableString description) {
            //this.name = name;
            this.description = description;
            this.indication = indication;
        }

        public static List<System.FormattableString> convert(List<LedSignal> ledSignal) {
            var result = new List<FormattableString>();
            foreach (var signal in ledSignal) {
                //result.Add(signal.name);
                result.Add(signal.indication);
                result.Add(signal.description);
            }
            return result;
        }
    }

}