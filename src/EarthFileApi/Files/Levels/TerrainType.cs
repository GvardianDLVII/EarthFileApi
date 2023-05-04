using System;

namespace Ieo.EarthFileApi.Files.Levels
{
   public enum TerrainType
    {
        Winter,
        EarlySpring,
        Spring,
        Summer,
        Desert,
        Volcanos,
        Lava,
        Moon
    }

   public static class TerrainTypeMapper
   {
      public static TerrainType FromGuid(Guid terrainGuid) => terrainGuid.ToString() switch
      {
         "eaeaeaea-2150-2150-0001-000000000000" => TerrainType.Winter,
         "eaeaeaea-2150-2150-0001-000000000001" => TerrainType.EarlySpring,
         "eaeaeaea-2150-2150-0001-000000000002" => TerrainType.Spring,
         "eaeaeaea-2150-2150-0001-000000000003" => TerrainType.Summer,
         "eaeaeaea-2150-2150-0001-000000000004" => TerrainType.Desert,
         "eaeaeaea-2150-2150-0001-000000000005" => TerrainType.Volcanos,
         "eaeaeaea-2150-2150-0001-000000000006" => TerrainType.Lava,
         "eaeaeaea-2150-2150-0001-000000000007" => TerrainType.Moon,
         _ => throw new ArgumentOutOfRangeException(nameof(terrainGuid)),
      };

      public static Guid ToGuid(TerrainType terrainType) => terrainType switch
      {
         TerrainType.Winter =>      Guid.Parse("EAEAEAEA-2150-2150-0001-000000000000"),
         TerrainType.EarlySpring => Guid.Parse("EAEAEAEA-2150-2150-0001-000000000001"),
         TerrainType.Spring =>      Guid.Parse("EAEAEAEA-2150-2150-0001-000000000002"),
         TerrainType.Summer =>      Guid.Parse("EAEAEAEA-2150-2150-0001-000000000003"),
         TerrainType.Desert =>      Guid.Parse("EAEAEAEA-2150-2150-0001-000000000004"),
         TerrainType.Volcanos =>    Guid.Parse("EAEAEAEA-2150-2150-0001-000000000005"),
         TerrainType.Lava =>        Guid.Parse("EAEAEAEA-2150-2150-0001-000000000006"),
         TerrainType.Moon =>        Guid.Parse("EAEAEAEA-2150-2150-0001-000000000007"),
         _ => throw new ArgumentOutOfRangeException(nameof(terrainType)),
      };
   }
}
