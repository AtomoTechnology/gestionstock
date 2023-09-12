using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationView.Forms.RedesignForm
{
    public class Redesign
    {
        private int borderRadius = 20;

        private static Redesign _instancia;

        public static Redesign GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new Redesign();
            }
            return _instancia;
        }
        public GraphicsPath GetRoundedPath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        public void DrawPath(Rectangle rect, Graphics graph, Color color)
        {
            using (GraphicsPath roundPath = GetRoundedPath(rect, borderRadius))
            using (Pen penBorder = new Pen(color, 0))
            {
                graph.DrawPath(penBorder, roundPath);
            }
        }
    }

    public struct FormBoundsColors
    {
        public Color TopLeftColor;
        public Color TopRightColor;
        public Color BottomLeftColor;
        public Color BottomRightColor;
    }
}
