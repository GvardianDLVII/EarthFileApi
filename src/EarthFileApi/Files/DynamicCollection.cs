using System.Collections.Generic;

namespace Ieo.EarthFileApi.Files
{
   internal class DynamicCollection<T> : IEarthData
   {
      public int Field_0x10 { get; set; }
      public IList<T> Items { get; set; }
   }
}
