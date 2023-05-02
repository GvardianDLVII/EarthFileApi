namespace Ieo.EarthFileApi.Files.Levels
{
    internal class EarthMisFileFactory : EarthFileFactory<EarthMisData>
    {
        private readonly EarthDataDeserializer<EarthMisData> _deserializer;

        internal EarthMisFileFactory() : base() => _deserializer = new EarthMisDataDeserializer();

        protected override FileType Type => FileType.Mis;

        protected override EarthMisData CreateData(byte[] bytes) => _deserializer.Deserialize(bytes);
    }
}
