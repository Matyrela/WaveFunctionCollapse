using ZeroElectric.Vinculum;

namespace WaveFunctionCollapse;

public class Terrain
{
    int[,] Map;
    int Width;
    int Height;
    
    const int CellSize = 30;
    int totalWidth = 0;
    int totalHeight = 0;
    private int startX = 0;
    private int startY = 0;
    
    public Terrain(int width, int height)
    {
        Width = width;
        Height = height;
        
        Map = new int[width, height];
        
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                Map[i,j] = -1;
            }
        }
        
        totalWidth = Width * CellSize;
        totalHeight = Height * CellSize;
        startX = (Program.ScreenWidth - totalWidth) / 2;
        startY = (Program.ScreenHeight - totalHeight) / 2;
    }
    
    public void Generate()
    {
        
    }
    
    public void Draw()
    {
        for(int i = 0; i < Width; i++)
        {
            for(int j = 0; j < Height; j++)
            {
                int x = startX + i * CellSize;
                int y = startY + j * CellSize;

                Raylib.DrawRectangleLines(x, y, CellSize, CellSize, new Color(0, 0, 0, 255));

                string text = Map[i,j].ToString();
                int textWidth = Raylib.MeasureText(text, CellSize);
                int textX = x + (CellSize - textWidth) / 2;
                int textY = y + (CellSize - CellSize) / 2;

                Raylib.DrawText(text, textX, textY, CellSize, new Color(0, 0, 0, 255));
            }
        }
    }
}