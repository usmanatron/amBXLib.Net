namespace amBXLib.Net.Exceptions
{
  public class NotConnectedException : amBXException
  {
    public NotConnectedException() : base(amBXOperationResult.BadArguments, "The amBXLibrary has not been connected. Please call CONNECT first.")
    {
    }
  }
}