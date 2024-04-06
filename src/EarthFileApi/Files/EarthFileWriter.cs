using Elskom.Generic.Libs;
using Ieo.EarthFileApi.Files.Language;
using Ieo.EarthFileApi.Files.Levels;
using Ieo.EarthFileApi.Files.Profiles;
using System.IO;
using System.Linq;

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
      public static byte[] WriteFile(ProfileData data)
      {
         MemoryZlib.Compress(WriteProfileData(data), out var dataBytes, out _);

         return dataBytes;
      }
      public static byte[] WriteFile(LanguageData data)
      {
         using var stream = new MemoryStream();
         new EarthLanguageSerializer().Serialize(stream, data);
         return stream.ToArray();
      }

      internal static byte[] WriteHeader(EarthHeader header)
      {
         using var stream = new MemoryStream();
         new EarthHeaderSerializer().Serialize(stream, header);
         return stream.ToArray();
      }
      internal static byte[] WriteLndData(EarthLndData data)
      {
         using var stream = new MemoryStream();
         new EarthLndDataSerializer().Serialize(stream, data);
         return stream.ToArray();
      }
      internal static byte[] WriteMisData(EarthMisData data)
      {
         using var stream = new MemoryStream();
         new EarthMisDataSerializer().Serialize(stream, data);
         return stream.ToArray();
      }
      internal static byte[] WriteProfileData(ProfileData data)
      {
         using var stream = new MemoryStream();
         new EarthProfileSerializer().Serialize(stream, data);
         return stream.ToArray();
      }
   }
}
