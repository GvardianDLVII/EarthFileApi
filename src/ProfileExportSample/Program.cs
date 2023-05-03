using Ieo.EarthFileApi.Files;
using System.Text.Json;

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

         File.WriteAllText("UserInfo.json", JsonSerializer.Serialize(profileFile));
      }
   }
}