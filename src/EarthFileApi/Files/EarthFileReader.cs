using Ieo.EarthFileApi.Compression;
using Ieo.EarthFileApi.Files.Levels;
using Ieo.EarthFileApi.Files.Profiles;
using Ieo.EarthFileApi.Files.Scripts;
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
      public static ProfileData ReadProfileFile(byte[] data)
      {
         if (data == null)
            throw new ArgumentNullException(nameof(data));
         var sections = EarthDecompressor.ReadSections(data).ToArray();
         if (sections.Length != 1)
            throw new InvalidOperationException("Profile files should contain 1 zlib compressed section.");
         return new EarthProfileDeserializer().Deserialize(sections.Single());
      }
      public static ProfileData ReadProfileFile(string filePath)
      {
         return ReadProfileFile(File.ReadAllBytes(filePath));
      }
      public static EarthFile<EarthEcoMpData> ReadEcoMpFile(byte[] data)
      {
         if (data == null)
            throw new ArgumentNullException(nameof(data));
         var sections = EarthDecompressor.ReadSections(data).ToArray();
         if (sections.Length != 2)
            throw new InvalidOperationException("ecoMP files should contain 2 zlib compressed sections.");
         return new EarthEcoMpFileFactory().Create(sections[0], sections[1]);
      }
      public static EarthFile<EarthEcoMpData> ReadEcoMpFile(string filePath)
      {
         return ReadEcoMpFile(File.ReadAllBytes(filePath));
      }
   }
}
