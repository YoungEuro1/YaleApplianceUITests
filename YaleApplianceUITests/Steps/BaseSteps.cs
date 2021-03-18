using YaleApplianceUITests.Fixtures;

namespace YaleApplianceUITests.Steps
{
    public abstract class BaseSteps : TechTalk.SpecFlow.Steps
    {
        protected static EnvironmentFixture _environmentFixture;

        public BaseSteps()
        {
            _environmentFixture = new EnvironmentFixture();

        }
    }
}
