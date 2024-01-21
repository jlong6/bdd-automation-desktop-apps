using SpecFlowBDD.Drivers;

namespace SpecFlowBDD.Interactions
{
    internal class ClickItem : DriverSession
    {
        public static void ClickButton(string buttonName) => session.FindElementByName(buttonName).Click();
    }
}
