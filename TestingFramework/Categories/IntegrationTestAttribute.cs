using System.ComponentModel;

namespace TestingFramework.Categories
{
    /// <summary>
    ///     A test that involves one more methods of various classes in conjunction.
    /// </summary>
    internal class IntegrationTestAttribute : CategoryAttribute
    {
        internal IntegrationTestAttribute()
            : base("Integration")
        {
        }
    }
}