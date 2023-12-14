using ZeroElectric.Vinculum;

namespace WaveFunctionCollapse;

public static class Program
{
    public static int ScreenWidth = 800;
    public static int ScreenHeight = 450;
    
    public static void Main(string[] args)
    {
        int mapWidth = 10;
        int mapHeight = 10;
        
        try
        {
            mapWidth = int.Parse(args[0]);
            mapHeight = int.Parse(args[1]);
        }
        catch(Exception e)
        {
            Console.WriteLine("Invalid arguments, using default values.");
            Console.WriteLine("Program arguments: <mapWidth> <mapHeight>");
        }
        
        Terrain terrain = new Terrain(mapWidth, mapHeight);
        terrain.Generate();

        Raylib.InitWindow(ScreenWidth, ScreenHeight, "WaveFunctionCollapse");

        Raylib.SetTargetFPS(60);
        
        string credits = "By Matyrela";
        int textOffset = 5;
        
        bool pressed = false;
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(new Color(255,255,255,1));
            
            if(Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && !pressed)
            {
                terrain.Generate();
                pressed = true;
            }
            else if(!Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                pressed = false;
            }
            
            terrain.Draw();
            
            Raylib.DrawText("Wave Function Collapse for terrain generation:", textOffset, 0, 15, new Color(255, 0, 0, 255));
            Raylib.DrawText(credits, ScreenWidth - (15 * credits.Length / 2) - textOffset, ScreenHeight - 15, 15, new Color(255, 0, 0, 255));
            Raylib.DrawText("Press SPACE to generate map", textOffset, ScreenHeight - 15, 15, new Color(255, 0, 0, 255));
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}