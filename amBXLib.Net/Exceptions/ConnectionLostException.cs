namespace amBXLib.Net.Exceptions
{
  public class ConnectionLostException : amBXException
  {


    public ConnectionLostException() : base(amBXOperationResult.EngineLost, "Connection to amBX has been lost.")
    {
    }
  }
}