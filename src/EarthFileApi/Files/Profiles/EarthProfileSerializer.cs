using System.IO;

namespace Ieo.EarthFileApi.Files.Profiles
{
   internal class EarthProfileSerializer : EarthDataSerializer<ProfileData>
   {
      private readonly DynamicCollectionSerializer<TemplateData> _templatesSerializer;
      private readonly StringCollectionSerializer _stringsSerializer;
      private readonly EarthGameOptionsSerializer _gameOptionsSerializer;

      public EarthProfileSerializer()
      {
         _templatesSerializer = new DynamicCollectionSerializer<TemplateData>(new EarthTemplateSerializer());
         _stringsSerializer = new StringCollectionSerializer();
         _gameOptionsSerializer = new EarthGameOptionsSerializer();
      }

      internal override void Serialize(MemoryStream stream, ProfileData value)
      {
         WriteInt(stream, 0x000d4955);
         WriteInt(stream, (int)value.ProfileType);
         WriteStringW(stream, value.ProfileName);
         WriteString(stream, value.EarthNetLogin);
         WriteString(stream, value.EarthNetPassword);
         _templatesSerializer.Serialize(stream, new DynamicCollection<TemplateData>
         {
            Field_0x10 = value.UnknownCollectionValue,
            Items = value.UcsTemplates
         });
         _templatesSerializer.Serialize(stream, new DynamicCollection<TemplateData>
         {
            Field_0x10 = value.UnknownCollectionValue2,
            Items = value.EdTemplates
         });
         _templatesSerializer.Serialize(stream, new DynamicCollection<TemplateData>
         {
            Field_0x10 = value.UnknownCollectionValue3,
            Items = value.LcTemplates
         });
         _stringsSerializer.Serialize(stream, new DynamicCollection<string>
         {
            Field_0x10 = value.UnknownCollectionValue4,
            Items = value.EnabledVideos
         });
         _gameOptionsSerializer.Serialize(stream, value.GameOptions);
         if (value.ProfileType == ProfileType.SnN)
         {
            WriteGuid(stream, value.UnknownGuid);
            WriteString(stream, value.UnknownString);
            WriteInt(stream, value.UnknownValue);
            WriteInt(stream, value.UnknownValue2);
            _stringsSerializer.Serialize(stream, new DynamicCollection<string>
            {
               Field_0x10 = value.UnknownCollectionValue5,
               Items = value.RecentIpAddresses
            });
            _stringsSerializer.Serialize(stream, new DynamicCollection<string>
            {
               Field_0x10 = value.UnknownCollectionValue6,
               Items = value.UnknownValues
            });
         }
      }
   }
}
