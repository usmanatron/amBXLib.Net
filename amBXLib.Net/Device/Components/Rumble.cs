using System;
using System.Linq;
using amBXLib.Net.Delegates;
using amBXLib.Net.Exceptions;
using amBXLib.Net.Helpers;
using amBXLib.Net.Device;

namespace amBXLib.Net.Device.Components
{
  public class Rumble : ComponentBase
  {
    private RumbleDelegates rumbleDelegates;

    public Rumble(string name, IntPtr rumblePtr, RumbleDelegates rumbleDelegates) : base(name, rumblePtr)
    {
      this.rumbleDelegates = rumbleDelegates;
    }

    #region Overrides

    protected override amBXOperationResult GetLocation(ref ComponentDirection location)
    {
      return rumbleDelegates.GetLocation(ComponentPtr, ref location);
    }

    protected override amBXOperationResult GetIsEnabled(ref ComponentEnabled isEnabled)
    {
      return rumbleDelegates.GetEnabled(ComponentPtr, ref isEnabled);
    }

    protected override amBXOperationResult EnableComponent()
    {
      return rumbleDelegates.SetEnabled(ComponentPtr, true);
    }

    // NOTE: This doesn't always work on Rumbles - more investigation is needed
    protected override amBXOperationResult DisableComponent()
    {
      return rumbleDelegates.SetEnabled(ComponentPtr, false);
    }

    #endregion


    public void SetRumble(RumbleWaveForms waveForm, ConstrainedUnit speed, ConstrainedUnit intensity)
    {
      ExceptionHelper.CheckForException(rumbleDelegates.SetRumble(ComponentPtr, GetNameFromEnum(waveForm), speed.Value, intensity.Value));
    }

    public void GetRumble(ref RumbleWaveForms waveForm, ref ConstrainedUnit constrainedSpeed, ref ConstrainedUnit constrainedIntensity)
    {
      var name = string.Empty;
      int nameLength = 0;
      float speed = 0f;
      float intensity = 0f;
      ExceptionHelper.CheckForException(rumbleDelegates.GetRumble(ComponentPtr, 255, name, ref nameLength, ref speed, ref intensity));

      waveForm = GetEnumFromName(name.Substring(0, nameLength));
      constrainedSpeed = new ConstrainedUnit(speed);
      constrainedIntensity = new ConstrainedUnit(intensity);
    }

    private string GetNameFromEnum(RumbleWaveForms waveForm) //MapEnumToName
    {
      return waveForm.GetStringValue();
    }

    /// <remarks>Magically adds a fallback value if no enum was found (will select the 1st item)</remarks>
    private RumbleWaveForms GetEnumFromName(string name) //MapNameToEnum
    {
      return ((RumbleWaveForms[]) Enum.GetValues(typeof(RumbleWaveForms)))
        .FirstOrDefault(waveForm =>
          String.Equals(waveForm.GetStringValue(), name, StringComparison.CurrentCultureIgnoreCase));
    }

    

    public long UpdateIntervalMilliseconds
    {
      get => ExtraProperties.UpdateIntervalMilliseconds;
      set
      {
        var properties = ExtraProperties.Clone();
        properties.UpdateIntervalMilliseconds = value;
        ExtraProperties = properties;
      }
    }

    /// <summary>
    /// The minimum change in Colour that triggers a change on the amBX device
    /// </summary>
    public float IntensityDelta
    {
      get => ExtraProperties.IntensityDelta;
      set
      {
        var properties = ExtraProperties.Clone();
        properties.IntensityDelta = value;
        ExtraProperties = properties;
      }
    }

    /// <summary>
    /// The minimum change in Speed that triggers a change on the amBX device
    /// </summary>
    public ConstrainedRumbleSpeed SpeedDelta
    {
      get => new ConstrainedRumbleSpeed(ExtraProperties.SpeedDelta);
      set
      {
        var properties = ExtraProperties.Clone();
        properties.SpeedDelta = value.Value;
        ExtraProperties = properties;
      }
    }

    private ComponentExtraProperties ExtraProperties
    {
      get
      {
        long updateInterval = 0;
        float speedDelta = 0f;
        float intensityDelta = 0f;
        ExceptionHelper.CheckForException(rumbleDelegates.GetUpdateProperties(ComponentPtr, ref updateInterval, ref speedDelta, ref intensityDelta));
        return new ComponentExtraProperties(updateInterval, intensityDelta, speedDelta);
      }
      set => ExceptionHelper.CheckForException(rumbleDelegates.SetUpdateProperties(ComponentPtr, value.UpdateIntervalMilliseconds, value.SpeedDelta, value.IntensityDelta));
    }

    protected override void Release()
    {
      try
      {
        ExceptionHelper.CheckForException(rumbleDelegates.Release(ComponentPtr));
      }
      finally
      {
        EntityPtr = IntPtr.Zero;
        rumbleDelegates = null;
      }
    }
  }
}