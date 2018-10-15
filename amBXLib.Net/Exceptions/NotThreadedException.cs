namespace amBXLib.Net.Exceptions
{
  public class NotThreadedException : amBXException
  {


    public NotThreadedException() : base(amBX_RESULT.amBX_NOT_THREADED, "A threaded function was called, but threading is not enabled.")
    {
    }
  }
}