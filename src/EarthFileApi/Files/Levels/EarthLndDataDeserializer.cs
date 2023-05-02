using System.Linq;

namespace Ieo.EarthFileApi.Files.Levels
{
    internal class EarthLndDataDeserializer : EarthDataDeserializer<EarthLndData>
    {
        internal override EarthLndData Deserialize(byte[] bytes, ref int startingOffset)
        {
            var data = new EarthLndData();
            var offset = startingOffset;
            data.MapWidth = ReadInt(bytes, ref offset);
            data.MapHeight = ReadInt(bytes, ref offset);
            data.UnknownField = ReadInt(bytes, ref offset);
            data.LevelName = ReadString(bytes, ref offset);
            for (int i = 0; i < 15; i++)
            {
                data.LevelInfo[i] = ReadByte(bytes, ref offset);
            }
            data.TerrainType = (TerrainType)ReadByte(bytes, ref offset);
            var allSquares = Enumerable.Range(0, data.MapWidth * data.MapHeight);
            data.TerrainHeight = allSquares.Select(_ => ReadShort(bytes, ref offset)).ToArray();
            data.Tunnels = allSquares.Select(_ => ReadByte(bytes, ref offset)).ToArray();
            data.TerrainTextures = allSquares.Select(_ => ReadByte(bytes, ref offset)).ToArray();
            data.Resources = allSquares.Select(_ => ReadByte(bytes, ref offset)).ToArray();
            data.LevelWaterHeight = ReadInt(bytes, ref offset);
            data.WaterHeight = allSquares.Select(_ => ReadShort(bytes, ref offset)).ToArray();
            startingOffset = offset;
            return data;
        }
    }
}
