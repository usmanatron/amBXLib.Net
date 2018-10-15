using System;

namespace amBXLib.Net.Helpers
{
  // https://weblogs.asp.net/stefansedich/enum-with-string-values-in-c
  public class StringValueAttribute : Attribute
  {
    public string StringValue { get; protected set; }

    public StringValueAttribute(string value)
    {
      StringValue = value;
    }
  }
}
