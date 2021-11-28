namespace Ieo.EarthFileApi.Files
{
   public class EarthFile<T> where T : IEarthData
   {
      public EarthHeader Header { get; set; }
      public T Data { get; set; }
      public FileType Type { get; set; }
   }
}
