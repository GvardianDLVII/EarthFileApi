using System;
using System.Linq;
using System.Text;

namespace Ieo.EarthFileApi.Files.Language
{
   internal class EarthLanguageDeserializer : EarthDataDeserializer<LanguageData>
   {
      internal override LanguageData Deserialize(byte[] bytes, ref int startingOffset)
      {
         var data = new LanguageData();
         var offset = startingOffset;
         int header = ReadInt(bytes, ref offset);
         if (header != 0x004e414c)
            throw new NotImplementedException();
         data.Type = (LanguageType)ReadInt(bytes, ref offset);
         int numberOfItems = ReadInt(bytes, ref offset);
         data.Entries = Enumerable.Range(0, numberOfItems)
            .Select(_ => (ReadString(bytes, ref offset), data.Type == LanguageType.Unicode ? ReadStringW(bytes, ref offset) : ReadString(bytes, ref offset, Encoding.GetEncoding(1250))))
            .ToDictionary(x => x.Item1, x => x.Item2);

         return data;
      }
   }
}
