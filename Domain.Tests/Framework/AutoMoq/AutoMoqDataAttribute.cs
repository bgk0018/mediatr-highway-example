using AutoFixture;
using AutoFixture.Xunit2;
using Domain.Tests.Framework.Customizations;

namespace Domain.Tests.Framework.AutoMoq
{
    internal class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(() =>
            {
                var fixture = new Fixture().Customize(new SuiteCustomizations());

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