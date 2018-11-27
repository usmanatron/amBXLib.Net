namespace amBXLib.Net.Helpers
{
  public class ConstrainedUnit : ConstrainedNumber
  {
    public ConstrainedUnit(float value) : base(0, 1, value)
    {
    }
  }
}