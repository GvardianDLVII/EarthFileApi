using System;

namespace Ieo.EarthFileApi.Files.Profiles
{
   internal class EarthProfileDeserializer : EarthDataDeserializer<ProfileData>
    {
        private readonly DynamicCollectionDeserializer<TemplateData> _templatesDeserializer;
        private readonly StringCollectionDeserializer _stringsDeserializer;
        private readonly EarthGameOptionsDeserializer _gameOptionsDeserializer;

        public EarthProfileDeserializer()
        {
            _templatesDeserializer = new DynamicCollectionDeserializer<TemplateData>(new EarthTemplateDeserializer());
            _stringsDeserializer = new StringCollectionDeserializer();
            _gameOptionsDeserializer = new EarthGameOptionsDeserializer();
        }

        internal override ProfileData Deserialize(byte[] bytes, ref int startingOffset)
        {
            var data = new ProfileData();
            var offset = startingOffset;
            int header = ReadInt(bytes, ref offset);
            if (header != 0x000d4955)
                throw new InvalidOperationException("Wrong header value for the profile data.");
            data.ProfileType = (ProfileType)ReadInt(bytes, ref offset);
            data.ProfileName = ReadStringW(bytes, ref offset);
            data.EarthNetLogin = ReadString(bytes, ref offset);
            data.EarthNetPassword = ReadString(bytes, ref offset);
            var ucsTemplates = _templatesDeserializer.Deserialize(bytes, ref offset);
            var edTemplates = _templatesDeserializer.Deserialize(bytes, ref offset);
            var lcTemplates = _templatesDeserializer.Deserialize(bytes, ref offset);
            data.UnknownCollectionValue = ucsTemplates.Field_0x10;
            data.UcsTemplates = ucsTemplates.Items;
            data.UnknownCollectionValue2 = edTemplates.Field_0x10;
            data.EdTemplates = edTemplates.Items;
            data.UnknownCollectionValue3 = lcTemplates.Field_0x10;
            data.LcTemplates = lcTemplates.Items;
            var unknownValues = _stringsDeserializer.Deserialize(bytes, ref offset);
            data.UnknownCollectionValue4 = unknownValues.Field_0x10;
            data.EnabledVideos = unknownValues.Items;
            data.GameOptions = _gameOptionsDeserializer.Deserialize(bytes, ref offset);
            if (data.ProfileType == ProfileType.SnN)
            {
                data.UnknownGuid = ReadGuid(bytes, ref offset);
                data.UnknownString = ReadString(bytes, ref offset);
                data.UnknownValue = ReadInt(bytes, ref offset);
                data.UnknownValue2 = ReadInt(bytes, ref offset);
                var ipAddresses = _stringsDeserializer.Deserialize(bytes, ref offset);
                data.UnknownCollectionValue5 = ipAddresses.Field_0x10;
                data.RecentIpAddresses = ipAddresses.Items;
                var unknownValues2 = _stringsDeserializer.Deserialize(bytes, ref offset);
                data.UnknownCollectionValue6 = unknownValues2.Field_0x10;
                data.UnknownValues = unknownValues2.Items;
            }

            startingOffset = offset;
            return data;
        }
    }
}
