namespace WinFormsApp1;

public class VideoBuffer
{
    public const int XSize = 352; //176
    public const int YSize = 288; //144
    public const int SizeOfBwFrame = XSize * YSize;
    public const int SizeOfFrameComponent = XSize * YSize / 4;
    private const int DataBufferSize = SizeOfBwFrame + SizeOfFrameComponent * 2;
    private const string Filename = "akiyo_cif.yuv";
    public DirectBitmap DirectBitmap = new(XSize, YSize);

    public readonly byte[] DataBuffer = new byte[DataBufferSize];
    public int CurrentFrame;

    public void FillBufferWithNewFrame(bool c64Dither)
    {
        //if(c64Dither)
        DirectBitmap = new(XSize, YSize);
        
        using var file = File.OpenRead(Filename);

        file.Seek(DataBufferSize * CurrentFrame, SeekOrigin.Begin);
        var read = file.Read(DataBuffer, 0, DataBuffer.Length);
    }

    public void CalculateFrame(bool useColor, bool c64Dither = false)
    {
        var bayerMatrix = new[,]
        {
            {  0, 13,  7, 19,  3 },
            { 17,  5, 21,  9, 11 },
            {  8, 20,  2, 14,  6 },
            { 24, 12, 16,  4, 22 },
            { 10, 18, 23,  1, 15 }
        };
        int matrixSize = bayerMatrix.GetLength(0);
        int matrixMax = bayerMatrix.Length;
        
        int offsetX = 0; // or e.g. CurrentFrame % matrixSize for slow drift
        int offsetY = 0;
        
        for (var y = 0; y < YSize - 1; y++)
        {
            for (var x = 0; x < XSize - 1; x++)
            {
                var Y = DataBuffer[y * XSize + x];
                var currentOffsetInComponents = (y >> 1) * (XSize >> 1) + (x >> 1);
                var currentOffset = SizeOfBwFrame + currentOffsetInComponents;
                var u = !useColor ? 0 : DataBuffer[currentOffset] - 128;
                var v = !useColor ? 0 : DataBuffer[currentOffset + SizeOfFrameComponent] - 128;
    
                // Use this if dither is used with 5 greyscale colors (c64 colors)
                if(c64Dither)
                {
                    var term = 255 / 5;
                    var quantize5Steps = (byte)(Y / term * term);
                    // Stable ordered dithering using Bayer matrix with offset
                    int threshold = bayerMatrix[(y + offsetY) % matrixSize, (x + offsetX) % matrixSize];
                    int diff = Y % term;
                    int dither = (diff * matrixMax / term) > threshold ? term : 0;
                    Y = (byte)Math.Min(255, quantize5Steps + dither);
                }
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