using System.ComponentModel;

namespace TestingFramework.Categories
{
    /// <summary>
    ///     A test that only tests an individual method of a class.
    /// </summary>
    public class UnitTestAttribute : CategoryAttribute
    {
        public UnitTestAttribute()
            : base("Unit")
        {
        }
    }
}