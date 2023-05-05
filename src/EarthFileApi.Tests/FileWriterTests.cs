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

      [Theory]
      [InlineData("( 2) 1v1 Box v4 [Ani].lnd")]
      [InlineData("( 2) Battle Box v3 [Ani].lnd")]
      [InlineData("( 2) Budokai v2 [Ani].lnd")]
      [InlineData("( 6) Hot Valley v9 [Ani].lnd")]
      [InlineData("( 6) In The End v2 - S [Ani].lnd")]
      [InlineData("[AI] - [TD] Map v2.0.lnd")]
      [InlineData("[AI] - Mortal Hill - 3 Players [MC].lnd")]
      [InlineData("[AI] - Ultimate Bot Challenge - 3 Players v2.4 [MC].lnd")]
      [InlineData("2_1v1_Naval_Box_v5_Konie.lnd")]
      [InlineData("3AIThe_Final_Judgementv9.lnd")]
      [InlineData("Arena_20230315183952.lnd")]
      public void LndFileHeaderTest(string lndFileName)
      {
         var rawData = File.ReadAllBytes(Path.Combine("Samples/Lnd", lndFileName));
         var rawSections = EarthDecompressor.ReadSections(rawData);
         var lndFile = EarthFileReader.ReadLndFile(rawData);
         var headerBytes = EarthFileWriter.WriteHeader(lndFile.Header);
         headerBytes.Should().BeEquivalentTo(rawSections.First());
      }

      [Theory]
      [InlineData("( 2) 1v1 Box v4 [Ani].lnd")]
      [InlineData("( 2) Battle Box v3 [Ani].lnd")]
      [InlineData("( 2) Budokai v2 [Ani].lnd")]
      [InlineData("( 6) Hot Valley v9 [Ani].lnd")]
      [InlineData("( 6) In The End v2 - S [Ani].lnd")]
      [InlineData("[AI] - [TD] Map v2.0.lnd")]
      [InlineData("[AI] - Mortal Hill - 3 Players [MC].lnd")]
      [InlineData("[AI] - Ultimate Bot Challenge - 3 Players v2.4 [MC].lnd")]
      [InlineData("2_1v1_Naval_Box_v5_Konie.lnd")]
      [InlineData("3AIThe_Final_Judgementv9.lnd")]
      [InlineData("Arena_20230315183952.lnd")]
      public void LndFileDataTest(string lndFileName)
      {
         var rawData = File.ReadAllBytes(Path.Combine("Samples/Lnd", lndFileName));
         var rawSections = EarthDecompressor.ReadSections(rawData);
         var lndFile = EarthFileReader.ReadLndFile(rawData);
         var dataBytes = EarthFileWriter.WriteLndData(lndFile.Data);
         dataBytes.Should().BeEquivalentTo(rawSections.Last());
      }

      [Theory]
      [InlineData("( 2) 1v1 Box v4 [Ani].mis")]
      [InlineData("( 2) Battle Box v3 [Ani].mis")]
      [InlineData("( 2) Budokai v2 [Ani].mis")]
      [InlineData("( 6) Hot Valley v9 [Ani].mis")]
      [InlineData("( 6) In The End v2 - S [Ani].mis")]
      [InlineData("[AI] - [TD] Map v2.0.mis")]
      [InlineData("[AI] - Mortal Hill - 3 Players [MC].mis")]
      [InlineData("[AI] - Ultimate Bot Challenge - 3 Players v2.4 [MC].mis")]
      [InlineData("2_1v1_Naval_Box_v5_Konie.mis")]
      [InlineData("3AIThe_Final_Judgementv9.mis")]
      [InlineData("Arena_20230315183952.mis")]
      public void MisFileTest(string misFileName)
      {
         var rawData = File.ReadAllBytes(Path.Combine("Samples/Mis", misFileName));
         var lndFile = EarthFileReader.ReadMisFile(rawData);
         var processedRawData = EarthFileWriter.WriteFile(lndFile);
         processedRawData.Should().BeEquivalentTo(rawData);
      }


      [Theory]
      [InlineData("( 2) 1v1 Box v4 [Ani].mis")]
      [InlineData("( 2) Battle Box v3 [Ani].mis")]
      [InlineData("( 2) Budokai v2 [Ani].mis")]
      [InlineData("( 6) Hot Valley v9 [Ani].mis")]
      [InlineData("( 6) In The End v2 - S [Ani].mis")]
      [InlineData("[AI] - [TD] Map v2.0.mis")]
      [InlineData("[AI] - Mortal Hill - 3 Players [MC].mis")]
      [InlineData("[AI] - Ultimate Bot Challenge - 3 Players v2.4 [MC].mis")]
      [InlineData("2_1v1_Naval_Box_v5_Konie.mis")]
      [InlineData("3AIThe_Final_Judgementv9.mis")]
      [InlineData("Arena_20230315183952.mis")]
      public void MisFileHeaderTest(string misFileName)
      {
         var rawData = File.ReadAllBytes(Path.Combine("Samples/Mis", misFileName));
         var rawSections = EarthDecompressor.ReadSections(rawData);
         var misFile = EarthFileReader.ReadMisFile(rawData);
         var headerBytes = EarthFileWriter.WriteHeader(misFile.Header);
         headerBytes.Should().BeEquivalentTo(rawSections.First());
      }

      [Theory]
      [InlineData("( 2) 1v1 Box v4 [Ani].mis")]
      [InlineData("( 2) Battle Box v3 [Ani].mis")]
      [InlineData("( 2) Budokai v2 [Ani].mis")]
      [InlineData("( 6) Hot Valley v9 [Ani].mis")]
      [InlineData("( 6) In The End v2 - S [Ani].mis")]
      [InlineData("[AI] - [TD] Map v2.0.mis")]
      [InlineData("[AI] - Mortal Hill - 3 Players [MC].mis")]
      [InlineData("[AI] - Ultimate Bot Challenge - 3 Players v2.4 [MC].mis")]
      [InlineData("2_1v1_Naval_Box_v5_Konie.mis")]
      [InlineData("3AIThe_Final_Judgementv9.mis")]
      [InlineData("Arena_20230315183952.mis")]
      public void MisFileDataTest(string misFileName)
      {
         var rawData = File.ReadAllBytes(Path.Combine("Samples/Mis", misFileName));
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
      public void ProfileDataTest(string profileName)
      {
         var rawData = File.ReadAllBytes(Path.Combine("Samples/Profiles", profileName));
         var rawSections = EarthDecompressor.ReadSections(rawData);
         var profileData = EarthFileReader.ReadProfileFile(rawData);
         var dataBytes = EarthFileWriter.WriteProfileData(profileData);
         dataBytes.Should().BeEquivalentTo(rawSections.Single());
         var processedRawData = EarthFileWriter.WriteFile(profileData);
         processedRawData.Should().BeEquivalentTo(rawData);
      }
   }
}
