using System.IO;

namespace Ieo.EarthFileApi.Files.Levels
{
    internal class EarthLndDataSerializer : EarthDataSerializer<EarthLndData>
    {
        internal override void Serialize(MemoryStream stream, EarthLndData value)
        {
            WriteInt(stream, value.MapWidth);
            WriteInt(stream, value.MapHeight);
            WriteInt(stream, value.UnknownField);
            WriteString(stream, value.LevelName);
            WriteBytes(stream, value.LevelInfo);
            WriteByte(stream, (byte)value.TerrainType);
            foreach (var item in value.TerrainHeight) { WriteShort(stream, item); }
            WriteBytes(stream, value.Tunnels);
            WriteBytes(stream, value.TerrainTextures);
            WriteBytes(stream, value.Resources);
            WriteInt(stream, value.LevelWaterHeight);
            foreach (var item in value.WaterHeight) { WriteShort(stream, item); }
        }
    }
}
