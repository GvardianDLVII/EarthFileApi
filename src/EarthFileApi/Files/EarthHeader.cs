using System;

namespace Ieo.EarthFileApi.Files
{
   public class EarthHeader
   {
      public int Header { get; set; }
      public string FileName { get; set; }
      public int UnknownOptionalField { get; set; }
      public Guid FileId { get; set; }
   }
}
