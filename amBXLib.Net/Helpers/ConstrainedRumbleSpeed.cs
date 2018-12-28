namespace amBXLib.Net.Helpers
{
  public class ConstrainedRumbleSpeed : ConstrainedNumber
  {
    private readonly float value;

    public ConstrainedRumbleSpeed(float value) : base(0, 10)
    {
      this.value = value;
    }

    public float Value => Constrain(value);
  }
}