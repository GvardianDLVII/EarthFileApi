namespace Ieo.EarthFileApi.Files
{
   internal class EarthHeaderDeserializer : EarthDataDeserializer<EarthHeader>
   {
      internal override EarthHeader Deserialize(byte[] bytes, ref int startingOffset)
      {
         var header = new EarthHeader();
         header.Header = ReadInt(bytes, ref startingOffset);
         header.FileName = ReadShortString(bytes, ref startingOffset);
         header.UnknownOptionalField = ReadInt(bytes, ref startingOffset);
         header.FileId = ReadGuid(bytes, ref startingOffset);
         return header;
      }
   }
}
