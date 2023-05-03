using System.IO;

namespace Ieo.EarthFileApi.Files.Levels
{
    internal class EarthMisDataSerializer : EarthDataSerializer<EarthMisData>
    {
        private readonly PlayerDataSerializer _playerSerializer;
        private readonly MarkerDataSerializer _markerSerializer;
        private readonly ObjectDataSerializer _objectSerializer;

        public EarthMisDataSerializer()
        {
            _playerSerializer = new PlayerDataSerializer();
            _markerSerializer = new MarkerDataSerializer();
            _objectSerializer = new ObjectDataSerializer();
        }

        internal override void Serialize(MemoryStream stream, EarthMisData value)
        {
            WriteString(stream, value.UnknownOptionalString);
            WriteGuid(stream, value.LndFileId);
            WriteByte(stream, GetWaterInfo(value));
            WriteInt(stream, value.TotalResources);
            WriteShort(stream, value.LevelWidth);
            WriteShort(stream, value.LevelHeight);
            WriteInt(stream, value.UnknownField);
            for (int i = 0; i < 16; i++)
            {
                _playerSerializer.Serialize(stream, value.Players[i]);
            }
            WriteShort(stream, value.UnknownField2);
            WriteShort(stream, (short)value.Markers.Count);
            foreach (var marker in value.Markers)
            {
                _markerSerializer.Serialize(stream, marker);
            }
            foreach (var obj in value.Objects)
            {
                _objectSerializer.Serialize(stream, obj);
            }
            WriteInt(stream, 0);
        }

        private byte GetWaterInfo(EarthMisData value)
        {
            byte waterInfo = 0;
            if (value.WaterType == WaterType.Lava) waterInfo |= 0x2;
            if (value.ShipsEnabled) waterInfo |= 0x1;
            return waterInfo;
        }
    }
}
