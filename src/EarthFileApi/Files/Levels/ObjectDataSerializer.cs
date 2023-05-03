using System.IO;

namespace Ieo.EarthFileApi.Files.Levels
{
    internal class ObjectDataSerializer : EarthDataSerializer<ObjectData>
    {
        internal override void Serialize(MemoryStream stream, ObjectData value)
        {
            WriteString(stream, value.String);
        }
    }
}
