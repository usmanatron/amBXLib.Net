namespace amBXLib.Net.Exceptions
{
  public class ThreadExistsException : amBXException
  {


    public ThreadExistsException() : base(amBX_RESULT.amBX_THREAD_EXISTS, "A thread is currently being used for the requested function.")
    {
    }
  }
}