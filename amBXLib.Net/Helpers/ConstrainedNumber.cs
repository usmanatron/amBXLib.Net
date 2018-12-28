namespace amBXLib.Net.Helpers
{
  public class ConstrainedNumber
  {
    public int Min { get; }
    public int Max { get; }

    protected ConstrainedNumber(int min, int max)
    {
      Min = min;
      Max = max;
    }

    protected float Constrain(float value)
    {
      if (value < Min)
      {
        return Min;
      }

      if (value > Max)
      {
        return Max;
      }

      return value;
    }
  }
}
