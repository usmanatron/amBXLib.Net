namespace amBXLib.Net.Exceptions
{
  public class UpdateTimeoutException : amBXException
  {
    public UpdateTimeoutException() : base(amBX_RESULT.amBX_UPDATE_TIMEOUT, "Waiting to perform an update timed out.")
    {
    }
  }
}