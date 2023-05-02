namespace Ieo.EarthFileApi.Files.Levels
{
    internal class EarthLndFileFactory : EarthFileFactory<EarthLndData>
    {
        private readonly EarthDataDeserializer<EarthLndData> _deserializer;

        internal EarthLndFileFactory() : base() => _deserializer = new EarthLndDataDeserializer();

        protected override FileType Type => FileType.Lnd;

        protected override EarthLndData CreateData(byte[] bytes) => _deserializer.Deserialize(bytes);
    }
}
