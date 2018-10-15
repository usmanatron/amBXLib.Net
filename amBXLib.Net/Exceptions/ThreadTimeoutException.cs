namespace amBXLib.Net.Exceptions
{
  public class ThreadTimeoutException : amBXException
  {


    public ThreadTimeoutException() : base(amBX_RESULT.amBX_THREAD_TIMEOUT, "Request to run a thread timed out.")
    {
    }
  }
}