namespace Ieo.EarthFileApi.Files.Levels
{
    internal class EarthPlayerDataDeserializer : EarthDataDeserializer<PlayerData>
    {
        internal override PlayerData Deserialize(byte[] bytes, ref int startingOffset) => new PlayerData
        {
            UnknownField = ReadInt(bytes, ref startingOffset),
            StartPositionX = ReadByte(bytes, ref startingOffset),
            StartPositionY = ReadByte(bytes, ref startingOffset)
        };
    }
}
