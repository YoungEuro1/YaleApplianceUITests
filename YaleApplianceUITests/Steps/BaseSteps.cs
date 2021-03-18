using YaleApplianceUITests.Fixtures;

namespace YaleApplianceUITests.Steps
{
    public abstract class BaseSteps : TechTalk.SpecFlow.Steps
    {
        protected static EnvironmentFixture EnvironmentFixture;

        public BaseSteps()
        {
            EnvironmentFixture = new EnvironmentFixture();

        }
    }
}
