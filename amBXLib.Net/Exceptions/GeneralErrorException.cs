namespace amBXLib.Net.Exceptions
{
  public class GeneralErrorException : amBXException
  {
    public GeneralErrorException() : base(amBX_RESULT.amBX_ERROR, "General Failure:")
    {
    }
  }
}