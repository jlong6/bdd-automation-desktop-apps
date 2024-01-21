using SpecFlowBDD.Drivers;
using SpecFlowBDD.Interactions;

namespace SpecFlowBDD.StepDefinitions
{
    [Binding]
    public class SharedStepDefinitions : DriverSession
    {
        [Given("I start application Calculator")]
        public static void GivenIStartApplicationCalculator()
        {			
            LaunchApplicaton(AppSettings.GetSection("Applications").GetSection("Calculator")["AppPath"]);
        }

		[Given("I start application Notepad")]
		public static void GivenIStartApplicationNotepad()
		{
			LaunchApplicaton(AppSettings.GetSection("Applications").GetSection("Notepad")["AppPath"]);
		}

		[Given("I click button \"(.*)\"")]
        public static void GivenIClickButton(string buttonName)
        {
            ClickItem.ClickButton(buttonName);
        }
    }
}