using NUnit.Framework;
using NCRAssignment.Driver;
using NUnit.Framework.Interfaces;


namespace NCRAssignment.Helpers
{
    public class Base
    {
        [SetUp]
        public static void BeforeScenario()
        {
            WebDriver.Initialize();
        }

        [TearDown]
        public static void AfterScenario()
        {
            WebDriver.Cleanup();
        }

        public static bool TestCompletedWithoutErrors()
        {
            return TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Inconclusive) ||
                   TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Success);
        }
    }
}

