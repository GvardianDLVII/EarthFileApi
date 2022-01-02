using System;
using System.Collections.Generic;
using System.Linq;

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
      /// Not recognised field. 15 bytes long, it seems to always be "ea ea ea ea 50 21 50 21 00 01 00 00 00 00 00"
      /// </summary>
      public byte[] LevelInfo { get; } = new byte[] { 0xEA, 0xEA, 0xEA, 0xEA, 0x50, 0x21, 0x50, 0x21, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 };
      public TerrainType TerrainType { get; set; }
      public short[] TerrainHeight { get; set; } = Array.Empty<short>();
      public byte[] Tunnels { get; set; } = Array.Empty<byte>();
      public byte[] TerrainTextures { get; set; } = Array.Empty<byte>();
      public byte[] Resources { get; set; } = Array.Empty<byte>();
      public int LevelWaterHeight { get; set; }
      public short[] WaterHeight { get; set; } = Array.Empty<short>();
   }
}
