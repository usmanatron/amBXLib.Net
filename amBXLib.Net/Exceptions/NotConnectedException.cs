namespace amBXLib.Net.Exceptions
{
  public class NotConnectedException : amBXException
  {
    public NotConnectedException() : base(amBX_RESULT.amBX_BAD_ARGS, "The amBXLibrary has not been connected. Please call CONNECT first.")
    {
    }
  }
}