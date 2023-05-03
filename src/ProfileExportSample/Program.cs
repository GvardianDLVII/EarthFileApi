using Ieo.EarthFileApi.Files;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LevelSaveSample
{
   class Program
   {
      static void Main(string[] args)
      {
         if(args.Length != 1)
         {
            Console.WriteLine("Please provide a single argument with path to UserInfo.dat");
         }
         var profileFile = EarthFileReader.ReadProfileFile(args[0]);

         JsonSerializerOptions options = new JsonSerializerOptions
         {
            Converters = { new JsonStringEnumConverter() }
         };

         File.WriteAllText("UserInfo.json", JsonSerializer.Serialize(profileFile, options));
      }
   }
}