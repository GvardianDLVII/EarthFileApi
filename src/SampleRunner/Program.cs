using CommandLine;
using Ieo.EarthFileApi.Files;
using LevelMinimapGenerator;
using System;
using System.IO;
using System.Linq;

namespace SampleRunner
{
   class Program
   {
      static int Main(string[] args)
      {
         return Parser.Default.ParseArguments<CommandLineOptions>(args)
            .MapResult((CommandLineOptions o) =>
            {
               try
               {
                  switch (o.Mode)
                  {
                     case "single":
                        CreateMinimapFile(o.Lnd, o.Mis, o.OutputPath, o.Scale, !o.HideStartingPositions);
                        break;
                     case "multiple":
                        CreateMultipleMinimapFiles(o.InputPath, o.OutputPath, o.Scale, !o.HideStartingPositions);
                        break;
                     default:
                        Console.WriteLine($"Invalid mode value {o.Mode}");
                        return -1;
                  }
                  return 0;
               }
               catch (Exception e)
               {
                  Console.WriteLine("Unhandled error:");
                  Console.WriteLine(e.ToString());
                  return -1;
               }
            },
            e =>
            {
               return -2;
            });
		}

      private static void CreateMultipleMinimapFiles(string inputPath, string outputPath, int scale, bool markStartingPositions)
      {
         if (string.IsNullOrEmpty(inputPath))
         {
            throw new ArgumentException("--inputPath option is required in multiple mode.");
         }
         var lndFiles = Directory.GetFiles(inputPath, "*.lnd");
         var misFiles = Directory.GetFiles(inputPath, "*.mis");
         foreach (var mis in misFiles)
         {
            var lnd = lndFiles.FirstOrDefault(l => Path.GetFileNameWithoutExtension(mis) == Path.GetFileNameWithoutExtension(l));
            if (lnd is null)
            {
               continue;
            }
            try
            {
               CreateMinimapFile(lnd, mis, Path.Combine(outputPath, Path.GetFileNameWithoutExtension(mis) + ".png"), scale, markStartingPositions);
            }
            catch (Exception e)
            {
               Console.WriteLine($" Error while parsing {Path.GetFileNameWithoutExtension(mis)} level: {e}");
            }
         }
      }

      private static void CreateMinimapFile(string lndFilePath, string misFilePath, string outputPath, int scale, bool markStartingPositions)
      {
         if(string.IsNullOrEmpty(lndFilePath))
         {
            throw new ArgumentException("--lnd option is required in single mode.");
         }
         if (string.IsNullOrEmpty(misFilePath))
         {
            throw new ArgumentException("--mis option is required in single mode.");
         }
         var lndFile = EarthFileReader.ReadLndFile(lndFilePath);
         var misFile = EarthFileReader.ReadMisFile(misFilePath);
         MinimapGenerator.Generate(lndFile, misFile, new MinimapOptions
         {
            Scale = scale,
            MarkStartingPositions = markStartingPositions
         }).Save(outputPath);
      }
	}
}
