using System.ComponentModel;

namespace TestingFramework.Categories
{
    /// <summary>
    ///     A test that exercises database objects.
    /// </summary>
    internal class DatabaseTestAttribute : CategoryAttribute
    {
        internal DatabaseTestAttribute()
            : base("Database")
        {
        }
    }
}