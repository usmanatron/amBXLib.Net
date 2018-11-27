namespace amBXLib.Net.Exceptions
{
  public class OldVersionException : amBXException
  {


    public OldVersionException() : base(amBXOperationResult.amBXVersionTooOld, "amBX is installed, but is not the right version.")
    {
    }
  }
}