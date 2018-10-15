namespace amBXLib.Net.Exceptions
{
  public class ConnectionLostException : amBXException
  {


    public ConnectionLostException() : base(amBX_RESULT.amBX_ENGINE_LOST, "Connection to amBX has been lost.")
    {
    }
  }
}