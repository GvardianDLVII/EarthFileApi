using System;
using System.IO;
using System.Text;

namespace Ieo.EarthFileApi.Files
{
   internal abstract class EarthDataSerializer<T> where T : IEarthData
   {
      internal abstract void Serialize(MemoryStream stream, T value);

      protected static void WriteInt(MemoryStream stream, int value)
      {
         stream.Write(BitConverter.GetBytes(value));
      }

      protected static void WriteFloat(MemoryStream stream, float value)
      {
         stream.Write(BitConverter.GetBytes(value));
      }

      protected static void WriteShort(MemoryStream stream, short value)
      {
         stream.Write(BitConverter.GetBytes(value));
      }

      protected static void WriteString(MemoryStream stream, string value, Encoding encoding = null)
      {
         stream.Write(BitConverter.GetBytes(value.Length));

         encoding ??= Encoding.UTF8;
         stream.Write(encoding.GetBytes(value));
      }

      protected static void WriteShortString(MemoryStream stream, string value)
      {
         stream.Write(new[] { (byte)value.Length });
         stream.Write(Encoding.UTF8.GetBytes(value));
      }

      protected static void WriteStringW(MemoryStream stream, string value)
      {
         stream.Write(BitConverter.GetBytes(value.Length));
         stream.Write(Encoding.Unicode.GetBytes(value));
      }

      protected static void WriteGuid(MemoryStream stream, Guid value)
      {
         stream.Write(value.ToByteArray());
      }

      protected static void WriteByte(MemoryStream stream, byte value)
      {
         stream.Write(new[] { value });
      }

      protected static void WriteBytes(MemoryStream stream, byte[] value)
      {
         stream.Write(value);
      }
   }
}
