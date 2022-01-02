using Elskom.Generic.Libs;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Ieo.EarthFileApi.Files
{
   public static class EarthFileWriter
   {
      public static byte[] WriteFile(EarthFile<EarthLndData> data)
      {
         MemoryZlib.Compress(WriteHeader(data.Header), out var headerBytes, out _);
         MemoryZlib.Compress(WriteLndData(data.Data), out var dataBytes, out _);

         return headerBytes.Concat(dataBytes).ToArray();
      }
      public static byte[] WriteFile(EarthFile<EarthMisData> data)
      {
         MemoryZlib.Compress(WriteHeader(data.Header), out var headerBytes, out _);
         MemoryZlib.Compress(WriteMisData(data.Data), out var dataBytes, out _);

         return headerBytes.Concat(dataBytes).ToArray();
      }
      internal static byte[] WriteHeader(EarthHeader header)
      {
         using (var stream = new MemoryStream())
         {
            stream.Write(BitConverter.GetBytes(header.Header));
            stream.Write(new[] { (byte)header.FileName.Length });
            stream.Write(Encoding.UTF8.GetBytes(header.FileName));
            stream.Write(BitConverter.GetBytes(header.UnknownOptionalField));
            stream.Write(header.FileId.ToByteArray());
            return stream.ToArray();
         }
      }
      internal static byte[] WriteLndData(EarthLndData data)
      {
         using (var stream = new MemoryStream())
         {
            stream.Write(BitConverter.GetBytes(data.MapWidth));
            stream.Write(BitConverter.GetBytes(data.MapHeight));
            stream.Write(BitConverter.GetBytes(data.UnknownField));
            stream.Write(BitConverter.GetBytes(data.LevelName.Length));
            stream.Write(Encoding.UTF8.GetBytes(data.LevelName));
            stream.Write(data.LevelInfo);
            stream.Write(new[] { (byte)data.TerrainType });
            stream.Write(data.TerrainHeight.SelectMany(s => BitConverter.GetBytes(s)).ToArray());
            stream.Write(data.Tunnels);
            stream.Write(data.TerrainTextures);
            stream.Write(data.Resources);
            stream.Write(BitConverter.GetBytes(data.LevelWaterHeight));
            stream.Write(data.WaterHeight.SelectMany(s => BitConverter.GetBytes(s)).ToArray());
            return stream.ToArray();
         }
      }
      internal static byte[] WriteMisData(EarthMisData data)
      {
         using (var stream = new MemoryStream())
         {
           stream.Write(BitConverter.GetBytes(data.UnknownOptionalString.Length));
           stream.Write(Encoding.UTF8.GetBytes(data.UnknownOptionalString));
           stream.Write(data.LndFileId.ToByteArray());
           stream.Write(new[] { (byte)((data.WaterType == WaterType.Lava ? 2 : 0) + (data.ShipsEnabled ? 1 : 0)) });
           stream.Write(BitConverter.GetBytes(data.TotalResources));
           stream.Write(BitConverter.GetBytes(data.LevelWidth));
           stream.Write(BitConverter.GetBytes(data.LevelHeight));
            stream.Write(BitConverter.GetBytes(data.UnknownField));
            for (int i = 0; i < 16; i++)
            {
               stream.Write(BitConverter.GetBytes(data.Players[i].UnknownField));
               stream.Write(new[] { data.Players[i].StartPositionX });
               stream.Write(new[] { data.Players[i].StartPositionY });
            }
            stream.Write(BitConverter.GetBytes(data.UnknownField2));
            stream.Write(BitConverter.GetBytes((short)data.Markers.Count));
            foreach (var marker in data.Markers)
            {
               stream.Write(BitConverter.GetBytes(marker.Number));
               stream.Write(BitConverter.GetBytes(marker.X));
               stream.Write(BitConverter.GetBytes(marker.Y));
            }
            foreach (var obj in data.Objects)
            {
               stream.Write(BitConverter.GetBytes(obj.Length));
               stream.Write(Encoding.UTF8.GetBytes(obj));
            }
            stream.Write(BitConverter.GetBytes(0));
            return stream.ToArray();
         }
      }
   }
}
