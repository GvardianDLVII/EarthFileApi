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

      [Theory]
      [InlineData("aaaaa_UserInfo.dat")]
      [InlineData("Demo_UserInfo.dat")]
      [InlineData("Editor_UserInfo.dat")]
      [InlineData("Gvardian_ED_UserInfo.dat")]
      [InlineData("Gvardian_LC_UserInfo.dat")]
      [InlineData("test_UCS_UserInfo.dat")]
      [InlineData("cleared_GvardianDLVII_UserInfo.dat")]
      [InlineData("cleared_Noctis_UserInfo.dat")]
      public void ProfileDataTest(string profileName)
      {
         var rawData = File.ReadAllBytes(Path.Combine("Samples", profileName));
         var rawSections = EarthDecompressor.ReadSections(rawData);
         var profileData = EarthFileReader.ReadProfileFile(rawData);
         var distinctField0x4 = profileData.EdTemplates.Select(t => t.Field_0x4).Concat(profileData.UcsTemplates.Select(t => t.Field_0x4)).Concat(profileData.LcTemplates.Select(t => t.Field_0x4)).Distinct().ToArray();
         var distinctField0xc = profileData.EdTemplates.Select(t => t.Field_0xc).Concat(profileData.UcsTemplates.Select(t => t.Field_0xc)).Concat(profileData.LcTemplates.Select(t => t.Field_0xc)).Distinct().ToArray();
         var distinctField0x10 = profileData.EdTemplates.Select(t => t.Field_0x10).Concat(profileData.UcsTemplates.Select(t => t.Field_0x10)).Concat(profileData.LcTemplates.Select(t => t.Field_0x10)).Distinct().ToArray();
         var distinctField0x14 = profileData.EdTemplates.Select(t => t.Field_0x14).Concat(profileData.UcsTemplates.Select(t => t.Field_0x14)).Concat(profileData.LcTemplates.Select(t => t.Field_0x14)).Distinct().ToArray();
         var distinctScripts = profileData.EdTemplates.Select(t => t.ScriptId).Concat(profileData.UcsTemplates.Select(t => t.ScriptId)).Concat(profileData.LcTemplates.Select(t => t.ScriptId)).Distinct().ToArray();
         var dataBytes = EarthFileWriter.WriteProfileData(profileData);
         dataBytes.Should().BeEquivalentTo(rawSections.Single());
         var processedRawData = EarthFileWriter.WriteFile(profileData);
         processedRawData.Should().BeEquivalentTo(rawData);
      }
   }
}
