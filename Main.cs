using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using OpenSeaBot.Collections;
using OpenSeaBot.ElementsAndVariables;
using OpenSeaBot.Methods;

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
            MainPageMethods.StartMetamask(webDriver, MainPageElements.getStarted, MainPageElements.importWallet, MainPageElements.noThanks);
            MainPageMethods.LogInMetamask(MainPageElements.word1, MainPageElements.word2, MainPageElements.word3, MainPageElements.word4, MainPageElements.word5, MainPageElements.word6,
                MainPageElements.word7, MainPageElements.word8, MainPageElements.word9, MainPageElements.word10, MainPageElements.word11, MainPageElements.word12, webDriver);
            MainPageMethods.ConnectMetamaskToOpenSea(webDriver);

            while(true)
            {               
                VividLimited.VividLimitedCollection(webDriver, MainPageElementsCollections.vividLimitedNFT, MainPageElementsCollections.vividLimitedNftToBeClicked,
                    MainPageElementsCollections.vividLimitedCollection, MainPageElementsCollections.vividLimitedCollectionName, 7.5, 5,
                    MainPageElementsCollections.myPreviousOfferNumberVividLimited);

                MutantGrandpaCountryClub.MutantGrandpaCountryClubCollection(webDriver, MainPageElementsCollections.mutantGrandpaCountryClubNFT, 
                    MainPageElementsCollections.mutantGrandpaCountryClubNftToBeClicked,
                    MainPageElementsCollections.mutantGrandpaCountryClubCollection, MainPageElementsCollections.mutantGrandpaCountryClubCollectionName, 7.5, 5,
                    MainPageElementsCollections.myPreviousOfferNumberMutantGrandpaCountryClub);

                TheLobstars.TheLobstarsCollection(webDriver, MainPageElementsCollections.theLobstarsNFT, MainPageElementsCollections.theLobstarsNftToBeClicked,
                    MainPageElementsCollections.theLobstarsCollection, MainPageElementsCollections.theLobstarsCollectionName, 7.5, 5,
                    MainPageElementsCollections.myPreviousOfferNumberTheLobstars);

                Thread.Sleep(1000); // 5 минути - 300000
            }

        }
    }
}