using static WaveFunctionCollapse.TerrainTypes;

namespace WaveFunctionCollapse
{
    public struct TerrainRules
    {
        public static Dictionary<TerrainTypes, List<TerrainTypes>> Rules = new Dictionary<TerrainTypes, List<TerrainTypes>>
        {
            { Empty, new List<TerrainTypes> { Water, Sand, Grass, Rock } },
            
            { Water, new List<TerrainTypes> { Water, Sand } },
            { Sand, new List<TerrainTypes> { Grass, Water } },
            { Grass, new List<TerrainTypes> { Sand, Grass } },
            { Rock, new List<TerrainTypes> { Rock, Grass } },
        };
    }
}