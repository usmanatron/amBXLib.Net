namespace amBXLib.Net.Exceptions
{
  public class amBXrtDllNotFoundException : amBXException
  {
    public amBXrtDllNotFoundException() : base(amBX_RESULT.amBX_ERROR, "ambxrt.dll not found")
    {
    }
  }
}