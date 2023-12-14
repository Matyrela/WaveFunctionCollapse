using ZeroElectric.Vinculum;
using static WaveFunctionCollapse.TerrainTypes;


namespace WaveFunctionCollapse;

public class Terrain
{
    TerrainTypes[,] Map;
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
        
        Map = new TerrainTypes[width, height];
        
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                Map[i,j] = Empty;
            }
        }
        
        totalWidth = Width * CellSize;
        totalHeight = Height * CellSize;
        startX = (Program.ScreenWidth - totalWidth) / 2;
        startY = (Program.ScreenHeight - totalHeight) / 2;
    }
    
    public void Generate()
    {
        for(int i = 0; i < Width; i++)
        {
            for(int j = 0; j < Height; j++)
            {
                Map[i,j] = Empty;
            }
        }
        
        Random rnd = new Random();

        int[] centerCoords = new int[2];
        centerCoords[0] = Width / 2;
        centerCoords[1] = Height / 2;

        Map[centerCoords[0], centerCoords[1]] = Grass;

        
    }
    
    public void Draw()
    {
        for(int i = 0; i < Width; i++)
        {
            for(int j = 0; j < Height; j++)
            {
                int x = startX + i * CellSize;
                int y = startY + j * CellSize;
                
                switch (Map[i, j])
                {
                    case Water:
                        Raylib.DrawRectangle(x, y, CellSize, CellSize, new Color(0, 0, 255, 255));
                        break;
                    
                    case Sand:
                        Raylib.DrawRectangle(x, y, CellSize, CellSize, new Color(255, 255, 0, 255));
                        break;
                    
                    case Grass:
                        Raylib.DrawRectangle(x, y, CellSize, CellSize, new Color(0, 255, 0, 255));
                        break;
                    
                    case Rock:
                        Raylib.DrawRectangle(x, y, CellSize, CellSize, new Color(128, 128, 128, 255));
                        break;
                    
                    default:
                        Raylib.DrawRectangle(x, y, CellSize, CellSize, new Color(255, 0, 255, 255));
                        break;
                }
                
                Raylib.DrawRectangleLines(x, y, CellSize, CellSize, new Color(0, 0, 0, 255));
            }
        }
    }
}