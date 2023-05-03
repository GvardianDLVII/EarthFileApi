using System.IO;

namespace Ieo.EarthFileApi.Files.Profiles
{
   internal class EarthTemplateSerializer : EarthDataSerializer<TemplateData>
   {
      internal override void Serialize(MemoryStream stream, TemplateData value)
      {
         WriteInt(stream, value.Field_0x4);
         WriteString(stream, value.ChassisName);
         WriteInt(stream, value.Field_0xc);
         WriteInt(stream, value.Field_0x10);
         WriteInt(stream, value.Field_0x14);
         WriteInt(stream, value.PowerShieldType);
         WriteGuid(stream, value.ScriptId);
         for (int i = 0; i < 8; i++)
            WriteString(stream, value.Slots[i]);
         WriteStringW(stream, value.TemplateName);

      }
   }
}
