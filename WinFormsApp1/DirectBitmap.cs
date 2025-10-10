using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace WinFormsApp1;

public class DirectBitmap : IDisposable
{
    public Bitmap Bitmap { get; private set; }
    public int[] Bits { get; private set; }
    public bool Disposed { get; private set; }
    public int Height { get; private set; }
    public int Width { get; private set; }

    protected GCHandle BitsHandle { get; private set; }

    public DirectBitmap(int width, int height)
    {
        Width = width;
        Height = height;
        Bits = new int[width * height];
        BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
        Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
    }

    public void SetPixel(int x, int y, Color color)
    {
        var index = x + (y * Width);
        var col = color.ToArgb();

        Bits[index] = col;
    }

    public DirectBitmap ResizeBitmap(int newWidth, int newHeight)
    {
        if (newWidth <= 0 || newHeight <= 0)
            throw new ArgumentException("Width and height must be positive.");

        var resized = new DirectBitmap(newWidth, newHeight);
        float xRatio = (float)Width / newWidth;
        float yRatio = (float)Height / newHeight;

        for (int y = 0; y < newHeight; y++)
        {
            int srcY = Math.Min((int)(y * yRatio), Height - 1);
            for (int x = 0; x < newWidth; x++)
            {
                int srcX = Math.Min((int)(x * xRatio), Width - 1);
                Color color = GetPixel(srcX, srcY);
                resized.SetPixel(x, y, color);
            }
        }

        return resized;
    }



    public Color GetPixel(int x, int y)
    {
        var index = x + (y * Width);
        var col = Bits[index];
        var result = Color.FromArgb(col);

        return result;
    }

    public void Dispose()
    {
        if (Disposed) return;
        Disposed = true;
        Bitmap.Dispose();
        BitsHandle.Free();
    }
}