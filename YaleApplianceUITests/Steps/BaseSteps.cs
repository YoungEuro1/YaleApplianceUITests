using YaleApplianceUITests.Fixtures;

namespace YaleApplianceUITests.Steps
{
    public abstract class BaseSteps : TechTalk.SpecFlow.Steps
    {
        protected static EnvironmentFixture EnvironmentFixture;

        protected BaseSteps()
        {
            EnvironmentFixture = new EnvironmentFixture();

        }
    }
}
