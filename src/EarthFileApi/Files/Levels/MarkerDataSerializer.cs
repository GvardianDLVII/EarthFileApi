using System.IO;

namespace Ieo.EarthFileApi.Files.Levels
{
    internal class MarkerDataSerializer : EarthDataSerializer<MarkerData>
    {
        internal override void Serialize(MemoryStream stream, MarkerData value)
        {
            WriteInt(stream, value.Number);
            WriteShort(stream, value.X);
            WriteShort(stream, value.Y);
        }
    }
}
