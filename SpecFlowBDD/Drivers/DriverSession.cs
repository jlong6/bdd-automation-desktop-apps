using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using SpecFlowBDD.Features.Calculator;
using System.Diagnostics;

namespace SpecFlowBDD.Drivers
{
    public class DriverSession : DriverTemplate
    {
        public static IConfiguration AppSettings
        {
            get 
            {
                IConfiguration configurationBuilder = new ConfigurationBuilder()
                    .AddJsonFile("AppSettings.json")
                    .AddEnvironmentVariables()
                    .Build();

                return configurationBuilder;
            }
        }

        public static void LaunchApplicaton(string appExePath)
        {
            KillApplication(appExePath);

            string appKey = "app";
            string exeName = Path.GetFileNameWithoutExtension(appExePath);
            string testServerValue = "http://127.0.0.1:4723";
            
            var options = new AppiumOptions();
            options.AddAdditionalCapability(appKey, appExePath);
            try { _ = new WindowsDriver<WindowsElement>(new Uri(testServerValue), options); } catch { }

            switch (exeName)
            {
                case "calc":
					SetSessionWindow(AppSettings.GetSection("Applications").GetSection("Calculator")["WindowName"]);
					break;
                case "Notepad":
					SetSessionWindow(AppSettings.GetSection("Applications").GetSection("Notepad")["WindowName"]);
                    break;
			}
		}

        public static void SetSessionWindow(string windowName)
        {
            var desktopCapabilities = new AppiumOptions();
            desktopCapabilities.AddAdditionalCapability("app", "Root");
            WindowsDriver<WindowsElement> desktop = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), desktopCapabilities);

            //  Grab the application window, which is a child of the Desktop window
            var ApplicationWindow = desktop.FindElementByName(windowName);
            ApplicationWindow.Click();
            var ApplicationSessionHandle = ApplicationWindow.GetAttribute("NativeWindowHandle");
            ApplicationSessionHandle = (int.Parse(ApplicationSessionHandle)).ToString("x"); //Convert to hex

            var appCapabilities = new AppiumOptions();
            appCapabilities.AddAdditionalCapability("appTopLevelWindow", ApplicationSessionHandle);
            session = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appCapabilities);
        }

        public static void KillApplication(string appName)
        {
            var processes = Process.GetProcessesByName(appName);
            foreach (var proc in processes)
            {
                proc.Kill();
            }
        }

    }
}
