namespace amBXLib.Net.Exceptions
{
  public class NotInstalledException : amBXException
  {
    public NotInstalledException() : base(amBXOperationResult.amBXNotInstalled, "amBX is not installed.")
    {
    }

  }
}