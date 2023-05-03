using System;
using System.Collections.Generic;

namespace Ieo.EarthFileApi.Files.Profiles
{
   public class ProfileData : IEarthData
   {
      public ProfileType ProfileType { get; set; }
      public string ProfileName { get; set; }
      public string EarthNetLogin { get; set; }
      public string EarthNetPassword { get; set; }
      public int UnknownCollectionValue { get; set; }
      public IList<TemplateData> UcsTemplates { get; set; }
      public int UnknownCollectionValue2 { get; set; }
      public IList<TemplateData> EdTemplates { get; set; }
      public int UnknownCollectionValue3 { get; set; }
      public IList<TemplateData> LcTemplates { get; set; }
      public int UnknownCollectionValue4 { get; set; }
      public IList<string> EnabledVideos { get; set; }
      public GameOptionsData GameOptions { get; set; }
      public Guid UnknownGuid { get; set; }
      public string UnknownString { get; set; }
      public int UnknownValue { get; set; }
      public int UnknownValue2 { get; set; }
      public int UnknownCollectionValue5 { get; set; }
      public IList<string> RecentIpAddresses { get; set; }
      public int UnknownCollectionValue6 { get; set; }
      public IList<string> UnknownValues { get; set; }
   }
}
