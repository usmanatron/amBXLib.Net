namespace amBXLib.Net.Exceptions
{
  public class BadArgsException : amBXException
  {
    public BadArgsException() : base(amBX_RESULT.amBX_BAD_ARGS, "Bad argument detected (usually a null pointer).")
    {
    }
  }
}