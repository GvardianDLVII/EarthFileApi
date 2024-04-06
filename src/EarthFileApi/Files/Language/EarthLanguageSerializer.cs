using System;
using System.IO;
using System.Text;

namespace Ieo.EarthFileApi.Files.Language
{
   internal class EarthLanguageSerializer : EarthDataSerializer<LanguageData>
   {
      internal override void Serialize(MemoryStream stream, LanguageData value)
      {
         WriteInt(stream, 0x004e414c);
         WriteInt(stream, (int)value.Type);
         WriteInt(stream, value.Entries.Count);
         foreach (var entry in value.Entries)
         {
            WriteString(stream, entry.Key);
            if (value.Type == LanguageType.Ascii)
               WriteString(stream, entry.Value, Encoding.GetEncoding(1250));
            else if (value.Type == LanguageType.Unicode)
               WriteStringW(stream, entry.Value);
            else
               throw new NotImplementedException();
         }
      }
   }
}
