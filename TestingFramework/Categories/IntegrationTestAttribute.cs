using System.ComponentModel;

namespace TestingFramework.Categories
{
    /// <summary>
    ///     A test that involves one more methods of various classes in conjunction.
    /// </summary>
    public class IntegrationTestAttribute : CategoryAttribute
    {
        public IntegrationTestAttribute()
            : base("Integration")
        {
        }
    }
}