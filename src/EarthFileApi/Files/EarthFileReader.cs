using Ieo.EarthFileApi.Compression;
using System;
using System.IO;
using System.Linq;

namespace Ieo.EarthFileApi.Files
{
   public static class EarthFileReader
   {
      public static EarthFile<EarthLndData> ReadLndFile(byte[] data)
      {
         if (data == null)
            throw new ArgumentNullException(nameof(data));
         var sections = EarthDecompressor.ReadSections(data).ToArray();
         if (sections.Length != 2)
            throw new InvalidOperationException("LND files should contain 2 zlib compressed sections.");
         return new EarthLndFileFactory().Create(sections[0], sections[1]);
      }
      public static EarthFile<EarthLndData> ReadLndFile(string filePath)
      {
         return ReadLndFile(File.ReadAllBytes(filePath));
      }
      public static EarthFile<EarthMisData> ReadMisFile(byte[] data)
      {
         if (data == null)
            throw new ArgumentNullException(nameof(data));
         var sections = EarthDecompressor.ReadSections(data).ToArray();
         if (sections.Length != 2)
            throw new InvalidOperationException("MIS files should contain 2 zlib compressed sections.");
         return new EarthMisFileFactory().Create(sections[0], sections[1]);
      }
      public static EarthFile<EarthMisData> ReadMisFile(string filePath)
      {
         return ReadMisFile(File.ReadAllBytes(filePath));
      }
   }
}
