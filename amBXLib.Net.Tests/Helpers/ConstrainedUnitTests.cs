using amBXLib.Net.Helpers;
using NUnit.Framework;

namespace amBXLib.Net.Tests.Helpers
{
  [TestFixture]
  class ConstrainedUnitTests
  {
    [Test]
    public void ValueLowerThanMinimum_ReturnsMinimum()
    {
      var constrainedUnit = new ConstrainedUnit(-0.5f);

      Assert.AreEqual(constrainedUnit.Min, constrainedUnit.Value);
    }

    [Test]
    public void ValueBetweenLimits_ReturnsUnchanged()
    {
      var val = 0.5f;
      var constrainedUnit = new ConstrainedUnit(val);

      Assert.AreEqual(val, constrainedUnit.Value);
    }

    [Test]
    public void ValueGreaterThanMaximum_ReturnsMaximum()
    {
      var constrainedUnit = new ConstrainedUnit(1.5f);

      Assert.AreEqual(constrainedUnit.Max, constrainedUnit.Value);
    }
  }
}
