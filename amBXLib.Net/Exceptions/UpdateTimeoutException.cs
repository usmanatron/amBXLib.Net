namespace amBXLib.Net.Exceptions
{
  public class UpdateTimeoutException : amBXException
  {
    public UpdateTimeoutException() : base(amBXOperationResult.UpdateTimeout, "Waiting to perform an update timed out.")
    {
    }
  }
}