namespace amBXLib.Net.Exceptions
{
  public class OutOfRangeException : amBXException
  {


    public OutOfRangeException() : base(amBXOperationResult.OutOfRange, "Argument out of range.")
    {
    }
  }
}