namespace amBXLib.Net.Exceptions
{
  public class BadArgsException : amBXException
  {
    public BadArgsException() : base(amBXOperationResult.BadArguments, "Bad argument detected (usually a null pointer).")
    {
    }
  }
}