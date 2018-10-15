using System.Drawing;

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

    private int ToRgb(ConstrainedUnit colour)
    {
      return (int) (colour.Value * 255);
    }

    public Color ToColour()
    {
      return Color.FromArgb(ToRgb(Red), ToRgb(Green), ToRgb(Blue));
    }
  }
}
