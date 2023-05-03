namespace Ieo.EarthFileApi.Files.Profiles
{
   public class GameOptionsData : IEarthData
   {
      public FogOfWarType FogOfWar { get; set; }
      public bool AtmosphericFog { get; set; }
      public bool TunnelWalls { get; set; }
      public bool TunnelWallsTransparent { get; set; }
      public bool ObjectShadows { get; set; }
      public bool TerrainShadows { get; set; }
      public bool Rain { get; set; }
      public bool Snow { get; set; }
      public bool LightCons { get; set; }
      public bool LowResTextures { get; set; }
      public bool Shining { get; set; }
      public float Gamma1 { get; set; }
      public float Gamma2 { get; set; }
      public float Gamma3 { get; set; }
      public float TunnelsAmbient { get; set; }
      public int ViewDistance { get; set; }
      public float MaxZoom { get; set; }
      public bool Compass { get; set; }
      public bool AutoZoom { get; set; }
      public bool SwapCameras { get; set; }
      public ToolbarPosition ToolbarPostion { get; set; }
      public MapPosition MapPosition { get; set; }
      public bool CommandList { get; set; }
      public bool ReverseMouse { get; set; }
      public PanelPosition PanelPosition { get; set; }
      public int ConsoleSize { get; set; }
      public int ConsoleDisplayTime { get; set; }
      public bool ShowHp { get; set; }
      public bool ShowShield { get; set; }
      public bool ShowElectronics { get; set; }
      public bool ShowAmmo { get; set; }
      public bool ShowExperience { get; set; }
      public bool ShowTemperature { get; set; }
      public bool ShowDynamic { get; set; }
      public SelectionShape SelectionShape { get; set; }
      public bool CommandTooltips { get; set; }
      public bool TooltipsInResearchDialog { get; set; }
      public bool ScrollbarsOnlyIfNeeded { get; set; }
      public DescriptionType DescriptionType { get; set; }
      public bool PauseInConstructor { get; set; }
      public bool PauseInResearchCenter { get; set; }
      public bool PauseInChangeWeapon { get; set; }
      public ScreenInfo ScreenInfo { get; set; }
      public bool UseAutosave { get; set; }
      public bool HpBarOnPanel { get; set; }
      public bool ShieldBarOnPanel { get; set; }
      public bool ShowBuildingTooltips { get; set; }
      public bool ShowDamageSelection { get; set; }
      public float ScrollingMouseSpeed { get; set; }
      public float ScrollingKeyboardSpeed { get; set; }
      public int NumberOfTicksPerSecond { get; set; }
      public bool Soundtrack { get; set; }
      public bool SwapChannels { get; set; }
      public bool DontPlayProductionMessages { get; set; }
      public int MusicVolume { get; set; }
      public int SoundFxVolume { get; set; }
      public int UnitsSpeechVolume { get; set; }
      public int BuildingsSpeechVolume { get; set; }
      public int InterfaceVolume { get; set; }
      public int EnvironmentalVolume { get; set; }
      public int CommandFrequency { get; set; }
      public int UnknownNetworkParameter { get; set; }
      public float MouseSensitivity { get; set; }
      public bool VideoDuobleSized { get; set; }
      public bool VideoSubtitles { get; set; }
      public string InterfaceName { get; set; }
      public int AutoSaveTimeMinutes { get; set; }
      public ShortcutData[] Shortcuts { get; set; } = new ShortcutData[210];
   }
}
