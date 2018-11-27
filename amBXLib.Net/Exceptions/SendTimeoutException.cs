namespace amBXLib.Net.Exceptions
{
  public class SendTimeoutException : amBXException
  {


    public SendTimeoutException() : base(amBXOperationResult.SendTimeout, "Request to send script timed out.")
    {
    }
  }
}