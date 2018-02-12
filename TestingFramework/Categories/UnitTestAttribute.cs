using System.ComponentModel;

namespace TestingFramework.Categories
{
    /// <summary>
    ///     A test that only tests an individual method of a class.
    /// </summary>
    internal class UnitTestAttribute : CategoryAttribute
    {
        internal UnitTestAttribute()
            : base("Unit")
        {
        }
    }
}