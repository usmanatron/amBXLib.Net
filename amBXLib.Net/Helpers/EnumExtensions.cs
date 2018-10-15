using System;

namespace amBXLib.Net.Helpers
{
  // https://weblogs.asp.net/stefansedich/enum-with-string-values-in-c
  static class EnumExtensions
  {
    /// <summary>
    /// Will get the string value for a given enums value, which will
    /// only work if you assign the StringValue attribute to
    /// the items in your enum.
    /// </summary>
    public static string GetStringValue(this Enum value)
    {
      var fieldInfo = value
        .GetType()
        .GetField(value.ToString());

      var attribs = fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];

      return attribs.Length > 0 ? attribs[0].StringValue : null;
    }
  }
}
