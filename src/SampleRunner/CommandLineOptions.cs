using CommandLine;

namespace SampleRunner
{
   public class CommandLineOptions
   {
      [Option(Required = false, Default = "single", HelpText = "'single' or 'multiple'. Determines whether to read single file or directory")]
      public string Mode { get; set; }
      [Option(Required = false, HelpText = "path to LND file, required for 'single' mode")]
      public string Lnd { get; set; }
      [Option(Required = false, HelpText = "path to MIS file, required for 'single' mode")]
      public string Mis { get; set; }
      [Option('i', Required = false, HelpText = "path to input directory, required for 'multiple' mode")]
      public string InputPath { get; set; }
      [Option('o', Required = true, HelpText = "path to output file, or output directory")]
      public string OutputPath { get; set; }
      [Option(Required = false, Default = 2, HelpText = "Determines output image size")]
      public int Scale { get; set; }
      [Option(Required = false, HelpText = "If specified, starting positions will not be marked with circled numbers")]
      public bool HideStartingPositions { get; set; }
   }
}
