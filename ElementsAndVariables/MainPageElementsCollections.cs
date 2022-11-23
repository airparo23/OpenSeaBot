using OpenQA.Selenium;

namespace OpenSeaBot.ElementsAndVariables
{
    internal static class MainPageElementsCollections
    {
        //ethlizards
        public static By ethlizardNFT = By.XPath("//span[text()='Ethlizards']");
        public static string ethlizardCollection = "https://opensea.io/collection/ethlizards/";
        public static By ethlizardNftToBeClicked = By.XPath("//span[contains(normalize-space(text()), 'Ethlizards #')]");
        


        //vividLimited
        public static By vividLimitedNFT = By.XPath("//span[text()='VividLimited']");
        public static By vividLimitedNftToBeClicked = By.XPath("//span[contains(normalize-space(text()), 'VIVID #')]");
        public static string vividLimitedCollection = "https://opensea.io/collection/vividlimited/";
        public static string vividLimitedCollectionName = "VividLimited";
        public static double initialValueOfferVividLimited;



        //theLobstars
        public static string theLobstarsCollection = "https://opensea.io/collection/thelobstars/";
        public static By theLobstarsNFT = By.XPath("//span[text()='The Lobstars']");
        public static By theLobstarsNftToBeClicked = By.XPath("//span[contains(normalize-space(text()), 'Lobstar #')]");
        public static string theLobstarsCollectionName = "The Lobstars";
        public static double initialValueOfferTheLobstars;



        //mutantGrandpaCountryClub
        public static string mutantGrandpaCountryClubCollection = "https://opensea.io/collection/mutantgrandpacountryclub/";
        public static By mutantGrandpaCountryClubNFT = By.XPath("//span[text()='Mutant Grandpa Country Club']");
        public static By mutantGrandpaCountryClubNftToBeClicked = By.XPath("//span[contains(normalize-space(text()), 'Mutant Grandpa #')]");
        public static string mutantGrandpaCountryClubCollectionName = "Mutant Grandpa Country Club";
        public static double initialValueOfferMutantGrandpaCountryClub;


        //Rubber Duck Bath Party
        public static string rubberDuckBathPartyCollection = "https://opensea.io/collection/rubber-duck-bath-party/";
        public static By rubberDuckBathPartyNFT = By.XPath("//span[text()='Rubber Duck Bath Party']");
        public static By rubberDuckBathPartyNftToBeClicked = By.XPath("//span[contains(normalize-space(text()), 'Duck #')]");
        public static string rubberDuckBathPartyCollectionName = "Rubber Duck Bath Party";
        public static double initialValueOfferRubberDuckBathParty;


        //Retro Arcade Collection
        public static string retroArcadeCollectionCollection = "https://opensea.io/collection/retro-arcade-collection/";
        public static By retroArcadeCollectionNFT = By.XPath("//span[text()='Retro Arcade Collection']");
        public static By retroArcadeCollectionNftToBeClicked = By.XPath("//span[contains(normalize-space(text()), 'Gen 2.0 Mint Pass')]");
        public static string retroArcadeCollectionCollectionName = "Retro Arcade Collection";
        public static double initialValueRetroArcadeCollection;


        //Antonym: GENESIS
        public static string antonymGENESISCollection = "https://opensea.io/collection/antonymgenesis/";
        public static By antonymGENESISNFT = By.XPath("//span[text()='Antonym: GENESIS']");
        public static By antonymGENESISNftToBeClicked = By.XPath("//span[contains(normalize-space(text()), 'Antonym: Genesis #')]");
        public static string antonymGENESISCollectionName = "Antonym: GENESIS";
        public static double initialValueAntonymGENESIS;


        //AINightbirds
        public static string AINightbirdsCollection = "https://opensea.io/collection/ainightbirds/";
        public static By AINightbirdsNFT = By.XPath("//span[text()='AINightbirds']");
        public static By AINightbirdsftToBeClicked = By.XPath("//span[contains(normalize-space(text()), 'MBAI #')]");
        public static string AINightbirdsCollectionName = "AINightbirds";
        public static double initialValueAINightbirds;


        //Children of Ukiyo
        public static string childrenofUkiyoCollection = "https://opensea.io/collection/childrenofukiyoofficial/";
        public static By childrenofUkiyoNFT = By.XPath("//span[text()='Children of Ukiyo']");
        public static By childrenofUkiyoToBeClicked = By.XPath("//span[contains(normalize-space(text()), 'Child of Ukiyo #')]");
        public static string childrenofUkiyoCollectionName = "Children of Ukiyo";
        public static double initialValuechildrenofUkiyo;


        //Flower Lolita Collections
        public static string flowerLolitaCollectionsCollection = "https://opensea.io/collection/flowerlolita-collections/";
        public static By flowerLolitaCollectionsNFT = By.XPath("//span[text()='Flower Lolita Collections']");
        public static By flowerLolitaCollectionsToBeClicked = By.XPath("//span[contains(normalize-space(text()), 'Flower Lolita #')]");
        public static string flowerLolitaCollectionsCollectionName = "Flower Lolita Collections";
        public static double initialValueFlowerLolitaCollections;


        //The Mekabots
        public static string theMekabotsCollection = "https://opensea.io/collection/themekabots/";
        public static By theMekabotsNFT = By.XPath("//span[text()='The Mekabots']");
        public static By theMekabotsToBeClicked = By.XPath("//span[contains(normalize-space(text()), 'MekaBot #')]");
        public static string theMekabotsCollectionName = "The Mekabots";
        public static double initialValuetheMekabots;


