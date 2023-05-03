using System.IO;

namespace Ieo.EarthFileApi.Files.Levels
{
    internal class PlayerDataSerializer : EarthDataSerializer<PlayerData>
    {
        internal override void Serialize(MemoryStream stream, PlayerData value)
        {
            WriteInt(stream, value.UnknownField);
            WriteByte(stream, value.StartPositionX);
            WriteByte(stream, value.StartPositionY);
        }
    }
}
