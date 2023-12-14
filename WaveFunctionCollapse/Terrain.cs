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
                Map[i,j] = (int) TerrainTypes.Empty;
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
                Map[i,j] = (int) TerrainTypes.Empty;
            }
        }
        
        Map[0, 0] = (int)TerrainTypes.Water;
        
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                switch (Map[x, y])
                {
                    case (int)TerrainTypes.Water:
                        GenerateAdyacent(x, y, new int[] { (int)TerrainTypes.Water, (int)TerrainTypes.Sand }, new int[] { 90, 10 });
                        break;
                    
                    case (int)TerrainTypes.Sand:
                        GenerateAdyacent(x, y, new int[] { (int)TerrainTypes.Sand, (int)TerrainTypes.Grass }, new int[] { 90, 10 });
                        break;
                    
                    case (int)TerrainTypes.Grass:
                        GenerateAdyacent(x, y, new int[] { (int)TerrainTypes.Grass, (int)TerrainTypes.Rock }, new int[] { 90, 10 });
                        break;
                    
                    case (int)TerrainTypes.Rock:
                        GenerateAdyacent(x, y, new int[] { (int)TerrainTypes.Rock, (int)TerrainTypes.Grass }, new int[] { 90, 10 });
                        break;
                }
            }
        }
    }

    public void GenerateAdyacent(int x, int y, int[] possibleValues, int[] chances)
    {
        Random random = new Random();
        int[] adyacentX = new int[] { x - 1, x + 1, x, x };
        int[] adyacentY = new int[] { y, y, y - 1, y + 1 };

        for (int i = 0; i < adyacentX.Length; i++)
        {
            if (adyacentX[i] >= 0 && adyacentX[i] < Width && adyacentY[i] >= 0 && adyacentY[i] < Height)
            {
                int value = Map[adyacentX[i], adyacentY[i]];
                if (value == (int)TerrainTypes.Empty)
                {
                    int newValue = possibleValues[0];
                    int chance = chances[0];

                    for (int j = 0; j < possibleValues.Length; j++)
                    {
                        if (random.Next(0, 100) < chances[j])
                        {
                            newValue = possibleValues[j];
                            chance = chances[j];
                        }
                    }

                    Map[adyacentX[i], adyacentY[i]] = newValue;
                }
            }
        }
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
                    case (int)TerrainTypes.Water:
                        Raylib.DrawRectangle(x, y, CellSize, CellSize, new Color(0, 0, 255, 255));
                        break;
                    
                    case (int)TerrainTypes.Sand:
                        Raylib.DrawRectangle(x, y, CellSize, CellSize, new Color(255, 255, 0, 255));
                        break;
                    
                    case (int)TerrainTypes.Grass:
                        Raylib.DrawRectangle(x, y, CellSize, CellSize, new Color(0, 255, 0, 255));
                        break;
                    
                    case (int)TerrainTypes.Rock:
                        Raylib.DrawRectangle(x, y, CellSize, CellSize, new Color(128, 128, 128, 255));
                        break;
                    
                    default:
                        break;
                }
                
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