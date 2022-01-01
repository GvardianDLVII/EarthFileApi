using System.Linq;

namespace Ieo.EarthFileApi.Files
{
   internal class EarthMisFileFactory : EarthFileFactory<EarthMisData>
   {
      protected override FileType Type => FileType.Mis;

      protected override EarthMisData CreateData(byte[] bytes)
      {
         var data = new EarthMisData();
         int offset = 0;
         data.UnknownOptionalString = ReadString(bytes, ReadInt(bytes, ref offset), ref offset);
         data.LndFileId = ReadGuid(bytes, ref offset);
         var shipsLavaFlags = ReadByte(bytes, ref offset);
         data.ShipsEnabled = (shipsLavaFlags & 1) != 0;
         data.WaterType = (shipsLavaFlags & 2) != 0 ? WaterType.Lava : WaterType.Water;
         data.TotalResources = ReadInt(bytes, ref offset);
         data.LevelWidth = ReadShort(bytes, ref offset);
         data.LevelHeight = ReadShort(bytes, ref offset);
         data.UnknownField = ReadInt(bytes, ref offset);
         for(int i = 0; i < 16; i++)
         {
            var player = ReadPlayer(bytes, ref offset);
            data.Players[i].UnknownField = player.UnknownField;
            data.Players[i].StartPositionX = player.StartPositionX;
            data.Players[i].StartPositionY = player.StartPositionY;
         }
         data.UnknownField2 = ReadShort(bytes, ref offset);
         var markersCount = ReadShort(bytes, ref offset);
         for(int i = 0; i < markersCount; i++)
         {
            data.Markers.Add(ReadMarker(bytes, ref offset));
         }
         while (offset < bytes.Length)
         {
            var @object = ReadObject(bytes, ref offset);
            if (@object is null) continue;
            data.Objects.Add(@object);
         }
         return data;
      }

      private static PlayerData ReadPlayer(byte[] bytes, ref int offset)
      {
         return new PlayerData
         {
            UnknownField = ReadInt(bytes, ref offset),
            StartPositionX = ReadByte(bytes, ref offset),
            StartPositionY = ReadByte(bytes, ref offset)
         };
      }

      private static string ReadObject(byte[] bytes, ref int offset)
      {
         var length = ReadInt(bytes, ref offset);
         if (length == 0) return null;
         return ReadString(bytes, length, ref offset);
      }

      private static MarkerData ReadMarker(byte[] bytes, ref int offset)
      {
         return new MarkerData
         {
            Number = ReadInt(bytes, ref offset),
            X = ReadShort(bytes, ref offset),
            Y = ReadShort(bytes, ref offset)
         };
      }
   }
}
