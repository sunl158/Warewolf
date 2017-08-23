﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Warewolf.Web.UI.Tests.BrowserWebDrivers
{
    public class ChromeIncognitoWebDriver : BaseWebDriver
    {
        public ChromeIncognitoWebDriver() : base(new ChromeDriver(capabilities))
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(new[] { "--test-type" });
            chromeOptions.AddArgument("start-maximized");
            DesiredCapabilities capabilities = DesiredCapabilities.Chrome();
            capabilities.SetCapability("chrome.switches", new[] { "--incognito" });
            capabilities.SetCapability(ChromeOptions.Capability, chromeOptions);
            Manage().Cookies.AddCookie(new Cookie("baseUrl", baseURL));
        }
    }
}
