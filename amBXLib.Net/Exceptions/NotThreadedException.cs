namespace amBXLib.Net.Exceptions
{
  public class NotThreadedException : amBXException
  {


    public NotThreadedException() : base(amBXOperationResult.NotThreaded, "A threaded function was called, but threading is not enabled.")
    {
    }
  }
}