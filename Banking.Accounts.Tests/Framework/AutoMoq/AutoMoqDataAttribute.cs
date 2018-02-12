using AutoFixture;
using AutoFixture.Xunit2;

namespace Banking.Accounts.Tests.Framework.AutoMoq
{
    internal class AutoMoqDataAttribute : AutoDataAttribute
    {
        internal AutoMoqDataAttribute()
            : base(() =>
            {
                var fixture = new Fixture();

                //fixture.Customizations.Add(new PropertyTypeOmitter(typeof(DataTextBase)));
                //fixture.Customize(new SuiteCustomizations());

                ////Some classes we depend on have circular references
                //fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => fixture.Behaviors.Remove(b));
                //fixture.Behaviors.Add(new OmitOnRecursionBehavior());

                return fixture;
            })
        {
        }
    }
}