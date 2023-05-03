using System.Collections.Generic;

namespace Ieo.EarthFileApi.Files
{
   internal class StringCollectionDeserializer : EarthDataDeserializer<DynamicCollection<string>>
   {
      internal override DynamicCollection<string> Deserialize(byte[] bytes, ref int startingOffset)
      {
         var result = new DynamicCollection<string>();
         int length = ReadInt(bytes, ref startingOffset);
         result.Field_0x10 = ReadInt(bytes, ref startingOffset);
         result.Items = new List<string>(length);
         for (int i = 0; i < length; i++)
         {
            result.Items.Add(ReadString(bytes, ref startingOffset));
         }
         return result;
      }
   }
}
