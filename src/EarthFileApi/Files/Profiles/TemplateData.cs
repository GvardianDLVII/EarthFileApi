using System;

namespace Ieo.EarthFileApi.Files.Profiles
{
   public class TemplateData : IEarthData
   {
      public int Field_0x4 { get; set; }
      public string ChassisName { get; set; }
      public int Field_0xc { get; set; }
      public int Field_0x10 { get; set; }
      public int Field_0x14 { get; set; }
      public int PowerShieldType { get; set; }
      public Guid ScriptId { get; set; }
      public string[] Slots { get; set; } = new string[8];
      public string TemplateName { get; set; }
   }
}
