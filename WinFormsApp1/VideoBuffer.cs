namespace WinFormsApp1;

public class VideoBuffer
{
    public const int XSize = 352; //176
    public const int YSize = 288; //144
    public const int SizeOfBwFrame = XSize * YSize;
    public const int SizeOfFrameComponent = XSize * YSize / 4;
    private const int DataBufferSize = SizeOfBwFrame + SizeOfFrameComponent * 2;
    private const string Filename = "akiyo_cif.yuv";
    public readonly DirectBitmap DirectBitmap = new(XSize, YSize);

    public readonly byte[] DataBuffer = new byte[DataBufferSize];
    public int CurrentFrame;

    public void FillBufferWithNewFrame()
    {
        using var file = File.OpenRead(Filename);

        file.Seek(DataBufferSize * CurrentFrame, SeekOrigin.Begin);
        var read = file.Read(DataBuffer, 0, DataBuffer.Length);
    }

    public void CalculateFrame(bool useColor)
    {
        for (var y = 0; y < YSize - 1; y++)
        {
            for (var x = 0; x < XSize - 1; x++)
            {
                var Y = DataBuffer[y * XSize + x];
                var currentOffsetInComponents = (y >> 1) * (XSize >> 1) + (x >> 1);
                var currentOffset = SizeOfBwFrame + currentOffsetInComponents;
                var u = !useColor ? 0 : DataBuffer[currentOffset] - 128;
                var v = !useColor
                    ? 0
                    : DataBuffer[currentOffset + SizeOfFrameComponent] - 128;

                var r = Cap(Y + ((73 * v) >> 6));
                var g = Cap(Y - ((101 * u) >> 8) - ((595 * v) >> 10));
                var b = Cap(Y + ((1041 * u) >> 9));

                DirectBitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
            }
        }
    }

    private static int Cap(int input)
    {
        return input switch
        {
            < 0 => 0,
            > 255 => 255,
            _ => input
        };
    }

}