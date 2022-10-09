using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSeaBot.ElementsAndVariables
{
    internal static class MainPageElementsCollections
    {
        //ethlizards
        public static By ethlizardNFT = By.XPath("//div[text()='Ethlizards']");
        public static string ethlizardCollection = "https://opensea.io/collection/ethlizards";
        public static By ethlizardNftToBeClicked = By.XPath("//div[contains(normalize-space(text()), 'Ethlizards #')]");
        


        //vividLimited
        public static By vividLimitedNFT = By.XPath("//div[text()='VividLimited']");
        public static By vividLimitedNftToBeClicked = By.XPath("//div[contains(normalize-space(text()), 'VIVID #')]");
        public static string vividLimitedCollection = "https://opensea.io/collection/vividlimited";
        public static string vividLimitedCollectionName = "VividLimited";
        public static double initialValueOfferVividLimited;


        //theLobstars
        public static string theLobstarsCollection = "https://opensea.io/collection/thelobstars";
        public static By theLobstarsNFT = By.XPath("//div[text()='The Lobstars']");
        public static By theLobstarsNftToBeClicked = By.XPath("//div[contains(normalize-space(text()), 'Lobstar #')]");
        public static string theLobstarsCollectionName = "The Lobstars";
        public static double initialValueOfferTheLobstars;


        //mutantGrandpaCountryClub
        public static string mutantGrandpaCountryClubCollection = "https://opensea.io/collection/mutantgrandpacountryclub";
        public static By mutantGrandpaCountryClubNFT = By.XPath("//div[text()='Mutant Grandpa Country Club']");
        public static By mutantGrandpaCountryClubNftToBeClicked = By.XPath("//div[contains(normalize-space(text()), 'Mutant Grandpa #')]");
        public static string mutantGrandpaCountryClubCollectionName = "Mutant Grandpa Country Club";
        public static double initialValueOfferMutantGrandpaCountryClub;


    }
}
