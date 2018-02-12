using System.ComponentModel;

namespace TestingFramework.Categories
{
    /// <summary>
    ///     A test that depends on or modifies state of a resource outside the confines of the test.
    /// </summary>
    internal class StatefulTestAttribute : CategoryAttribute
    {
        internal StatefulTestAttribute()
            : base("Stateful")
        {
        }
    }
}