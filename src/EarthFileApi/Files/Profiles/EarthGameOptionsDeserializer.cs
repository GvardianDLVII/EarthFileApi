using System.Text;

namespace Ieo.EarthFileApi.Files.Profiles
{
   internal class EarthGameOptionsDeserializer : EarthDataDeserializer<GameOptionsData>
   {
      internal override GameOptionsData Deserialize(byte[] bytes, ref int startingOffset)
      {
         var result = new GameOptionsData();
         var graphicsSettings = ReadInt(bytes, ref startingOffset);
         result.FogOfWar = (graphicsSettings & 0x2) != 0 ? FogOfWarType.Environmental : FogOfWarType.Black;
         result.AtmosphericFog = (graphicsSettings & 0x4) != 0;
         result.TunnelWalls = (graphicsSettings & 0x8) != 0;
         result.TunnelWallsTransparent = (graphicsSettings & 0x10) != 0;
         result.ObjectShadows = (graphicsSettings & 0x20) != 0;
         result.TerrainShadows = (graphicsSettings & 0x40) != 0;
         result.Rain = (graphicsSettings & 0x80) != 0;
         result.Snow = (graphicsSettings & 0x100) != 0;
         result.LightCons = (graphicsSettings & 0x400) != 0;
         result.LowResTextures = (graphicsSettings & 0x1000) != 0;
         result.Shining = (graphicsSettings & 0x2000) != 0;

         result.Gamma1 = ReadFloat(bytes, ref startingOffset);
         result.Gamma2 = ReadFloat(bytes, ref startingOffset);
         result.Gamma3 = ReadFloat(bytes, ref startingOffset);
         result.TunnelsAmbient = ReadFloat(bytes, ref startingOffset);
         result.ViewDistance = ReadInt(bytes, ref startingOffset);
         result.MaxZoom = ReadFloat(bytes, ref startingOffset);

         var interfaceSettings = ReadInt(bytes, ref startingOffset);
         result.Compass = (interfaceSettings & 0x1) != 0;
         result.AutoZoom = (interfaceSettings & 0x2) != 0;
         result.SwapCameras = (interfaceSettings & 0x4) != 0;
         result.ToolbarPostion = (interfaceSettings & 0x10) != 0 ? ToolbarPosition.Bottom : ToolbarPosition.Top;
         result.MapPosition = (interfaceSettings & 0x20) != 0 ? MapPosition.BottomRight : MapPosition.TopLeft;
         result.CommandList = (interfaceSettings & 0x80) != 0;
         result.ReverseMouse = (interfaceSettings & 0x100) != 0;

         var unused = ReadInt(bytes, ref startingOffset);
         result.PanelPosition = (PanelPosition)ReadInt(bytes, ref startingOffset);
         result.ConsoleSize = ReadInt(bytes, ref startingOffset);
         result.ConsoleDisplayTime = ReadInt(bytes, ref startingOffset);

         var selectionSettings = ReadInt(bytes, ref startingOffset);
         result.ShowHp = (selectionSettings & 0x1) != 0;
         result.ShowShield = (selectionSettings & 0x2) != 0;
         result.ShowElectronics = (selectionSettings & 0x4) != 0;
         result.ShowAmmo = (selectionSettings & 0x8) != 0;
         result.ShowExperience = (selectionSettings & 0x10) != 0;
         result.ShowTemperature = (selectionSettings & 0x20) != 0;
         result.ShowDynamic = (selectionSettings & 0x40) != 0;
         result.SelectionShape = (selectionSettings & 0x100) != 0 ? SelectionShape.Isometric : SelectionShape.Square;
         result.CommandTooltips = (selectionSettings & 0x200) != 0;
         result.TooltipsInResearchDialog = (selectionSettings & 0x400) != 0;
         result.ScrollbarsOnlyIfNeeded = (selectionSettings & 0x800) != 0;
         result.DescriptionType = (selectionSettings & 0x1000) != 0 ? DescriptionType.Tooltip : DescriptionType.Normal;
         result.PauseInConstructor = (selectionSettings & 0x4000) != 0;
         result.PauseInResearchCenter = (selectionSettings & 0x8000) != 0;
         result.PauseInChangeWeapon = (selectionSettings & 0x10000) != 0;
         result.ScreenInfo = (selectionSettings & 0x40000) != 0
            ? ScreenInfo.Temperature
            : (selectionSettings & 0x20000) != 0
               ? ScreenInfo.Clock
               : ScreenInfo.None;
         result.UseAutosave = (selectionSettings & 0x80000) != 0;
         result.HpBarOnPanel = (selectionSettings & 0x100000) != 0;
         result.ShieldBarOnPanel = (selectionSettings & 0x200000) != 0;
         result.ShowBuildingTooltips = (selectionSettings & 0x400000) != 0;
         result.ShowDamageSelection = (selectionSettings & 0x800000) != 0;

         result.ScrollingMouseSpeed = ReadFloat(bytes, ref startingOffset);
         result.ScrollingKeyboardSpeed = ReadFloat(bytes, ref startingOffset);
         result.NumberOfTicksPerSecond = ReadInt(bytes, ref startingOffset);

         var soundSettings = ReadInt(bytes, ref startingOffset);
         result.Soundtrack = (soundSettings & 0x2) != 0;
         result.SwapChannels = (soundSettings & 0x4) != 0;
         result.DontPlayProductionMessages = (soundSettings & 0x8) != 0;

         result.MusicVolume = ReadInt(bytes, ref startingOffset);
         result.SoundFxVolume = ReadInt(bytes, ref startingOffset);
         result.UnitsSpeechVolume = ReadInt(bytes, ref startingOffset);
         result.BuildingsSpeechVolume = ReadInt(bytes, ref startingOffset);
         result.InterfaceVolume = ReadInt(bytes, ref startingOffset);
         result.EnvironmentalVolume = ReadInt(bytes, ref startingOffset);
         result.CommandFrequency = ReadInt(bytes, ref startingOffset);
         result.UnknownNetworkParameter = ReadInt(bytes, ref startingOffset);
         result.MouseSensitivity = ReadFloat(bytes, ref startingOffset);

         var videoSettings = ReadInt(bytes, ref startingOffset);
         result.VideoDuobleSized = (videoSettings & 0x1) != 0;
         result.VideoSubtitles = (videoSettings & 0x2) != 0;

         var interfaceNameBytes = ReadBytes(bytes, 60, ref startingOffset);
         result.InterfaceName = Encoding.UTF8.GetString(interfaceNameBytes).TrimEnd((char)0x0);
         result.AutoSaveTimeMinutes = ReadInt(bytes, ref startingOffset);

         for (int i = 0; i < 210; i++)
         {
            result.Shortcuts[i] = new ShortcutData();
            result.Shortcuts[i].ShowInTooltip = ReadInt(bytes, ref startingOffset) != 0;
            result.Shortcuts[i].BoundKey = ReadInt(bytes, ref startingOffset);
            result.Shortcuts[i].ModifierKey = ReadInt(bytes, ref startingOffset);
         }

         return result;
      }
   }
}
