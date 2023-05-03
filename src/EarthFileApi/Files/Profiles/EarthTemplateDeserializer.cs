namespace Ieo.EarthFileApi.Files.Profiles
{
   internal class EarthTemplateDeserializer : EarthDataDeserializer<TemplateData>
    {
        internal override TemplateData Deserialize(byte[] bytes, ref int startingOffset)
        {
            var result = new TemplateData();
            result.Field_0x4 = ReadInt(bytes, ref startingOffset);
            result.ChassisName = ReadString(bytes, ref startingOffset);
            result.Field_0xc = ReadInt(bytes, ref startingOffset);
            result.Field_0x10 = ReadInt(bytes, ref startingOffset);
            result.Field_0x14 = ReadInt(bytes, ref startingOffset);
            result.PowerShieldType = ReadInt(bytes, ref startingOffset);
            result.ScriptId = ReadGuid(bytes, ref startingOffset);
            for (int i = 0; i < 8; i++)
                result.Slots[i] = ReadString(bytes, ref startingOffset);
            result.TemplateName = ReadStringW(bytes, ref startingOffset);
            return result;
        }
    }
}
