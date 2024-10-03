using System.Drawing.Drawing2D;
using Timer = System.Windows.Forms.Timer;

namespace WinFormsApp1;

public partial class Form1 : Form
{
    private readonly VideoBuffer _videoBuffer = new();
    private readonly Timer _timer = new();

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        SetupTimer();
        InitializeControls();
    }

    private void SetupTimer()
    {
        _timer.Interval = 1000 / (int)nudFrameRate.Value;
        _timer.Tick += Timer_Tick;
        _timer.Start();
    }

    private void InitializeControls()
    {
        var interpolationValues = Enum.GetValues<InterpolationMode>().Select(i => i.ToString()).ToList();
        interpolationValues.Remove("Invalid");
        cbInterpolationMode.Items.AddRange(interpolationValues.ToArray());
        cbInterpolationMode.SelectedIndex = 5;

        var compositingQualityValues = Enum.GetValues<CompositingQuality>().Select(i => i.ToString()).ToList();
        cbCompositingQuality.Items.AddRange(compositingQualityValues.ToArray());
        cbCompositingQuality.SelectedIndex = 0;

        var compositingModeValues = Enum.GetValues<CompositingMode>().Select(i => i.ToString()).ToList();
        cbCompositingMode.Items.AddRange(compositingModeValues.ToArray());
        cbCompositingMode.SelectedIndex = 0;

        var pixelOffsetModeValues = Enum.GetValues<PixelOffsetMode>().Select(i => i.ToString()).ToList();
        cbPixelOffsetMode.Items.AddRange(pixelOffsetModeValues.ToArray());
        cbPixelOffsetMode.SelectedIndex = 0;


    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        _videoBuffer.CurrentFrame++;
        if (_videoBuffer.CurrentFrame >= 300) _videoBuffer.CurrentFrame = 0;
        RepaintPicture();
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        RepaintPicture();
    }

    private void RepaintPicture()
    {
        _videoBuffer.FillBufferWithNewFrame();
        _videoBuffer.CalculateFrame(checkBox1.Checked);
        pictureBox1.Image = _videoBuffer.DirectBitmap.Bitmap;
    }
       
    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        RepaintPicture();
    }

    private void Form1_DoubleClick(object sender, EventArgs e)
    {
        SwitchModes();
    }

    private void pictureBox1_DoubleClick(object sender, EventArgs e)
    {
        SwitchModes();
    }

    private void SwitchModes()
    {
        if (WindowState == FormWindowState.Maximized)
            SetWindowed();
        else
            SetFullScreen();
    }

    private void SetFullScreen()
    {
        _originalStyle = FormBorderStyle;
        _originalState = WindowState;
        _originalHeight = Height;
        _originalWidth = Width;

        FormBorderStyle = FormBorderStyle.None;
        WindowState = FormWindowState.Maximized;
    }

    private FormBorderStyle _originalStyle;
    private FormWindowState _originalState;
    private int _originalWidth;
    private int _originalHeight;

    private void SetWindowed()
    {
        FormBorderStyle = _originalStyle;
        WindowState = _originalState;
        Width = _originalWidth;
        Height = _originalHeight;
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var combo = sender as ComboBox;

        pictureBox1.InterpolationMode = Enum.Parse<InterpolationMode>(combo.SelectedItem.ToString());
        BeginInvoke(new Action(() => combo.Select(int.MaxValue, 0)));
    }

    private void nudFrameRate_ValueChanged(object sender, EventArgs e)
    {
        _timer.Interval = 1000 / (int)nudFrameRate.Value;
    }

    private void nudFrameRate_Leave(object sender, EventArgs e)
    {
        var nudControl = sender as NumericUpDown;

        if (nudControl!.Text == "")
        {
            nudControl.Text = "30";
        }
    }
}