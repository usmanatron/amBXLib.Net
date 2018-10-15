namespace amBXLib.Net.Exceptions
{
  public class SendTimeoutException : amBXException
  {


    public SendTimeoutException() : base(amBX_RESULT.amBX_SENDING_TIMEOUT, "Request to send script timed out.")
    {
    }
  }
}