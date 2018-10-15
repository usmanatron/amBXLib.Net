namespace amBXLib.Net.Helpers
{
  public class ConstrainedNumber
  {
    private readonly float value;
    private readonly int min;
    private readonly int max;

    protected ConstrainedNumber(int min, int max, float value)
    {
      this.min = min;
      this.max = max;
      this.value = value;
    }

    public float Value => ConstrainFloat();

    private float ConstrainFloat()
    {
      if (value < min)
      {
        return min;
      }

      if (value > max)
      {
        return max;
      }

      return value;
    }
  }
}
