using System;

namespace Ieo.EarthFileApi.Files.Levels
{
    public class EarthLndData : IEarthData
    {
        public int MapWidth { get; set; }
        public int MapHeight { get; set; }
        /// <summary>
        /// Always 16?
        /// </summary>
        public int UnknownField { get; set; }
        public string LevelName { get; set; }
        public TerrainType TerrainType { get; set; }
        public short[] TerrainHeight { get; set; } = Array.Empty<short>();
        public byte[] Tunnels { get; set; } = Array.Empty<byte>();
        public byte[] TerrainTextures { get; set; } = Array.Empty<byte>();
        public byte[] Resources { get; set; } = Array.Empty<byte>();
        public int LevelWaterHeight { get; set; }
        public short[] WaterHeight { get; set; } = Array.Empty<short>();
    }
}
