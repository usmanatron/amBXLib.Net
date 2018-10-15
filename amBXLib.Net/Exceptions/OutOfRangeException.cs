namespace amBXLib.Net.Exceptions
{
  public class OutOfRangeException : amBXException
  {


    public OutOfRangeException() : base(amBX_RESULT.amBX_OUT_OF_RANGE, "Argument out of range.")
    {
    }
  }
}