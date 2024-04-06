using System;
using System.Linq;
using System.Text;

namespace Ieo.EarthFileApi.Files
{
   internal abstract class EarthDataDeserializer<T> where T : IEarthData
   {
      internal T Deserialize(byte[] bytes)
      {
         var offset = 0;
         return Deserialize(bytes, ref offset);
      }

      internal abstract T Deserialize(byte[] bytes, ref int startingOffset);

      protected static int ReadInt(byte[] bytes, ref int offset)
      {
         var result = BitConverter.ToInt32(bytes, offset);
         offset += 4;
         return result;
      }

      protected static float ReadFloat(byte[] bytes, ref int offset)
      {
         var result = BitConverter.ToSingle(bytes, offset);
         offset += 4;
         return result;
      }

      protected static short ReadShort(byte[] bytes, ref int offset)
      {
         var result = BitConverter.ToInt16(bytes, offset);
         offset += 2;
         return result;
      }

      protected static string ReadString(byte[] bytes, ref int offset, Encoding encoding = null)
      {
         var length = ReadInt(bytes, ref offset);
         if (length == 0)
            return string.Empty;

         encoding ??= Encoding.UTF8;
         var result = encoding.GetString(bytes, offset, length);
         offset += length;
         return result;
      }

      protected static string ReadShortString(byte[] bytes, ref int offset)
      {
         var length = ReadByte(bytes, ref offset);
         if (length == 0)
            return string.Empty;
         var result = Encoding.UTF8.GetString(bytes, offset, length);
         offset += length;
         return result;
      }

      protected static string ReadStringW(byte[] bytes, ref int offset)
      {
         var length = ReadInt(bytes, ref offset);
         if (length == 0)
            return string.Empty;
         var result = Encoding.Unicode.GetString(bytes, offset, length*2);
         offset += length * 2;
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
