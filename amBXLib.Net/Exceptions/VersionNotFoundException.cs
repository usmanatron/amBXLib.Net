namespace amBXLib.Net.Exceptions
{
  public class VersionNotFoundException : amBXException
  {
    public VersionNotFoundException()
      : base(amBXOperationResult.amBXVersionNotFound, "Expected version of amBX API not found.")
    {
    }
  }
}