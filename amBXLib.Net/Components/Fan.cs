using System;
using amBXLib.Net.Components;
using amBXLib.Net.Exceptions;
using amBXLib.Net.Interop;

namespace amBXLib.Net.Components
{
  public class Fan : ComponentBase
  {
    private FanDelegates fanDelegates;

    public Fan(string name, IntPtr fanPtr, FanDelegates fanDelegates) : base(name, fanPtr)
    {
      Name = name;
      this.fanDelegates = fanDelegates;
    }

    #region Overrides

    protected override amBX_RESULT GetLocation(ref ComponentDirection location)
    {
      return fanDelegates.GetLocation(ComponentPtr, ref location);
    }

    protected override amBX_RESULT GetIsEnabled(ref ComponentEnabled isEnabled)
    {
      return fanDelegates.GetEnabled(ComponentPtr, ref isEnabled);
    }

    protected override amBX_RESULT EnableComponent()
    {
      return fanDelegates.SetEnabled(ComponentPtr, ComponentEnabled.ENABLED);
    }

    protected override amBX_RESULT DisableComponent()
    {
      return fanDelegates.SetEnabled(ComponentPtr, ComponentEnabled.DISABLED);
    }

    protected override void Release()
    {
      try
      {
        ExceptionHelper.CheckForException(fanDelegates.Release(ComponentPtr));
      }
      finally
      {
        ComponentPtr = IntPtr.Zero;
        fanDelegates = null;
      }
    }

    #endregion

    public float Intensity
    {
      get
      {
        float intensity = 0f;
        ExceptionHelper.CheckForException(fanDelegates.GetIntensity(ComponentPtr, ref intensity));
        return intensity;
      }
      set => ExceptionHelper.CheckForException(fanDelegates.SetIntensity(ComponentPtr, value));
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
    /// The minimum change in Intensity that triggers a change on the amBX device
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

    private ComponentExtraProperties ExtraProperties
    {
      get
      {
        long updateInterval = 0;
        float lightDelta = 0f;
        ExceptionHelper.CheckForException(fanDelegates.GetUpdateProperties(ComponentPtr, ref updateInterval, ref lightDelta));
        return new ComponentExtraProperties(updateInterval, lightDelta);
      }
      set => ExceptionHelper.CheckForException(fanDelegates.SetUpdateProperties(ComponentPtr, value.UpdateIntervalMilliseconds, value.IntensityDelta));
    }
  }
}
