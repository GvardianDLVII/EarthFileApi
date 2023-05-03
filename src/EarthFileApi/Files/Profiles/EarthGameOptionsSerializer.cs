using System.IO;
using System.Text;

namespace Ieo.EarthFileApi.Files.Profiles
{
   internal class EarthGameOptionsSerializer : EarthDataSerializer<GameOptionsData>
   {
      internal override void Serialize(MemoryStream stream, GameOptionsData value)
      {
         WriteInt(stream, GetGraphicsSettings(value));
         WriteFloat(stream, value.Gamma1);
         WriteFloat(stream, value.Gamma2);
         WriteFloat(stream, value.Gamma3);
         WriteFloat(stream, value.TunnelsAmbient);
         WriteInt(stream, value.ViewDistance);
         WriteFloat(stream, value.MaxZoom);
         WriteInt(stream, GetInterfaceSettings(value));
         WriteInt(stream, 0);
         WriteInt(stream, (int)value.PanelPosition);
         WriteInt(stream, value.ConsoleSize);
         WriteInt(stream, value.ConsoleDisplayTime);
         WriteInt(stream, GetSelectionSettings(value));
         WriteFloat(stream, value.ScrollingMouseSpeed);
         WriteFloat(stream, value.ScrollingKeyboardSpeed);
         WriteInt(stream, value.NumberOfTicksPerSecond);
         WriteInt(stream, GetSoundSettings(value));
         WriteInt(stream, value.MusicVolume);
         WriteInt(stream, value.SoundFxVolume);
         WriteInt(stream, value.UnitsSpeechVolume);
         WriteInt(stream, value.BuildingsSpeechVolume);
         WriteInt(stream, value.InterfaceVolume);
         WriteInt(stream, value.EnvironmentalVolume);
         WriteInt(stream, value.CommandFrequency);
         WriteInt(stream, value.UnknownNetworkParameter);
         WriteFloat(stream, value.MouseSensitivity);
         WriteInt(stream, GetVideoSettings(value));
         WriteBytes(stream, Encoding.UTF8.GetBytes(value.InterfaceName.PadRight(60, (char)0x0)));
         WriteInt(stream, value.AutoSaveTimeMinutes);

         for (int i = 0; i < 210; i++)
         {
            WriteInt(stream, value.Shortcuts[i].ShowInTooltip ? 1 : 0);
            WriteInt(stream, value.Shortcuts[i].BoundKey);
            WriteInt(stream, value.Shortcuts[i].ModifierKey);
         }
      }

      private int GetGraphicsSettings(GameOptionsData value)
      {
         int graphicsSettings = 0;
         if (value.FogOfWar == FogOfWarType.Black) graphicsSettings |= 0x1;
         if (value.FogOfWar == FogOfWarType.Environmental) graphicsSettings |= 0x2;
         if (value.AtmosphericFog) graphicsSettings |= 0x4;
         if (value.TunnelWalls) graphicsSettings |= 0x8;
         if (value.TunnelWallsTransparent) graphicsSettings |= 0x10;
         if (value.ObjectShadows) graphicsSettings |= 0x20;
         if (value.TerrainShadows) graphicsSettings |= 0x40;
         if (value.Rain) graphicsSettings |= 0x80;
         if (value.Snow) graphicsSettings |= 0x100;
         if (value.LightCons) graphicsSettings |= 0x400;
         if (value.LowResTextures) graphicsSettings |= 0x1000;
         if (value.Shining) graphicsSettings |= 0x2000;

         return graphicsSettings;
      }

      private int GetInterfaceSettings(GameOptionsData value)
      {
         int interfaceSettings = 0;
         if (value.Compass) interfaceSettings |= 0x1;
         if (value.AutoZoom) interfaceSettings |= 0x2;
         if (value.SwapCameras) interfaceSettings |= 0x4;
         if (value.ToolbarPostion == ToolbarPosition.Bottom) interfaceSettings |= 0x10;
         if (value.MapPosition == MapPosition.BottomRight) interfaceSettings |= 0x20;
         if (value.CommandList) interfaceSettings |= 0x80;
         if (value.ReverseMouse) interfaceSettings |= 0x100;
         return interfaceSettings;
      }

      private int GetSelectionSettings(GameOptionsData value)
      {
         int selectionSettings = 0;
         if (value.ShowHp) selectionSettings |= 0x1;
         if (value.ShowShield) selectionSettings |= 0x2;
         if (value.ShowElectronics) selectionSettings |= 0x4;
         if (value.ShowAmmo) selectionSettings |= 0x8;
         if (value.ShowExperience) selectionSettings |= 0x10;
         if (value.ShowTemperature) selectionSettings |= 0x20;
         if (value.ShowDynamic) selectionSettings |= 0x40;
         if (value.SelectionShape == SelectionShape.Isometric) selectionSettings |= 0x100;
         if (value.CommandTooltips) selectionSettings |= 0x200;
         if (value.TooltipsInResearchDialog) selectionSettings |= 0x400;
         if (value.ScrollbarsOnlyIfNeeded) selectionSettings |= 0x800;
         if (value.DescriptionType == DescriptionType.Tooltip) selectionSettings |= 0x1000;
         if (value.PauseInConstructor) selectionSettings |= 0x4000;
         if (value.PauseInResearchCenter) selectionSettings |= 0x8000;
         if (value.PauseInChangeWeapon) selectionSettings |= 0x10000;
         if (value.ScreenInfo == ScreenInfo.Clock) selectionSettings |= 0x20000;
         if (value.ScreenInfo == ScreenInfo.Temperature) selectionSettings |= 0x40000;
         if (value.UseAutosave) selectionSettings |= 0x80000;
         if (value.HpBarOnPanel) selectionSettings |= 0x100000;
         if (value.ShieldBarOnPanel) selectionSettings |= 0x200000;
         if (value.ShowBuildingTooltips) selectionSettings |= 0x400000;
         if (value.ShowDamageSelection) selectionSettings |= 0x800000;
         return selectionSettings;
      }

      private int GetSoundSettings(GameOptionsData value)
      {
         int soundSettings = 0;
         if (value.Soundtrack) soundSettings |= 0x2;
         if (value.SwapChannels) soundSettings |= 0x4;
         if (value.DontPlayProductionMessages) soundSettings |= 0x8;
         return soundSettings;
      }

      private int GetVideoSettings(GameOptionsData value)
      {
         int videoSettings = 0;
         if (value.VideoDuobleSized) videoSettings |= 0x1;
         if (value.VideoSubtitles) videoSettings |= 0x2;
         return videoSettings;
      }
   }
}
