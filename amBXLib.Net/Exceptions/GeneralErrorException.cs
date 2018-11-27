namespace amBXLib.Net.Exceptions
{
  public class GeneralErrorException : amBXException
  {
    public GeneralErrorException() : base(amBXOperationResult.GenericError, "General Failure:")
    {
    }
  }
}