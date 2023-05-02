namespace Ieo.EarthFileApi.Files.Levels
{
    internal class EarthMarkerDataDeserializer : EarthDataDeserializer<MarkerData>
    {
        internal override MarkerData Deserialize(byte[] bytes, ref int startingOffset) => new MarkerData
        {
            Number = ReadInt(bytes, ref startingOffset),
            X = ReadShort(bytes, ref startingOffset),
            Y = ReadShort(bytes, ref startingOffset)
        };
    }
}
