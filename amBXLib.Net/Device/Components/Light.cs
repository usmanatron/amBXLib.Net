using System;
using amBXLib.Net.Delegates.Components;
using amBXLib.Net.Exceptions;
using amBXLib.Net.Helpers;

namespace amBXLib.Net.Device.Components
{
  public class Light : ComponentBase
  {
    private LightDelegates lightDelegates;

    public Light(string name, IntPtr lightPtr, LightDelegates lightDelegates) : base(name, lightPtr)
    {
      this.lightDelegates = lightDelegates;
    }

    #region Overrides

    protected override amBXOperationResult GetLocation(ref ComponentDirection location)
    {
      return lightDelegates.GetLocation(ComponentPtr, ref location);
    }

    // Unlike other components, a Light returns a bool.  We convert this as appropriate
    protected override amBXOperationResult GetIsEnabled(ref ComponentEnabled isEnabled)
    {

      var lightEnabled = false;
      var result = lightDelegates.GetEnabled(ComponentPtr, ref lightEnabled);
      isEnabled = lightEnabled ? ComponentEnabled.Enabled : ComponentEnabled.Disabled;
      return result;
    }

    protected override amBXOperationResult EnableComponent()
    {
      return lightDelegates.SetEnabled(ComponentPtr, true);
    }

    protected override amBXOperationResult DisableComponent()
    {
      return lightDelegates.SetEnabled(ComponentPtr, false);
    }

    protected override void Release()
    {
      try
      {
        ExceptionHelper.CheckForException(lightDelegates.Release(ComponentPtr));
      }
      finally
      {
        EntityPtr = IntPtr.Zero;
        lightDelegates = null;
      }
    }

    #endregion

    public int FadeTime
    {
      get
      {
        var fadeTime = 0;
        ExceptionHelper.CheckForException(lightDelegates.GetFadeTime(ComponentPtr, ref fadeTime));
        return fadeTime;
      }
      set => ExceptionHelper.CheckForException(lightDelegates.SetFadeTime(ComponentPtr, value));
    }

    public Colour Colour
    {
      get

      {
        var red = 0f;
        var green = 0f;
        var blue = 0f;
        ExceptionHelper.CheckForException(lightDelegates.GetCol(ComponentPtr, ref red, ref green, ref blue));
        return new Colour(red, green, blue);
      }
      set => ExceptionHelper.CheckForException(lightDelegates.SetCol(ComponentPtr, value.Red.Value, value.Green.Value, value.Blue.Value));
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
    public float LightDelta
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
        ExceptionHelper.CheckForException(lightDelegates.GetUpdateProperties(ComponentPtr, ref updateInterval, ref lightDelta));
        return new ComponentExtraProperties(updateInterval, lightDelta);
      }
      set => ExceptionHelper.CheckForException(lightDelegates.SetUpdateProperties(ComponentPtr, value.UpdateIntervalMilliseconds, value.IntensityDelta));
    }
  }
}
