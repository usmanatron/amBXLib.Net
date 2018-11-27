namespace amBXLib.Net.Exceptions
{
  public class ThreadExistsException : amBXException
  {


    public ThreadExistsException() : base(amBXOperationResult.ThreadExists, "A thread is currently being used for the requested function.")
    {
    }
  }
}