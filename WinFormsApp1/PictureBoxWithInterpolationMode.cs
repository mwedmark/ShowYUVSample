using System.Drawing.Drawing2D;

public class PictureBoxWithInterpolationMode : PictureBox
{
    public InterpolationMode InterpolationMode { get; set; }
    public CompositingQuality CompositingQuality { get; set; }
    public CompositingMode CompositingMode { get; set; }
    public PixelOffsetMode PixelOffsetMode { get; set; }

    protected override void OnPaint(PaintEventArgs paintEventArgs)
    {
        paintEventArgs.Graphics.InterpolationMode = InterpolationMode;
        paintEventArgs.Graphics.CompositingQuality = CompositingQuality;
        paintEventArgs.Graphics.CompositingMode = CompositingMode;
        paintEventArgs.Graphics.PixelOffsetMode = PixelOffsetMode;
        //paintEventArgs.Graphics.Transform
        base.OnPaint(paintEventArgs);
    }
}