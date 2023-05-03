using System.IO;

namespace Ieo.EarthFileApi.Files
{
   internal class StringCollectionSerializer : EarthDataSerializer<DynamicCollection<string>>
   {
      internal override void Serialize(MemoryStream stream, DynamicCollection<string> value)
      {
         WriteInt(stream, value.Items.Count);
         WriteInt(stream, value.Field_0x10);
         foreach(var item in value.Items) { WriteString(stream, item); }
      }
   }
}
