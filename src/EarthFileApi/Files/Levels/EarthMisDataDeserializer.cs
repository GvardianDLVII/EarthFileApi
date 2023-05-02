namespace Ieo.EarthFileApi.Files.Levels
{
    internal class EarthMisDataDeserializer : EarthDataDeserializer<EarthMisData>
    {
        private readonly EarthDataDeserializer<PlayerData> _playerDeserializer;
        private readonly EarthDataDeserializer<MarkerData> _markerDeserializer;
        private readonly EarthDataDeserializer<ObjectData> _objectDeserializer;

        internal EarthMisDataDeserializer()
        {
            _playerDeserializer = new EarthPlayerDataDeserializer();
            _markerDeserializer = new EarthMarkerDataDeserializer();
            _objectDeserializer = new EarthObjectDataDeserializer();
        }

        internal override EarthMisData Deserialize(byte[] bytes, ref int startingOffset)
        {
            var data = new EarthMisData();
            int offset = startingOffset;
            data.UnknownOptionalString = ReadString(bytes, ref offset);
            data.LndFileId = ReadGuid(bytes, ref offset);
            var shipsLavaFlags = ReadByte(bytes, ref offset);
            data.ShipsEnabled = (shipsLavaFlags & 1) != 0;
            data.WaterType = (shipsLavaFlags & 2) != 0 ? WaterType.Lava : WaterType.Water;
            data.TotalResources = ReadInt(bytes, ref offset);
            data.LevelWidth = ReadShort(bytes, ref offset);
            data.LevelHeight = ReadShort(bytes, ref offset);
            data.UnknownField = ReadInt(bytes, ref offset);
            for (int i = 0; i < 16; i++)
            {
                var player = _playerDeserializer.Deserialize(bytes, ref offset);
                data.Players[i].UnknownField = player.UnknownField;
                data.Players[i].StartPositionX = player.StartPositionX;
                data.Players[i].StartPositionY = player.StartPositionY;
            }
            data.UnknownField2 = ReadShort(bytes, ref offset);
            var markersCount = ReadShort(bytes, ref offset);
            for (int i = 0; i < markersCount; i++)
            {
                data.Markers.Add(_markerDeserializer.Deserialize(bytes, ref offset));
            }
            while (offset < bytes.Length)
            {
                var @object = _objectDeserializer.Deserialize(bytes, ref offset);
                if (string.IsNullOrEmpty(@object.String)) continue;
                data.Objects.Add(@object);
            }
            startingOffset = offset;
            return data;
        }
    }
}
