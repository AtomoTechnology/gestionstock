using ApplicationView.exportExcel.EnumColor;
using System;

namespace ApplicationView.exportExcel.Color
{
    public class Colors
    {
        #region Singleton
        private static Colors instance;
        public static Colors GetInstance()
        {
            if (instance == null)
                instance = new Colors();
            return instance;
        }
        #endregion

        public System.Drawing.Color GetColor(ColorEnum color)
        {
            switch (color)
            {
                case ColorEnum.Blue: return System.Drawing.Color.FromArgb(84, 107, 175);
                case ColorEnum.Pink: return System.Drawing.Color.FromArgb(224, 103, 121);
                case ColorEnum.Green: return System.Drawing.Color.FromArgb(75, 191, 168);
                case ColorEnum.Violet: return System.Drawing.Color.FromArgb(129, 104, 151);
                case ColorEnum.Yellow: return System.Drawing.Color.FromArgb(238, 199, 72);
                case ColorEnum.DarkGrey: return System.Drawing.Color.FromArgb(74, 74, 74);
                case ColorEnum.LightGrey: return System.Drawing.Color.FromArgb(230, 230, 230);
                default: return System.Drawing.Color.White;
            }
        }

        public String GetColor(ColorEnum color, Int16 type)
        {
            switch (color)
            {
                case ColorEnum.Blue: if (type == 1) { return "#546baf"; } { return "84, 107, 175"; }
                case ColorEnum.Pink: if (type == 1) { return "#e06779"; } { return "224, 103, 121"; }
                case ColorEnum.Green: if (type == 1) { return "#4bbfa8"; } { return "75, 191, 168"; }
                case ColorEnum.Violet: if (type == 1) { return "#816897"; } { return "129, 104, 151"; }
                case ColorEnum.Yellow: if (type == 1) { return "#eec748"; } { return "238, 199, 72"; }
                case ColorEnum.DarkGrey: if (type == 1) { return "#4a4a4a"; } { return "74, 74, 74"; }
                case ColorEnum.LightGrey: if (type == 1) { return "#e6e6e6"; } { return "230, 230, 230"; }
                default: if (type == 1) { return "#ffffff"; } { return "255, 255, 255"; }
            }
        }
    }
}
