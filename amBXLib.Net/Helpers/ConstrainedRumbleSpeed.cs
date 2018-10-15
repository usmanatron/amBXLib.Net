namespace amBXLib.Net.Helpers
{
  public class ConstrainedRumbleSpeed : ConstrainedNumber
  {
    public ConstrainedRumbleSpeed(float value) : base(0, 10, value)
    {
    }
  }
}