using System;

namespace Ieo.EarthFileApi.Files
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
      /// <summary>
      /// Not fully recognised field. The last byte contains terrain type. First 15 seem to always be "ea ea ea ea 50 21 50 21 00 01 00 00 00 00 00"
      /// </summary>
      public string LevelInfo { get; set; }
      public short[] TerrainHeight { get; set; } = Array.Empty<short>();
      public byte[] Tunnels { get; set; } = Array.Empty<byte>();
      public byte[] TerrainTextures { get; set; } = Array.Empty<byte>();
      public byte[] Resources { get; set; } = Array.Empty<byte>();
      public int LevelWaterHeight { get; set; }
      public short[] WaterHeight { get; set; } = Array.Empty<short>();
   }
}
