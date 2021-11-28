using System.Linq;

namespace Ieo.EarthFileApi.Files
{
   internal class EarthLndFileFactory : EarthFileFactory<EarthLndData>
   {
      protected override FileType Type => FileType.Lnd;

      protected override EarthLndData CreateData(byte[] bytes)
      {
         var data = new EarthLndData();
         int offset = 0;
         data.MapWidth = ReadInt(bytes, ref offset);
         data.MapHeight = ReadInt(bytes, ref offset);
         data.UnknownField = ReadInt(bytes, ref offset);
         data.LevelName = ReadString(bytes, ReadInt(bytes, ref offset), ref offset);
         data.LevelInfo = ReadString(bytes, 16, ref offset);
         var allSquares = Enumerable.Range(0, data.MapWidth * data.MapHeight);
         data.TerrainHeight = allSquares.Select(_ => ReadShort(bytes, ref offset)).ToArray();
         data.Tunnels = allSquares.Select(_ => ReadByte(bytes, ref offset)).ToArray();
         data.TerrainTextures = allSquares.Select(_ => ReadByte(bytes, ref offset)).ToArray();
         data.Resources = allSquares.Select(_ => ReadByte(bytes, ref offset)).ToArray();
         data.LevelWaterHeight = ReadInt(bytes, ref offset);
         data.WaterHeight = allSquares.Select(_ => ReadShort(bytes, ref offset)).ToArray();
         return data;
      }
   }
}
