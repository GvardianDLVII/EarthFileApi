namespace Ieo.EarthFileApi.Files.Levels
{
    internal class EarthObjectDataDeserializer : EarthDataDeserializer<ObjectData>
    {
        internal override ObjectData Deserialize(byte[] bytes, ref int startingOffset) => new ObjectData
        {
            String = ReadString(bytes, ref startingOffset)
        };
    }
}
