using System.Drawing.Drawing2D;
using Timer = System.Windows.Forms.Timer;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private const int Xsize = 352; //176
        private const int Ysize = 288; //144
        private const int sizeOfBWFrame = Xsize * Ysize;
        private const int sizeOfFrameComponent = Xsize * Ysize / 4;
        private const int dataBufferSize = sizeOfBWFrame + sizeOfFrameComponent * 2;
        private const string filename = "akiyo_cif.yuv";

        private readonly byte[] dataBuffer = new byte[dataBufferSize];
        private int currentFrame;
        private Timer timer = new();
        private DirectBitmap bitmap = new(Xsize, Ysize);

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
            //var fps = 30;
            timer.Interval = 1000 / (int)nudFrameRate.Value;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void InitializeControls()
        {
            // interpolation
            var interpolationValues = Enum.GetValues<InterpolationMode>().Select(i => i.ToString()).ToList();
            interpolationValues.Remove("Invalid");
            cbInterpolationMode.Items.AddRange(interpolationValues.ToArray());
            cbInterpolationMode.SelectedIndex = 5;

            //public CompositingQuality CompositingQuality { get; set; }
            var compositingQualityValues = Enum.GetValues<CompositingQuality>().Select(i => i.ToString()).ToList();
            //interpolationValues.Remove("Invalid");
            cbCompositingQuality.Items.AddRange(compositingQualityValues.ToArray());
            cbCompositingQuality.SelectedIndex = 0;

            //public CompositingMode CompositingMode { get; set; }
            var CompositingModeValues = Enum.GetValues<CompositingMode>().Select(i => i.ToString()).ToList();
            //interpolationValues.Remove("Invalid");
            cbCompositingMode.Items.AddRange(CompositingModeValues.ToArray());
            cbCompositingMode.SelectedIndex = 0;

            //public PixelOffsetMode PixelOffsetMode { get; set; }
            var PixelOffsetModeValues = Enum.GetValues<PixelOffsetMode>().Select(i => i.ToString()).ToList();
            //interpolationValues.Remove("Invalid");
            cbPixelOffsetMode.Items.AddRange(PixelOffsetModeValues.ToArray());
            cbPixelOffsetMode.SelectedIndex = 0;


        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            currentFrame++;
            if (currentFrame >= 300) currentFrame = 0;
            RepaintPicture();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            RepaintPicture();
        }

        private void RepaintPicture()
        {
            FillBufferWithNewFrame();
            for (int y = 0; y < Ysize - 1; y++)
            {
                for (int x = 0; x < Xsize - 1; x++)
                {
                    var Y = dataBuffer[y * Xsize + x];
                    var currentOffsetInComponents = (y >> 1) * (Xsize >> 1) + (x >> 1);
                    var currentOffset = sizeOfBWFrame + currentOffsetInComponents;
                    var u = !checkBox1.Checked ? 0 :
                        dataBuffer[currentOffset] - 128;
                    var v = !checkBox1.Checked ? 0 :
                        dataBuffer[currentOffset + sizeOfFrameComponent] - 128;

                    var r = Cap(Y + ((73 * v) >> 6));
                    var g = Cap(Y - ((101 * u) >> 8) - ((595 * v) >> 10));
                    var b = Cap(Y + ((1041 * u) >> 9));

                    bitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            pictureBox1.Image = bitmap.Bitmap;
        }

        private void FillBufferWithNewFrame()
        {
            using var file = File.OpenRead(filename);
            int bytesRead;

            file.Seek(dataBufferSize * currentFrame, SeekOrigin.Begin);
            bytesRead = file.Read(dataBuffer, 0, dataBuffer.Length);
        }

        private int Cap(int input)
        {
            if (input < 0) return 0;
            if (input > 255) return 255;

            return input;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            RepaintPicture();
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            switchModes();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            switchModes();
        }

        private void switchModes()
        {
            if (WindowState == FormWindowState.Maximized)
                SetWindowed();
            else
                SetFullScreen();
        }

        private void SetFullScreen()
        {
            OriginalStyle = FormBorderStyle;
            OriginalState = WindowState;
            OriginalHeight = Height;
            OriginalWidth = Width;

            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
        }

        private FormBorderStyle OriginalStyle;
        private FormWindowState OriginalState;
        private int OriginalWidth;
        private int OriginalHeight;

        private void SetWindowed()
        {
            FormBorderStyle = OriginalStyle;
            WindowState = OriginalState;
            Width = OriginalWidth;
            Height = OriginalHeight;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = sender as ComboBox;

            pictureBox1.InterpolationMode = Enum.Parse<InterpolationMode>(combo.SelectedItem.ToString());
            BeginInvoke(new Action(() => combo.Select(int.MaxValue, 0)));
        }

        private void nudFrameRate_ValueChanged(object sender, EventArgs e)
        {
            timer.Interval = 1000 / (int)nudFrameRate.Value;
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
}