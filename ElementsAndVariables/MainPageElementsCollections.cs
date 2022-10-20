using OpenQA.Selenium;

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
        public static bool isVividLimitedProfitable = true;
        public static double isVividLimitedProfitableCounter = 0;


        //theLobstars
        public static string theLobstarsCollection = "https://opensea.io/collection/thelobstars";
        public static By theLobstarsNFT = By.XPath("//div[text()='The Lobstars']");
        public static By theLobstarsNftToBeClicked = By.XPath("//div[contains(normalize-space(text()), 'Lobstar #')]");
        public static string theLobstarsCollectionName = "The Lobstars";
        public static double initialValueOfferTheLobstars;
        public static bool isTheLobstarsProfitable = true;
        public static double isTheLobstarsProfitableCounter = 0;


        //mutantGrandpaCountryClub
        public static string mutantGrandpaCountryClubCollection = "https://opensea.io/collection/mutantgrandpacountryclub";
        public static By mutantGrandpaCountryClubNFT = By.XPath("//div[text()='Mutant Grandpa Country Club']");
        public static By mutantGrandpaCountryClubNftToBeClicked = By.XPath("//div[contains(normalize-space(text()), 'Mutant Grandpa #')]");
        public static string mutantGrandpaCountryClubCollectionName = "Mutant Grandpa Country Club";
        public static double initialValueOfferMutantGrandpaCountryClub;
        public static bool isMutantGrandpaCountryClubProfitable = true;
        public static double isMutantGrandpaCountryClubProfitableCounter = 0;

        //Rubber Duck Bath Party
        public static string rubberDuckBathPartyCollection = "https://opensea.io/collection/rubber-duck-bath-party";
        public static By rubberDuckBathPartyNFT = By.XPath("//div[text()='Rubber Duck Bath Party']");
        public static By rubberDuckBathPartyNftToBeClicked = By.XPath("//div[contains(normalize-space(text()), 'Duck #')]");
        public static string rubberDuckBathPartyCollectionName = "Rubber Duck Bath Party";
        public static double initialValueOfferRubberDuckBathParty;
        public static bool isRubberDuckBathPartyProfitable = true;
        public static double isRubberDuckBathPartyProfitableCounter = 0;

        //Retro Arcade Collection
        public static string retroArcadeCollectionCollection = "https://opensea.io/collection/retro-arcade-collection";
        public static By retroArcadeCollectionNFT = By.XPath("//div[text()='Retro Arcade Collection']");
        public static By retroArcadeCollectionNftToBeClicked = By.XPath("//div[contains(normalize-space(text()), 'Gen 2.0 Mint Pass')]");
        public static string retroArcadeCollectionCollectionName = "Retro Arcade Collection";
        public static double initialValueRetroArcadeCollection;
        public static bool isRetroArcadeCollectionProfitable = true;
        public static double isRetroArcadeCollectionProfitableCounter = 0;

        //Antonym: GENESIS
        public static string antonymGENESISCollection = "https://opensea.io/collection/antonymgenesis";
        public static By antonymGENESISNFT = By.XPath("//div[text()='Antonym: GENESIS']");
        public static By antonymGENESISNftToBeClicked = By.XPath("//div[contains(normalize-space(text()), 'Antonym: Genesis #')]");
        public static string antonymGENESISCollectionName = "Antonym: GENESIS";
        public static double initialValueAntonymGENESIS;
        public static bool isAntonymGENESISProfitable = true;
        public static double isAntonymGENESISProfitableCounter = 0;

        //AINightbirds
        public static string AINightbirdsCollection = "https://opensea.io/collection/ainightbirds";
        public static By AINightbirdsNFT = By.XPath("//div[text()='AINightbirds']");
        public static By AINightbirdsftToBeClicked = By.XPath("//div[contains(normalize-space(text()), 'MBAI #')]");
        public static string AINightbirdsCollectionName = "AINightbirds";
        public static double initialValueAINightbirds;
        public static bool isAINightbirdsProfitable = true;
        public static double isAINightbirdsProfitableCounter = 0;

        //Children of Ukiyo
        public static string childrenofUkiyoCollection = "https://opensea.io/collection/childrenofukiyoofficial";
        public static By childrenofUkiyoNFT = By.XPath("//div[text()='Children of Ukiyo']");
        public static By childrenofUkiyoToBeClicked = By.XPath("//div[contains(normalize-space(text()), 'Child of Ukiyo #')]");
        public static string childrenofUkiyoCollectionName = "Children of Ukiyo";
        public static double initialValuechildrenofUkiyo;
        public static bool isChildrenofUkiyoProfitable = true;
        public static double isChildrenofUkiyoProfitableCounter = 0;

        //Flower Lolita Collections
        public static string flowerLolitaCollectionsCollection = "https://opensea.io/collection/flowerlolita-collections";
        public static By flowerLolitaCollectionsNFT = By.XPath("//div[text()='Flower Lolita Collections']");
        public static By flowerLolitaCollectionsToBeClicked = By.XPath("//div[contains(normalize-space(text()), 'Flower Lolita #')]");
        public static string flowerLolitaCollectionsCollectionName = "Flower Lolita Collections";
        public static double initialValueFlowerLolitaCollections;
        public static bool isFlowerLolitaCollectionsProfitable = true;
        public static double isFlowerLolitaCollectionsProfitableCounter = 0;

        //The Mekabots
        public static string theMekabotsCollection = "https://opensea.io/collection/themekabots";
        public static By theMekabotsNFT = By.XPath("//div[text()='The Mekabots']");
        public static By theMekabotsToBeClicked = By.XPath("//div[contains(normalize-space(text()), 'MekaBot #')]");
        public static string theMekabotsCollectionName = "The Mekabots";
        public static double initialValuetheMekabots;
        public static bool isTheMekabotsProfitable = true;
        public static double isTheMekabotsProfitableCounter = 0;

        //Girlies NFT
        public static string girliesNFTCollection = "https://opensea.io/collection/girlies-nft";
        public static By girliesNFTNFT = By.XPath("//div[text()='Girlies NFT']");
        public static By girliesNFTToBeClicked = By.XPath("//div[contains(normalize-space(text()), 'Girlie #')]");
        public static string girliesNFTCollectionName = "Girlies NFT";
        public static double initialValueGirliesNFT;
        public static bool isGirliesNFTProfitable = true;
        public static double isGirliesNFTProfitableCounter = 0;

        //Japanese Born Ape Society
        public static string japaneseBornApeSocietyCollection = "https://opensea.io/collection/japanesebornapesociety";
        public static By japaneseBornApeSocietyNFT = By.XPath("//div[text()='Japanese Born Ape Society']");
        public static By japaneseBornApeSocietyToBeClicked = By.XPath("//div[contains(normalize-space(text()), 'Japanese Born Ape Society #')]");
        public static string japaneseBornApeSocietyCollectionName = "Japanese Born Ape Society";
        public static double initialValuejapaneseBornApeSociety;
        public static bool isJapaneseBornApeSocietyProfitable = true;
        public static double isJapaneseBornApeSocietyProfitableCounter = 0;
















    }
}
