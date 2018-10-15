namespace amBXLib.Net.Exceptions
{
  public class NoSpaceException : amBXException
  {
    public NoSpaceException() : base(amBX_RESULT.amBX_NO_SPACE, "Out of buffer space")
    {
    }
  }
}