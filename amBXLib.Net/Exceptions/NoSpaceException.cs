namespace amBXLib.Net.Exceptions
{
  public class NoSpaceException : amBXException
  {
    public NoSpaceException() : base(amBXOperationResult.NoSpace, "Out of buffer space")
    {
    }
  }
}