        //Girlies NFT
        public static string girliesNFTCollection = "https://opensea.io/collection/girlies-nft/";
        public static By girliesNFTNFT = By.XPath("//span[text()='Girlies NFT']");
        public static By girliesNFTToBeClicked = By.XPath("//span[contains(normalize-space(text()), 'Girlie #')]");
        public static string girliesNFTCollectionName = "Girlies NFT";
        public static double initialValueGirliesNFT;


        //Japanese Born Ape Society
        public static string japaneseBornApeSocietyCollection = "https://opensea.io/collection/japanesebornapesociety/";
        public static By japaneseBornApeSocietyNFT = By.XPath("//span[text()='Japanese Born Ape Society']");
        public static By japaneseBornApeSocietyToBeClicked = By.XPath("//span[contains(normalize-space(text()), 'Japanese Born Ape Society #')]");
        public static string japaneseBornApeSocietyCollectionName = "Japanese Born Ape Society";
        public static double initialValuejapaneseBornApeSociety;

        //--
        //Chains NFT
        public static string chainsNFTCollection = "https://opensea.io/collection/chainsnft/";
        public static By chainsNFTNFT = By.XPath("//span[text()='Chains NFT']");
        public static By chainsNFTToBeClicked = By.XPath("//span[contains(normalize-space(text()), 'Chains NFT #')]");
        public static string chainsNFTCollectionName = "Chains NFT";
        public static double initialValueChainsNFT;

        //TheWhitelist.io - Aces
        public static string theWhitelistioAcesCollection = "https://opensea.io/collection/thewhitelistioaces/";
        public static By theWhitelistioAcesNFT = By.XPath("//span[text()='TheWhitelist.io - Aces']");
        public static By theWhitelistioAcesToBeClicked = By.XPath("//span[contains(normalize-space(text()), 'Ace #')]");
        public static string theWhitelistioAcesCollectionName = "TheWhitelist.io - Aces";
        public static double initialValuetheWhitelistioAces;

        //Karafuru x HYPEBEAST x atmos
        public static string karafuruxHYPEBEASTxatmosCollection = "https://opensea.io/collection/karafuru-x-hypebeast-x-atmos/";
        public static By karafuruxHYPEBEASTxatmosNFT = By.XPath("//span[text()='Karafuru x HYPEBEAST x atmos']");
        public static By karafuruxHYPEBEASTxatmosToBeClicked = By.XPath("//span[contains(normalize-space(text()), 'Egao #')]");
        public static string karafuruxHYPEBEASTxatmosCollectionName = "Karafuru x HYPEBEAST x atmos";
        public static double initialValueKarafuruxHYPEBEASTxatmos;

        //Creepz Reptile Armoury
        public static string creepzReptileArmouryCollection = "https://opensea.io/collection/reptile-armoury/";
        public static By creepzReptileArmouryNFT = By.XPath("//span[text()='Creepz Reptile Armoury']");
        public static By creepzReptileArmouryToBeClicked = By.XPath("//span[contains(normalize-space(text()), 'Reptile Armoury #')]");
        public static string creepzReptileArmouryCollectionName = "Creepz Reptile Armoury";
        public static double initialValueCreepzReptileArmoury;

        //Culture Cubs Official
        public static string cultureCubsOfficialCollection = "https://opensea.io/collection/culturecubs-official/";
        public static By cultureCubsOfficialNFT = By.XPath("//span[text()='Culture Cubs Official']");
        public static By cultureCubsOfficialToBeClicked = By.XPath("//span[contains(normalize-space(text()), 'Culture Cub #')]");
        public static string cultureCubsOfficialCollectionName = "Culture Cubs Official";
        public static double initialValueCultureCubsOfficial;

        //ILikeYouYoureWeird
        public static string iLikeYouYoureWeirdCollection = "https://opensea.io/collection/ilyyw/";
        public static By iLikeYouYoureWeirdNFT = By.XPath("//span[text()=\"I Like You, You're Weird\"]");
        public static By iLikeYouYoureWeirdToBeClicked = By.XPath("//span[contains(normalize-space(text()), 'Weirdo #')]");
        public static string iLikeYouYoureWeirdCollectionName = "I Like You, You're Weird";
        public static double initialValueiLikeYouYoureWeird;

        //WulfBoySocialClub
        public static string wulfBoySocialClubCollection = "https://opensea.io/collection/wulfboysocialclub/";
        public static By wulfBoySocialClubNFT = By.XPath("//span[text()='WulfBoySocialClub']");
        public static By wulfBoySocialClubToBeClicked = By.XPath("//span[contains(normalize-space(text()), 'Wulf Boy #')]");
        public static string wulfBoySocialClubCollectionName = "WulfBoySocialClub";
        public static double initialValuewulfBoySocialClub;

        //The Psychonaut Ape Division
        public static string thePsychonautApeDivisionCollection = "https://opensea.io/collection/psychonautapedivision/";
        public static By thePsychonautApeDivisionNFT = By.XPath("//span[text()='The Psychonaut Ape Division']");
        public static By thePsychonautApeDivisionToBeClicked = By.XPath("//span[contains(normalize-space(text()), 'Psychonaut Ape Division #')]");
        public static string thePsychonautApeDivisionCollectionName = "The Psychonaut Ape Division";
        public static double initialValueThePsychonautApeDivision;

        //Little Lemon Friends
        public static string littleLemonFriendsCollection = "https://opensea.io/collection/little-lemon-friends";
        public static By littleLemonFriendsNFT = By.XPath("//span[text()='Little Lemon Friends']");
        public static By littleLemonFriendsToBeClicked = By.XPath("//span[contains(normalize-space(text()), 'Little Lemon #')]");
        public static string littleLemonFriendsCollectionName = "Little Lemon Friends";
        public static double initialValueLittleLemonFriends;

    }
}
