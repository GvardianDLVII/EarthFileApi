using System;
using System.Linq;
using System.Text;

namespace Ieo.EarthFileApi.Files
{
   internal abstract class EarthFileFactory<T> where T : IEarthData
   {
      protected abstract FileType Type { get; }
      public EarthFile<T> Create(byte[] header, byte[] data)
      {
         return new EarthFile<T>
         {
            Type = Type,
            Header = CreateHeader(header),
            Data = CreateData(data)
         };
      }

      protected EarthHeader CreateHeader(byte[] bytes)
      {
         var header = new EarthHeader();
         int offset = 0;
         header.Header = ReadInt(bytes, ref offset);
         var fileNameLength = ReadByte(bytes, ref offset);
         header.FileName = ReadString(bytes, fileNameLength, ref offset);
         header.UnknownOptionalField = ReadInt(bytes, ref offset);
         header.FileId = ReadGuid(bytes, ref offset);
         return header;
      }

      protected abstract T CreateData(byte[] bytes);

      protected static int ReadInt(byte[] bytes, ref int offset)
      {
         var result = BitConverter.ToInt32(bytes, offset);
         offset += 4;
         return result;
      }

      protected static short ReadShort(byte[] bytes, ref int offset)
      {
         var result = BitConverter.ToInt16(bytes, offset);
         offset += 2;
         return result;
      }

      protected static string ReadString(byte[] bytes, int length, ref int offset)
      {
         var result = Encoding.UTF8.GetString(bytes, offset, length);
         offset += length;
         return result;
      }

      protected static Guid ReadGuid(byte[] bytes, ref int offset)
      {
         var result = new Guid(bytes.Skip(offset).Take(16).ToArray());
         offset += 16;
         return result;
      }

      protected static byte ReadByte(byte[] bytes, ref int offset)
      {
         var result = bytes[offset];
         offset++;
         return result;
      }

      protected static byte[] ReadBytes(byte[] bytes, int count, ref int offset)
      {
         var result = bytes.Skip(offset).Take(count).ToArray();
         offset += count;
         return result;
      }
   }
}
