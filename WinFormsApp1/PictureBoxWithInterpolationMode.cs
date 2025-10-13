using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace WinFormsApp1;

public class PictureBoxWithInterpolationMode : PictureBox
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public InterpolationMode InterpolationMode { get; set; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public CompositingQuality CompositingQuality { get; set; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public CompositingMode CompositingMode { get; set; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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