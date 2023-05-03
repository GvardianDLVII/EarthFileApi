using System.IO;

namespace Ieo.EarthFileApi.Files
{
   internal class DynamicCollectionSerializer<T> : EarthDataSerializer<DynamicCollection<T>> where T: IEarthData
   {
      private readonly EarthDataSerializer<T> _serializer;
      public DynamicCollectionSerializer(EarthDataSerializer<T> serializer)
      {
         _serializer = serializer;
      }

      internal override void Serialize(MemoryStream stream, DynamicCollection<T> value)
      {
         WriteInt(stream, value.Items.Count);
         WriteInt(stream, value.Field_0x10);
         foreach(var item in value.Items) { _serializer.Serialize(stream, item); }
      }
   }
}
