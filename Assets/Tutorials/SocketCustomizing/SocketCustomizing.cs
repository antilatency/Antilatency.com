using Csml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


partial class Tutorials: Scope {
    public static LanguageSelector<IMaterial> SocketCustomizing => new LanguageSelector<IMaterial>();
    public partial class SocketCustomizing_Assets : Scope {
        public static Image AltMount1 => new Image("Images/AltMount1.jpg");
        public static Image AltMount2 => new Image("Images/AltMount2.jpg");
        public static Downloadable CustomMaterials = new Downloadable("Materials", "CustomMaterials", Downloadable.PathFragment.CanSelectAll);
        public static Downloadable Holder3D = new Downloadable ("Holder 3D-model", "Holder 3D-model");
        public static Image MagnetMount0 = new Image("./Images/MagnetMount/MagnetMount0.jpg");
        public static Image MagnetMount1 = new Image("./Images/MagnetMount/MagnetMount1.jpg");
        public static Image MagnetMount2 = new Image("./Images/MagnetMount/MagnetMount2.jpg");
        public static Image MagnetMount3 = new Image("./Images/MagnetMount/MagnetMount3.jpg");
        public static Image MagnetMount4 = new Image("./Images/MagnetMount/MagnetMount4.jpg");
        public static Image MagnetMount5 = new Image("./Images/MagnetMount/MagnetMount5.jpg");
        public static Image MagnetMount6 = new Image("./Images/MagnetMount/MagnetMount6.jpg");

        public static Image HolderMount0 = new Image("./Images/HolderMount/HolderMount0.jpg");
        public static Image HolderMount1 = new Image("./Images/HolderMount/HolderMount1.jpg");
        public static Image HolderMount2 = new Image("./Images/HolderMount/HolderMount2.jpg");
        public static Image HolderMount3 = new Image("./Images/HolderMount/HolderMount3.jpg");
        public static Image HolderMount4 = new Image("./Images/HolderMount/HolderMount4.jpg");
        public static Image HolderMount5 = new Image("./Images/HolderMount/HolderMount5.jpg");
        public static Image HolderMount6 = new Image("./Images/HolderMount/HolderMount6.jpg");
        public static Image HolderMount7 = new Image("./Images/HolderMount/HolderMount7.jpg");
        public static Image HolderMount8 = new Image("./Images/HolderMount/HolderMount8.jpg");
    
    }
}
