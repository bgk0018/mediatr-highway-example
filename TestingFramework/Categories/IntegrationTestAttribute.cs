using System;
using System.ComponentModel;
using Xunit;
using Xunit.Sdk;

namespace TestingFramework.Categories
{
    /// <summary>
    ///     A test that involves one more methods of various classes in conjunction.
    /// </summary>
    [TraitDiscoverer(IntegrationTestDiscoverer.DiscovererTypeName, DiscovererUtil.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class IntegrationTestAttribute : Attribute, ITraitAttribute
    {

    }
}