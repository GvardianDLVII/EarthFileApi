using System;
using System.Collections.Generic;
using System.Linq;

namespace Ieo.EarthFileApi.Files
{
   public class EarthMisData : IEarthData
   {
      public string UnknownOptionalString { get; set; }
      public Guid LndFileId { get; set; }
      public bool ShipsEnabled { get; set; }
      public WaterType WaterType { get; set; }
      public int TotalResources { get; set; }
      public short LevelWidth { get; set; }
      public short LevelHeight { get; set; }
      /// <summary>
      /// Always 1?
      /// </summary>
      public int UnknownField { get; set; }
      /// <summary>
      /// List of players. It always contains 16 records
      /// </summary>
      public IReadOnlyList<PlayerData> Players { get; } = Enumerable.Range(0, 16).Select(_ => new PlayerData()).ToArray();
      /// <summary>
      /// Most likely a boolean
      /// </summary>
      public short UnknownField2 { get; set; }
      public IList<MarkerData> Markers { get; set; } = new List<MarkerData>();

      public IList<string> Objects { get; set; } = new List<string>();
   }
}
