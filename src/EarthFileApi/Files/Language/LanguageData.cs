using System.Collections.Generic;

namespace Ieo.EarthFileApi.Files.Language
{
   public class LanguageData : IEarthData
   {
      public LanguageType Type { get; set; }
      public Dictionary<string, string> Entries { get; set; }
   }
}
