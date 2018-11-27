
namespace amBXLib.Net.Helpers
{
  public class Colour
  {
    public ConstrainedUnit Red { get; }
    public ConstrainedUnit Green { get; }
    public ConstrainedUnit Blue { get; }

    public Colour(float red, float green, float blue)
    {
      Red = new ConstrainedUnit(red);
      Green = new ConstrainedUnit(green);
      Blue = new ConstrainedUnit(blue);
    }
  }
}
