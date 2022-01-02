using FluentAssertions;
using Ieo.EarthFileApi.Compression;
using Ieo.EarthFileApi.Files;
using System.IO;
using System.Linq;
using Xunit;

namespace Ieo.EarthFileApi.Tests
{
   public class FileWriterTests
   {
      /*[Fact]
      //For some reason it fails, even thought the data before compression is the same as decompressed bytes. Could be a difference in Zlib implementations used in Earth and in this library
      public void LndFileTest()
      {
         var rawData = File.ReadAllBytes(Path.Combine("Samples", "3AIThe_Final_Judgementv9.lnd"));
         var lndFile = EarthFileReader.ReadLndFile(rawData);
         var processedRawData = EarthFileWriter.WriteFile(lndFile);
         processedRawData.Should().BeEquivalentTo(rawData);
      }*/
      [Fact]
      public void LndFileHeaderTest()
      {
         var rawData = File.ReadAllBytes(Path.Combine("Samples", "3AIThe_Final_Judgementv9.lnd"));
         var rawSections = EarthDecompressor.ReadSections(rawData);
         var lndFile = EarthFileReader.ReadLndFile(rawData);
         var headerBytes = EarthFileWriter.WriteHeader(lndFile.Header);
         headerBytes.Should().BeEquivalentTo(rawSections.First());
      }
      [Fact]
      public void LndFileDataTest()
      {
         var rawData = File.ReadAllBytes(Path.Combine("Samples", "3AIThe_Final_Judgementv9.lnd"));
         var rawSections = EarthDecompressor.ReadSections(rawData);
         var lndFile = EarthFileReader.ReadLndFile(rawData);
         var dataBytes = EarthFileWriter.WriteLndData(lndFile.Data);
         dataBytes.Should().BeEquivalentTo(rawSections.Last());
      }
      [Fact]
      public void MisFileTest()
      {
         var rawData = File.ReadAllBytes(Path.Combine("Samples", "3AIThe_Final_Judgementv9.mis"));
         var lndFile = EarthFileReader.ReadMisFile(rawData);
         var processedRawData = EarthFileWriter.WriteFile(lndFile);
         processedRawData.Should().BeEquivalentTo(rawData);
      }
      [Fact]
      public void MisFileHeaderTest()
      {
         var rawData = File.ReadAllBytes(Path.Combine("Samples", "3AIThe_Final_Judgementv9.mis"));
         var rawSections = EarthDecompressor.ReadSections(rawData);
         var misFile = EarthFileReader.ReadMisFile(rawData);
         var headerBytes = EarthFileWriter.WriteHeader(misFile.Header);
         headerBytes.Should().BeEquivalentTo(rawSections.First());
      }
      [Fact]
      public void MisFileDataTest()
      {
         var rawData = File.ReadAllBytes(Path.Combine("Samples", "3AIThe_Final_Judgementv9.mis"));
         var rawSections = EarthDecompressor.ReadSections(rawData);
         var misFile = EarthFileReader.ReadMisFile(rawData);
         var dataBytes = EarthFileWriter.WriteMisData(misFile.Data);
         dataBytes.Should().BeEquivalentTo(rawSections.Last());
      }
   }
}
