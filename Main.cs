using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenSeaBot.Collections;
using OpenSeaBot.ElementsAndVariables;
using OpenSeaBot.Methods;
using System.Collections;

namespace OpenSeaBot
{
    public class Main
    {

        [SetUp]
        public void Setup()
        {

            
        }

        [Test]
        public async Task StartBot()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            var option = new ChromeOptions();

            option.AddExtension(MainPageElements.extensionPath);
            WebDriver webDriver = new ChromeDriver(chromeDriverService, option); 
            webDriver.Manage().Window.Maximize();
            MainPageMethods.StartMetamask(webDriver, MainPageElements.getStarted, MainPageElements.importWallet, MainPageElements.noThanks);
            MainPageMethods.LogInMetamask(MainPageElements.word1, MainPageElements.word2, MainPageElements.word3, MainPageElements.word4, MainPageElements.word5, MainPageElements.word6,
                MainPageElements.word7, MainPageElements.word8, MainPageElements.word9, MainPageElements.word10, MainPageElements.word11, MainPageElements.word12, webDriver);
            MainPageMethods.ConnectMetamaskToOpenSea(webDriver);

            await startTimer(webDriver);
        }

        public async Task startTimer(WebDriver webDriver)
        {
            var timer = new PeriodicTimer(TimeSpan.FromSeconds(10));

            while (await timer.WaitForNextTickAsync())
            {
                /*VividLimited.VividLimitedCollection(webDriver, MainPageElementsCollections.vividLimitedNFT, MainPageElementsCollections.vividLimitedNftToBeClicked,
                    MainPageElementsCollections.vividLimitedCollection, MainPageElementsCollections.vividLimitedCollectionName, 7.5, 5, 
                    MainPageElementsCollections.initialValueOfferVividLimited);*/
                try {
                    MutantGrandpaCountryClub.MutantGrandpaCountryClubCollection(
                        webDriver, 
                        MainPageElementsCollections.mutantGrandpaCountryClubNFT,
                        MainPageElementsCollections.mutantGrandpaCountryClubNftToBeClicked,
                        MainPageElementsCollections.mutantGrandpaCountryClubCollection,
                        7.5,
                        5);
                }
                catch {
                    // throw new Exception(String.Format("Нещо се счупи в {0} в {1}!", MainPageElementsCollections.mutantGrandpaCountryClubCollectionName, DateTime.Now));
                    //MainPageMethods.GoToCollection(webDriver, MainPageElements.myAccountUrl);
                    //TestContext.Progress.WriteLine("Нещо се счупи в {0} в {1}!", CollectionName, DateTime.Now);
                }
            }
                

                /*TheLobstars.TheLobstarsCollection(webDriver, MainPageElementsCollections.theLobstarsNFT, MainPageElementsCollections.theLobstarsNftToBeClicked,
                    MainPageElementsCollections.theLobstarsCollection, MainPageElementsCollections.theLobstarsCollectionName, 7.5, 5, 
                    MainPageElementsCollections.initialValueOfferTheLobstars);*/
            
        }
    }
}