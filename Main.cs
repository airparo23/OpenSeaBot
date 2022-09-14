using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using OpenSeaBot.Collections;
 

namespace OpenSeaBot
{
    public class Main
    {

        [SetUp]
        public void Setup()
        {

            
        }

        [Test]
        public void StartBot()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            var option = new ChromeOptions();

            option.AddExtension(MainPageElements.extensionPath);
            WebDriver webDriver = new ChromeDriver(chromeDriverService, option); 
            webDriver.Manage().Window.Maximize();
            webDriver.SwitchTo().Window(webDriver.WindowHandles[0]);
            MainPageMethods.StartMetamask(webDriver, MainPageElements.getStarted, MainPageElements.importWallet, MainPageElements.noThanks);

            MainPageMethods.LogInMetamask(MainPageElements.word1, MainPageElements.word2, MainPageElements.word3, MainPageElements.word4, MainPageElements.word5, MainPageElements.word6,
                MainPageElements.word7, MainPageElements.word8, MainPageElements.word9, MainPageElements.word10, MainPageElements.word11, MainPageElements.word12, webDriver);

            webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
            MainPageMethods.ConnectMetamaskToOpenSea(webDriver);
            webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);


            while (true)
            {
                Spellfire.SpellfireCollection(webDriver);
                //друга колекция
                Thread.Sleep(300000); // 5 минути
            }

        }
    }
}