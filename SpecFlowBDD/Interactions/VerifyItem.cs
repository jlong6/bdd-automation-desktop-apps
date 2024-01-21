using SpecFlowBDD.Drivers;

namespace SpecFlowBDD.Interactions
{
    public class VerifyItem : DriverSession
    {
        public static void VerifyButtonText(string buttonName) => session.FindElementByName(buttonName).Click();
    }
}
