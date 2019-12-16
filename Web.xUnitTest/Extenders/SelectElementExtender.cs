using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Web.AutomatedUITests.Extenders
{
    static class SelectElementExtender
    {
        public static SelectElement FindSelectElementWhenPopulated(this IWebDriver driver, By by, int delayInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(delayInSeconds));
            return wait.Until<SelectElement>(drv =>
            {
                SelectElement element = new SelectElement(drv.FindElement(by));
                if (element.Options.Count >= 2)
                {
                    return element;
                }

                return null;
            }
            );
        }
    }
}
