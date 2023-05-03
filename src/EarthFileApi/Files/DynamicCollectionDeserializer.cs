using System.Collections.Generic;

namespace Ieo.EarthFileApi.Files
{
   internal class DynamicCollectionDeserializer<T> : EarthDataDeserializer<DynamicCollection<T>> where T: IEarthData
   {
      private readonly EarthDataDeserializer<T> _deserializer;
      public DynamicCollectionDeserializer(EarthDataDeserializer<T> deserializer) => _deserializer = deserializer;

      internal override DynamicCollection<T> Deserialize(byte[] bytes, ref int startingOffset)
      {
         var result = new DynamicCollection<T>();
         int length = ReadInt(bytes, ref startingOffset);
         result.Field_0x10 = ReadInt(bytes, ref startingOffset);
         result.Items = new List<T>(length);
         for (int i = 0; i < length; i++)
         {
            result.Items.Add(_deserializer.Deserialize(bytes, ref startingOffset));
         }
         return result;
      }
   }
}
