using System;
using Gtk;
using clock;

/// <summary>
/// Main window.
/// </summary>
public partial class MainWindow : Gtk.Window
{
    /// <summary>
    /// The clock.
    /// </summary>
    WatchClock clock;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:MainWindow"/> class.
    /// </summary>
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();

        drawingArea.ModifyBg(StateType.Normal, new Gdk.Color(5, 5, 5));

        clock = new WatchClock();

        ClockStart();
    }

    /// <summary>
    /// Clocks the start.
    /// </summary>
    void ClockStart()
    {
        GLib.Timeout.Add(100, new GLib.TimeoutHandler(Update));
    }

    /// <summary>
    /// Update clock.
    /// </summary>
    bool Update()
    {
        drawingArea.GdkWindow.Clear();
        clock.WriteLine(drawingArea.GdkWindow, (Math.PI * 2 * (DateTime.Now.Hour % 12) * 60 + DateTime.Now.Minute) / 720, new double[3] {1, 1, 1}, 50, 8);
        clock.WriteLine(drawingArea.GdkWindow, Math.PI * 2 * DateTime.Now.Minute / 60, new double[3] { 1, 1, 1 }, 70, 8);
        clock.WriteLine(drawingArea.GdkWindow, Math.PI * 2 * DateTime.Now.Second / 60, new double[3] { 1, 0, 0 }, 90, 4);

        return true;
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
}
