using System;
using System.Collections.Generic;
using System.Text;

namespace Ieo.EarthFileApi.Files.Scripts
{
   public class EarthEcoMpData : IEarthData
   {
      public int MemorySize { get; set; }
      public byte[] Consts { get; set; }
      public int[] ConstReferences { get; set; }
      public FuncReference[] FuncReferences { get; set; }
      public int[] StatesOffsets { get; set; }
      public Command[] Commands { get; set; }
      public int[] EventOffsets{ get; set; }

      public byte[] Code { get; set; }
   }

   public class FuncReference
   {
      public int CodeOffset { get; set; }
      public int FunctionNumber { get; set; }
   }

   public class Command
   {
      public int CodeOffset { get; set; }
      public int Unknown { get; set; }
      public int Unknown2 { get; set; }
      public int Unknown3 { get; set; }
      public int Unknown4 { get; set; }
   }
}
