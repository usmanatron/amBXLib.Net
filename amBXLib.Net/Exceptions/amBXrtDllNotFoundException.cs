namespace amBXLib.Net.Exceptions
{
  // ReSharper disable once InconsistentNaming
  public class amBXrtDllNotFoundException : amBXException
  {
    public amBXrtDllNotFoundException() : base(amBXOperationResult.GenericError, "ambxrt.dll not found")
    {
    }
  }
}