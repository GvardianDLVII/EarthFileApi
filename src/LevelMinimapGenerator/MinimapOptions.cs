namespace LevelMinimapGenerator
{
   public class MinimapOptions
   {
      /// <summary>
      /// Minimap scaling factor. recommended values are 1-4
      /// </summary>
      public int Scale { get; set; }

      /// <summary>
      /// Render Starting postions as circled numbers
      /// </summary>
      public bool MarkStartingPositions { get; set; }
   }

   internal static class MinimapOptionsFactory
   {
      internal static MinimapOptions Default => new MinimapOptions
      {
         Scale = 2,
         MarkStartingPositions = true
      };
   }
}
