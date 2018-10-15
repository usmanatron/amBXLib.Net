using System;

namespace amBXLib.Net.Exceptions
{
  /// <summary>
  /// Base amBX Exception
  /// </summary>
  public class amBXException : Exception
  {
    public amBX_RESULT ErrorNumber { get; }

    public amBXException(amBX_RESULT errorNumber, string message) : base(message)
    {
      ErrorNumber = errorNumber;
    }
  }
}
