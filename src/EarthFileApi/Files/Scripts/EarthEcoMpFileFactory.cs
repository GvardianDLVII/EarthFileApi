namespace Ieo.EarthFileApi.Files.Scripts
{
   internal class EarthEcoMpFileFactory : EarthFileFactory<EarthEcoMpData>
   {
      private readonly EarthDataDeserializer<EarthEcoMpData> _deserializer;

      internal EarthEcoMpFileFactory() : base() => _deserializer = new EarthEcoMpDataDeserializer();

      protected override FileType Type => FileType.Eco;

      protected override EarthEcoMpData CreateData(byte[] bytes) => _deserializer.Deserialize(bytes);
   }
}
