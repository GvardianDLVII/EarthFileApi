using System.IO;

namespace Ieo.EarthFileApi.Files
{
   internal class EarthHeaderSerializer : EarthDataSerializer<EarthHeader>
   {
      internal override void Serialize(MemoryStream stream, EarthHeader value)
      {
         WriteInt(stream, value.Header);
         WriteShortString(stream, value.FileName);
         WriteInt(stream, value.UnknownOptionalField);
         WriteGuid(stream, value.FileId);
      }
   }
}
