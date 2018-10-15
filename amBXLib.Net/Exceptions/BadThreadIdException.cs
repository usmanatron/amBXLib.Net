namespace amBXLib.Net.Exceptions
{
  public class BadThreadIdException : amBXException
  {
    public BadThreadIdException() : base(amBX_RESULT.amBX_BAD_THREADID, "A thread ID is incorrect or doesn't exist.")
    {
    }
  }
}