using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenSeaBot.ElementsAndVariables;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSeaBot.BurnerWallets
{
    internal static class Seeds
    {
        public static void LogInMetamaskBurner1(By word1, By word2, By word3, By word4, By word5, By word6, By word7, By word8,
            By word9, By word10, By word11, By word12, WebDriver webDriver)
        {
            WaitForAnElementToShow(webDriver, MainPageElements.word1);

            string[] pass = { "hazard", "clog", "glow", "shoe", "knock", "safe", "capable", "cement", "custom", "glad", "know", "pluck" };
            By[] passFields = { word1, word2, word3, word4, word5, word6, word7, word8, word9, word10, word11, word12 };
            int i = 0;
            int j = 0;
            for (; i < pass.Length; i++, j++)
            {
                webDriver.FindElement(passFields[i]).SendKeys(pass[j]);
            }

            webDriver.FindElement(MainPageElements.password).SendKeys("paromaro");
            webDriver.FindElement(MainPageElements.passwordConfirm).SendKeys("paromaro");
            ClickTermsOfUseButton(webDriver, MainPageElements.termsOfUse);
            webDriver.FindElement(MainPageElements.import).Click();
            WaitForAnElementToShow(webDriver, MainPageElements.allDone);

            webDriver.FindElement(MainPageElements.allDone).Click();
            webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
        }

        public static void LogInMetamaskBurner2(By word1, By word2, By word3, By word4, By word5, By word6, By word7, By word8,
           By word9, By word10, By word11, By word12, WebDriver webDriver)
        {
            WaitForAnElementToShow(webDriver, MainPageElements.word1);

            string[] pass = { "entire", "fury", "calm", "useful", "minor", "list", "decorate", "reunion", "need", "welcome", "market", "boss" };
            By[] passFields = { word1, word2, word3, word4, word5, word6, word7, word8, word9, word10, word11, word12 };
            int i = 0;
            int j = 0;
            for (; i < pass.Length; i++, j++)
            {
                webDriver.FindElement(passFields[i]).SendKeys(pass[j]);
            }

            webDriver.FindElement(MainPageElements.password).SendKeys("paromaro");
            webDriver.FindElement(MainPageElements.passwordConfirm).SendKeys("paromaro");
            ClickTermsOfUseButton(webDriver, MainPageElements.termsOfUse);
            webDriver.FindElement(MainPageElements.import).Click();
            WaitForAnElementToShow(webDriver, MainPageElements.allDone);

            webDriver.FindElement(MainPageElements.allDone).Click();
            webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
        }

        public static void WaitForAnElementToShow(WebDriver webDriver, By element)
        {
            WebDriverWait w = new WebDriverWait(webDriver, TimeSpan.FromSeconds(120));
            w.Until(ExpectedConditions.ElementExists(element));
        }

        public static void ClickTermsOfUseButton(WebDriver webDriver, By terms)
        {
            webDriver.FindElement(terms).Click();

        }
    }
}
