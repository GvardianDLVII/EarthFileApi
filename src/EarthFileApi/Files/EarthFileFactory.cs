namespace Ieo.EarthFileApi.Files
{
   internal abstract class EarthFileFactory<T> where T : IEarthData
   {
      private readonly EarthDataDeserializer<EarthHeader> _headerDeserializer;

      internal EarthFileFactory()
      {
         _headerDeserializer = new EarthHeaderDeserializer();
      }

      protected abstract FileType Type { get; }
      public EarthFile<T> Create(byte[] header, byte[] data)
      {
         return new EarthFile<T>
         {
            Type = Type,
            Header = CreateHeader(header),
            Data = CreateData(data)
         };
      }

      protected EarthHeader CreateHeader(byte[] bytes) => _headerDeserializer.Deserialize(bytes);

      protected abstract T CreateData(byte[] bytes);
   }
}
