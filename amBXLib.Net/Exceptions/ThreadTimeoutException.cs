namespace amBXLib.Net.Exceptions
{
  public class ThreadTimeoutException : amBXException
  {


    public ThreadTimeoutException() : base(amBXOperationResult.ThreadTimeout, "Request to run a thread timed out.")
    {
    }
  }
}