using Ieo.EarthFileApi.Files;
using System;
using System.IO;

namespace LevelSaveSample
{
   class Program
   {
      static void Main(string[] args)
      {
         var headerGuid = Guid.NewGuid();

         var lndFile = EarthFileReader.ReadLndFile(@"D:\SteamLibrary\steamapps\common\Earth 2150 The Moon Project\Levels\3AIThe_Final_Judgementv9.lnd");
         var misFile = EarthFileReader.ReadMisFile(@"D:\SteamLibrary\steamapps\common\Earth 2150 The Moon Project\Levels\3AIThe_Final_Judgementv9.mis");

         lndFile.Header.FileId = headerGuid;
         lndFile.Header.FileName = "ApiSaveTest";
         lndFile.Data.LevelName = "ApiSaveTestName";

         misFile.Header.FileId = Guid.NewGuid();
         misFile.Header.FileName = "ApiSaveTest";
         misFile.Data.LndFileId = headerGuid;

         File.WriteAllBytes(@"D:\SteamLibrary\steamapps\common\Earth 2150 The Moon Project\Levels\AutoMap.lnd", EarthFileWriter.WriteFile(lndFile));
         File.WriteAllBytes(@"D:\SteamLibrary\steamapps\common\Earth 2150 The Moon Project\Levels\AutoMap.mis", EarthFileWriter.WriteFile(misFile));
      }
   }
}
