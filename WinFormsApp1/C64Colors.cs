namespace WinFormsApp1;

public class C64Colors
{
    private readonly Color[] _c64Colours = new Color[16];
    public C64Colors()
    {
        InitializeC64Colors();
    }
    
    private void InitializeC64Colors()
    {
        var argbValues = new []
        {
            0xFF000000, 0xFFFFFFFF, 0xFF744335, 0xFF7CACBA,
            0xFF7B4890, 0xFF64974F, 0xFF403285, 0xFFBFCD7A,
            0xFF7B5B2F, 0xFF4F4500, 0xFFA37265, 0xFF505050,
            0xFF787878, 0xFFA4D78E, 0xFF786ABD, 0xFF9F9F9F
        };

        for (var i = 0; i < 16; i++)
        {
            _c64Colours[i] = Color.FromArgb((int)argbValues[i]);
        }
    }
    
    public List<Color> GetGreyscaleColors()
    {
        var greys = _c64Colours
            .Where(color => color.R == color.G && color.G == color.B).ToList();
        return greys.OrderBy(g => g.R).ToList();
    }

    public List<Color> GetAllColors()
    {
        return _c64Colours.ToList();
    }
    
}