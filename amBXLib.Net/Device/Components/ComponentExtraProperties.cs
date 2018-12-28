namespace amBXLib.Net.Device.Components
{
    class ComponentExtraProperties
    {
      public long UpdateIntervalMilliseconds;
      public float IntensityDelta;

      // Only used by Rumbles, which is slightly unfortunate!
      public float SpeedDelta;


      public ComponentExtraProperties(long updateInterval, float intensityDelta, float speedDelta = 0f)
      {
        UpdateIntervalMilliseconds = updateInterval;
        IntensityDelta = intensityDelta;
        SpeedDelta = speedDelta;
      }

      public ComponentExtraProperties Clone()
      {
        return new ComponentExtraProperties(UpdateIntervalMilliseconds, IntensityDelta, SpeedDelta);
      }
  }
}
