using System;
using System.Linq;

namespace Ieo.EarthFileApi.Files.Scripts
{
   internal class EarthEcoMpDataDeserializer : EarthDataDeserializer<EarthEcoMpData>
   {
      internal override EarthEcoMpData Deserialize(byte[] bytes, ref int startingOffset)
      {
         var data = new EarthEcoMpData();
         var offset = startingOffset;
         var header = ReadInt(bytes, ref offset);
         if (header != 0x004F4345)
            throw new InvalidOperationException("Invalid header");
         ReadInt(bytes, ref offset);
         data.MemorySize = ReadInt(bytes, ref offset);
         data.Consts = ReadBytes(bytes, ReadInt(bytes, ref offset), ref offset);
         var numberOfConstReferences = ReadInt(bytes, ref offset);
         data.ConstReferences = Enumerable.Range(0, numberOfConstReferences).Select(_ => ReadInt(bytes, ref offset)).ToArray();
         var numberOfFuncReferences = ReadInt(bytes, ref offset);
         data.FuncReferences = Enumerable.Range(0, numberOfFuncReferences).Select(_ => new FuncReference
         {
            CodeOffset = ReadInt(bytes, ref offset),
            FunctionNumber = ReadInt(bytes, ref offset),
         }).ToArray();
         var numberOfStates = ReadInt(bytes, ref offset);
         data.StatesOffsets = Enumerable.Range(0, numberOfStates).Select(_ => ReadInt(bytes, ref offset)).ToArray();
         var numberOfCommands = ReadInt(bytes, ref offset);
         data.Commands = Enumerable.Range(0, numberOfCommands).Select(_ => new Command
         {
            CodeOffset = ReadInt(bytes, ref offset),
            Unknown = ReadInt(bytes, ref offset),
            Unknown2 = ReadInt(bytes, ref offset),
            Unknown3 = ReadInt(bytes, ref offset),
            Unknown4 = ReadInt(bytes, ref offset),
         }).ToArray();
         var numberOfEvents = ReadInt(bytes, ref offset);
         data.EventOffsets = Enumerable.Range(0, numberOfEvents).Select(_ => ReadInt(bytes, ref offset)).ToArray();

         data.Code = ReadBytes(bytes, ReadInt(bytes, ref offset), ref offset);
         startingOffset = offset;
         return data;
      }
   }
}
