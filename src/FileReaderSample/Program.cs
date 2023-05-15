using Ieo.EarthFileApi.Files;
using Ieo.EarthFileApi.Files.Profiles;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FileReaderSample
{
   class Program
   {
      static void Main(string[] args)
      {
         if(args.Length != 1)
         {
            Console.WriteLine("Please provide a single argument with path to a file.");
            return;
         }
         var filePath = args.Single();
         if(!File.Exists(filePath))
         {
            Console.WriteLine("File does not exist.");
            return;
         }

         JsonSerializerOptions options = new JsonSerializerOptions
         {
            Converters = { new JsonStringEnumConverter() }
         };

         if(filePath.EndsWith(".dat"))
         {
            var profileFile = EarthFileReader.ReadProfileFile(filePath);
            File.WriteAllText($"{filePath}.json", JsonSerializer.Serialize(profileFile, options));
         }
         else if (filePath.EndsWith(".lnd"))
         {
            var lndFile = EarthFileReader.ReadLndFile(filePath);
            File.WriteAllText($"{filePath}.json", JsonSerializer.Serialize(lndFile, options));
         }
         else if (filePath.EndsWith(".mis"))
         {
            var misFile = EarthFileReader.ReadMisFile(filePath);
            File.WriteAllText($"{filePath}.json", JsonSerializer.Serialize(misFile, options));
         }
         else if (filePath.EndsWith(".dat.json"))
         {
            var profileFile = JsonSerializer.Deserialize<ProfileData>(File.ReadAllText(filePath), options);
            File.WriteAllBytes($"{filePath}.dat", EarthFileWriter.WriteFile(profileFile));
         }
         else
         {
            Console.WriteLine("Unsupported file extension.");
         }
      }
   }
}