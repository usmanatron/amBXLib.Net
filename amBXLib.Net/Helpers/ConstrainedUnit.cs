namespace amBXLib.Net.Helpers
{
  public class ConstrainedUnit : ConstrainedNumber
  {
    private readonly float value;

    public ConstrainedUnit(float value) : base(0, 1)
    {
      this.value = value;
    }

    public float Value => Constrain(value);
  }
}