using System;
using Cairo;

namespace clock
{
    public class WatchClock
    {
        public void WriteLine(Gdk.Window drawingArea, double Calculate, double[] Colors, int length, int width)
        {
            Cairo.Context ring = Gdk.CairoHelper.Create(drawingArea);

            PointD startPoint = new PointD(0, 0);
            PointD finishPoint = new PointD(0, -1 * length);

            ring.Translate(100, 100);
            ring.Rotate(Calculate);
            ring.LineWidth = width;
            ring.MoveTo(startPoint);
            ring.LineTo(finishPoint);
            ring.LineCap = LineCap.Round;

            ring.SetSourceColor(new Cairo.Color(Colors[0], Colors[1], Colors[2]));
            ring.Stroke();

            ring.GetTarget().Dispose();
            ring.Dispose();
        }
    }
}