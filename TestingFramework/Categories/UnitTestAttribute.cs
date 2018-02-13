

using System;
using System.ComponentModel;
using Xunit.Sdk;

namespace TestingFramework.Categories
{
    /// <summary>
    ///     A test that only tests an individual method of a class.
    /// </summary>
    [TraitDiscoverer(UnitTestDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class UnitTestAttribute : Attribute, ITraitAttribute
    {
        public UnitTestAttribute()
        {

        }

        public UnitTestAttribute(string name)
        {
            this.Identifier = name;
        }

        public UnitTestAttribute(long id)
        {
            this.Identifier = id.ToString();
        }

        public string Identifier { get; private set; }

    }
}