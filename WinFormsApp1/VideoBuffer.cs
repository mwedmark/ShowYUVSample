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
    private readonly C64Colors _c64Colors = new();

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
        //int matrixMax = bayerMatrix.Length;
        
        int offsetX = 0; // or e.g. CurrentFrame % matrixSize for slow drift
        int offsetY = 0;
        var selectedColors = !useColor ? _c64Colors.GetGreyscaleColors() : _c64Colors.GetAllColors();
        
        Parallel.For(0, YSize - 1, y =>
        {
            for (var x = 0; x < XSize - 1; x++)
            {
                var Y = DataBuffer[y * XSize + x];
                var currentOffsetInComponents = (y >> 1) * (XSize >> 1) + (x >> 1);
                var currentOffset = SizeOfBwFrame + currentOffsetInComponents;
                var u = !useColor ? 0 : DataBuffer[currentOffset] - 128;
                var v = !useColor ? 0 : DataBuffer[currentOffset + SizeOfFrameComponent] - 128;

                // Use this if dither is used with 5 greyscale colors (c64 colors)
                int r = 0, g = 0, b = 0;
                if (c64Dither)
                {
                    var palette = selectedColors;
                    int matrixValue = bayerMatrix[(y + offsetY) % matrixSize, (x + offsetX) % matrixSize];
                
                    // Calculate the original RGB value
                    int origR, origG, origB;
                    if (!useColor)
                    {
                        origR = origG = origB = Y;
                    }
                    else
                    {
                        origR = Cap(Y + ((73 * v) >> 6));
                        origG = Cap(Y - ((101 * u) >> 8) - ((595 * v) >> 10));
                        origB = Cap(Y + ((1041 * u) >> 9));
                    }
                
                    // Calculate Bayer threshold (0-24 scaled to -32 to +32 range)
                    int threshold = (matrixValue * 64 / 24) - 32;
                
                    // Apply threshold to create dithered values
                    int ditheredR = Cap(origR + threshold);
                    int ditheredG = Cap(origG + threshold);
                    int ditheredB = Cap(origB + threshold);
                
                    // Find the closest C64 color to the dithered value
                    var selected = palette
                            .OrderBy(c =>
                                Math.Pow(c.R - ditheredR, 2) +
                                Math.Pow(c.G - ditheredG, 2) +
                                Math.Pow(c.B - ditheredB, 2))
                            .First();
                
                    r = selected.R;
                    g = selected.G;
                    b = selected.B;
                }
                
                else
                {
                    r = Cap(Y + ((73 * v) >> 6));
                    g = Cap(Y - ((101 * u) >> 8) - ((595 * v) >> 10));
                    b = Cap(Y + ((1041 * u) >> 9));
                }
                var selectedColor = Color.FromArgb(r, g, b);

                DirectBitmap.SetPixel(x, y, selectedColor);
            }
        });

        //CreateKoalaCompatibleImage();
        //Console.Write($"Frame {CurrentFrame} calculated,");

    }

    public void CreateKoalaCompatibleImage()
    {
        // Loop through each 4x8 patch of the full picture (160x200)
        var patchColorDictionary = new Dictionary<Point, HashSet<Color>>();
        for (var patchY = 0; patchY < DirectBitmap.Height; patchY += 8)
        {
            for (var patchX = 0; patchX < DirectBitmap.Width; patchX += 4)
            {
                var currentColors = new HashSet<Color>();
                // Process each pixel within the current 4x8 patch
                for (var y = patchY; y < patchY + 8 && y < DirectBitmap.Height; y++)
                {
                    for (var x = patchX; x < patchX + 4 && x < DirectBitmap.Width; x++)
                    {
                        // Example: Retrieve the color of the pixel
                        var pixelColor = DirectBitmap.GetPixel(x, y);
                        currentColors.Add(pixelColor);
                        // Perform any processing on the pixel here
                        // For example, you could modify the pixel color or analyze the patch
                        // DirectBitmap.SetPixel(x, y, modifiedColor);
                    }
                }
                
                patchColorDictionary.Add(new Point(patchX, patchY), currentColors);
                // Decide best background color, start by grouping tiles per  color count.
                
                //if(currentColors.Count > 4)
                //    Console.Write($"{currentColors.Count},");

                // Example: Perform operations on the entire patch here
                // This could include analyzing the patch or applying transformations
                //Console.WriteLine($"Processed patch at ({patchX}, {patchY})");
            }
        }
        
        // Sort Patches on Color count
        var sortedTiles = patchColorDictionary
            .GroupBy(kv => kv.Value.Count)
            .OrderByDescending(k => k.Key).ToList();
        
        var overColoredTiles =  patchColorDictionary.Where(k => k.Value.Count > 3).ToList();
        var perColorUsage = overColoredTiles.SelectMany(kv => kv.Value)
            .GroupBy(c => c)
            .Select(g => new { Color = g.Key, Count = g.Count() })
            .OrderByDescending(g => g.Count)
            .ToList();

        if (!perColorUsage.Any())
            return;
        
        // Select most used color as background color
        var backgroundColor = perColorUsage.FirstOrDefault()?.Color;

        if (backgroundColor == null)
            return;
        
        // Now try to reduce colors in each tile
        foreach (var tile in overColoredTiles)
        {
            var colorsInTile = tile.Value.ToList();
            // Remove background color from list
            colorsInTile.Remove(backgroundColor.Value);
            // Select the two most used colors in the tile
            var selectedColors = colorsInTile.Take(2).ToList();
            // If less than 2 colors, fill with background color
            // while (selectedColors.Count < 2)
            // {
            //     selectedColors.Add(backgroundColor);
            // }
                
            // Now we have 3 colors for the tile, map all pixels to these colors
            for (var y = tile.Key.Y; y < tile.Key.Y + 8 && y < DirectBitmap.Height; y++)
            {
                for (var x = tile.Key.X; x < tile.Key.X + 4 && x < DirectBitmap.Width; x++)
                {
                    var pixelColor = DirectBitmap.GetPixel(x, y);
                    // Find the closest color among the selected colors
                    var closestColor = selectedColors
                        .OrderBy(c =>
                            Math.Pow(c.R - pixelColor.R, 2) +
                            Math.Pow(c.G - pixelColor.G, 2) +
                            Math.Pow(c.B - pixelColor.B, 2))
                        .First();
                    // Update the pixel to the closest color
                    DirectBitmap.SetPixel(x, y, closestColor);
                }
            }
        }
        
        // new reenter all overColoredTiles into original dictionary
        foreach (var tile in overColoredTiles)
        {
            patchColorDictionary[tile.Key] = tile.Value;
        }
        
        // All done!
        
            
        //Console.Write($"{overColoredTiles},");
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