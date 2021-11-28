using Elskom.Generic.Libs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ieo.EarthFileApi.Compression
{
   internal class EarthDecompressor
   {
      internal static IEnumerable<byte[]> ReadSections(byte[] compressedData)
      {
         int bytesProcessed = 0;
         while (bytesProcessed < compressedData.Length)
         {
            Decompress(compressedData.Skip(bytesProcessed).ToArray(), out var section, out var bytesRead);
            bytesProcessed += bytesRead;
            yield return section;
         }
      }

      /// <summary>
      /// Decompiled Decompress method from zlib.managed package, but with `out int bytesRead`, which is needed for reading multiple sections
      /// </summary>
      /// <param name="inData"></param>
      /// <param name="outData"></param>
      /// <param name="bytesRead"></param>
      private static void Decompress(byte[] inData, out byte[] outData, out int bytesRead)
      {
         using MemoryStream memoryStream = new MemoryStream();
         using ZOutputStream zOutputStream = new ZOutputStream(memoryStream);
         using Stream stream = new MemoryStream(inData);
         try
         {
            stream.CopyTo(zOutputStream);
         }
         catch (ZStreamException)
         {
         }
         try
         {
            zOutputStream.Flush();
         }
         catch (StackOverflowException ex2)
         {
            throw new NotPackableException("Decompression Failed due to a stack overflow.", ex2);
         }
         try
         {
            zOutputStream.Finish();
         }
         catch (ZStreamException ex3)
         {
            throw new NotUnpackableException("Decompression Failed.", ex3);
         }
         bytesRead = (int)zOutputStream.TotalIn;
         outData = memoryStream.ToArray();
      }
   }
}
