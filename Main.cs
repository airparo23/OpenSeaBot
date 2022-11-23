using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenSeaBot.Collections;
using OpenSeaBot.ElementsAndVariables;
using OpenSeaBot.Methods;
using OpenSeaBot.OfferNumber;
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
            var timer = new PeriodicTimer(TimeSpan.FromSeconds(1));

            while (await timer.WaitForNextTickAsync())
            {
                await Task.Delay(9000);

                try
                {
                    ChainsNFT.ChainsNFTCollection(
                        webDriver,
MainPageElementsCollections.chainsNFTNFT,
MainPageElementsCollections.chainsNFTToBeClicked,
MainPageElementsCollections.chainsNFTCollection,
10.5,
5);
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("Нещо се счупи в {0} в {1}!", MainPageElementsCollections.theLobstarsCollectionName, DateTime.Now));
                }

                try
                {
                    CultureCubsOfficial.CultureCubsOfficialCollection(
                                webDriver,
                                MainPageElementsCollections.cultureCubsOfficialNFT,
                                MainPageElementsCollections.cultureCubsOfficialToBeClicked,
                                MainPageElementsCollections.cultureCubsOfficialCollection,
                                10,
                                5);


                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("Нещо се счупи в {0} в {1}!", MainPageElementsCollections.antonymGENESISCollectionName, DateTime.Now));
                }

                try
                {
                    LittleLemonFriends.LittleLemonFriendsCollection(
       webDriver,
       MainPageElementsCollections.littleLemonFriendsNFT,
       MainPageElementsCollections.littleLemonFriendsToBeClicked,
       MainPageElementsCollections.littleLemonFriendsCollection,
       5,
       5);


                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("Нещо се счупи в {0} в {1}!", MainPageElementsCollections.retroArcadeCollectionCollectionName, DateTime.Now));
                }

                try
                {

                    RetroArcadeCollection.RetroArcadeCollectionCollection(
webDriver,
MainPageElementsCollections.retroArcadeCollectionNFT,
MainPageElementsCollections.retroArcadeCollectionNftToBeClicked,
MainPageElementsCollections.retroArcadeCollectionCollection,
5.5,
5);

                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("Нещо се счупи в {0} в {1}!", MainPageElementsCollections.vividLimitedCollectionName, DateTime.Now));
                }

                try
                {
                    ChildrenofUkiyo.ChildrenofUkiyoCollection(
     webDriver,
     MainPageElementsCollections.childrenofUkiyoNFT,
     MainPageElementsCollections.childrenofUkiyoToBeClicked,
     MainPageElementsCollections.childrenofUkiyoCollection,
     10,
     5);
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("Нещо се счупи в {0} в {1}!", MainPageElementsCollections.mutantGrandpaCountryClubCollectionName, DateTime.Now));
                }

                try
                {
                    TheMekabots.TheMekabotsCollection(
                        webDriver,
                        MainPageElementsCollections.theMekabotsNFT,
                        MainPageElementsCollections.theMekabotsToBeClicked,
                        MainPageElementsCollections.theMekabotsCollection,
                        7.5,
                        5);
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("Нещо се счупи в {0} в {1}!", MainPageElementsCollections.rubberDuckBathPartyCollectionName, DateTime.Now));
                }

                try
                {
                    AntonymGENESIS.AntonymGENESISCollection(
                        webDriver,
                        MainPageElementsCollections.antonymGENESISNFT,
                        MainPageElementsCollections.antonymGENESISNftToBeClicked,
                        MainPageElementsCollections.antonymGENESISCollection,
                        10.6,
                        5);
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("Нещо се счупи в {0} в {1}!", MainPageElementsCollections.antonymGENESISCollectionName, DateTime.Now));
                }

                try
                {
                    AINightbirds.AINightbirdsCollection(
              webDriver,
              MainPageElementsCollections.AINightbirdsNFT,
              MainPageElementsCollections.AINightbirdsftToBeClicked,
              MainPageElementsCollections.AINightbirdsCollection,
              7.5,
              5);
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("Нещо се счупи в {0} в {1}!", MainPageElementsCollections.AINightbirdsCollectionName, DateTime.Now));
                }

                try
                {
                    MutantGrandpaCountryClub.MutantGrandpaCountryClubCollection(
webDriver,
MainPageElementsCollections.mutantGrandpaCountryClubNFT,
MainPageElementsCollections.mutantGrandpaCountryClubNftToBeClicked,
MainPageElementsCollections.mutantGrandpaCountryClubCollection,
7.5,
5);
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("Нещо се счупи в {0} в {1}!", MainPageElementsCollections.childrenofUkiyoCollectionName, DateTime.Now));
                }

                try
                {
                    ILikeYouYoureWeird.ILikeYouYoureWeirdCollection(
webDriver,
MainPageElementsCollections.iLikeYouYoureWeirdNFT,
MainPageElementsCollections.iLikeYouYoureWeirdToBeClicked,
MainPageElementsCollections.iLikeYouYoureWeirdCollection,
8.5,
5);
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("Нещо се счупи в {0} в {1}!", MainPageElementsCollections.flowerLolitaCollectionsCollectionName, DateTime.Now));
                }



                try
                {
                    GirliesNFT.GirliesNFTCollection(
                        webDriver,
                        MainPageElementsCollections.girliesNFTNFT,
                        MainPageElementsCollections.girliesNFTToBeClicked,
                        MainPageElementsCollections.girliesNFTCollection,
                        7.5,
                        5);
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("Нещо се счупи в {0} в {1}!", MainPageElementsCollections.girliesNFTCollectionName, DateTime.Now));
                }

                //floor price too high
                /*try
                {
                    JapaneseBornApeSociety.JapaneseBornApeSocietyCollection(
                        webDriver,
                        MainPageElementsCollections.japaneseBornApeSocietyNFT,
                        MainPageElementsCollections.japaneseBornApeSocietyToBeClicked,
                        MainPageElementsCollections.japaneseBornApeSocietyCollection,
                        9.5,
                        5);
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("Нещо се счупи в {0} в {1}!", MainPageElementsCollections.japaneseBornApeSocietyCollectionName, DateTime.Now));
                }*/

                try
                {
                    WulfBoySocialClub.WulfBoySocialClubCollection(
                        webDriver,
                        MainPageElementsCollections.wulfBoySocialClubNFT,
                        MainPageElementsCollections.wulfBoySocialClubToBeClicked,
                        MainPageElementsCollections.wulfBoySocialClubCollection,
                        9.5,
                        5);
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("Нещо се счупи в {0} в {1}!", MainPageElementsCollections.chainsNFTCollectionName, DateTime.Now));
                }

                try
                {
                    TheWhitelistioAces.TheWhitelistioAcesCollection(
                        webDriver,
                        MainPageElementsCollections.theWhitelistioAcesNFT,
                        MainPageElementsCollections.theWhitelistioAcesToBeClicked,
                        MainPageElementsCollections.theWhitelistioAcesCollection,
                        9.5,
                        5);
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("Нещо се счупи в {0} в {1}!", MainPageElementsCollections.theWhitelistioAcesCollectionName, DateTime.Now));
                }

                try
                {
                    KarafuruxHYPEBEASTxatmos.KarafuruxHYPEBEASTxatmosCollection(
                        webDriver,
                        MainPageElementsCollections.karafuruxHYPEBEASTxatmosNFT,
                        MainPageElementsCollections.karafuruxHYPEBEASTxatmosToBeClicked,
                        MainPageElementsCollections.karafuruxHYPEBEASTxatmosCollection,
                        8,
                        5);
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("Нещо се счупи в {0} в {1}!", MainPageElementsCollections.karafuruxHYPEBEASTxatmosCollectionName, DateTime.Now));
                }

                try
                {
                    CreepzReptileArmoury.CreepzReptileArmouryCollection(
                        webDriver,
                        MainPageElementsCollections.creepzReptileArmouryNFT,
                        MainPageElementsCollections.creepzReptileArmouryToBeClicked,
                        MainPageElementsCollections.creepzReptileArmouryCollection,
                        10,
                        5);
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("Нещо се счупи в {0} в {1}!", MainPageElementsCollections.creepzReptileArmouryCollectionName, DateTime.Now));
                }

                try
                {
                    TheLobstars.TheLobstarsCollection(
                webDriver,
                MainPageElementsCollections.theLobstarsNFT,
                MainPageElementsCollections.theLobstarsNftToBeClicked,
                MainPageElementsCollections.theLobstarsCollection,
                9.5,
                5);
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("Нещо се счупи в {0} в {1}!", MainPageElementsCollections.cultureCubsOfficialCollectionName, DateTime.Now));
                }

                try
                {
                    VividLimited.VividLimitedCollection(
                    webDriver,
                    MainPageElementsCollections.vividLimitedNFT,
                    MainPageElementsCollections.vividLimitedNftToBeClicked,
                    MainPageElementsCollections.vividLimitedCollection,
                    7.5,
                    5);
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("Нещо се счупи в {0} в {1}!", MainPageElementsCollections.iLikeYouYoureWeirdCollectionName, DateTime.Now));
                }

                try
                {
                    FlowerLolitaCollections.FlowerLolitaCollectionsCollection(
       webDriver,
       MainPageElementsCollections.flowerLolitaCollectionsNFT,
       MainPageElementsCollections.flowerLolitaCollectionsToBeClicked,
       MainPageElementsCollections.flowerLolitaCollectionsCollection,
       10,
       5);
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("Нещо се счупи в {0} в {1}!", MainPageElementsCollections.wulfBoySocialClubCollectionName, DateTime.Now));
                }

                try
                {
                    RubberDuckBathParty.RubberDuckBathPartyCollection(
webDriver,
MainPageElementsCollections.rubberDuckBathPartyNFT,
MainPageElementsCollections.rubberDuckBathPartyNftToBeClicked,
MainPageElementsCollections.rubberDuckBathPartyCollection,
8.5,
5);
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("Нещо се счупи в {0} в {1}!", MainPageElementsCollections.thePsychonautApeDivisionCollectionName, DateTime.Now));
                }

                try
                {

                    ThePsychonautApeDivision.ThePsychonautApeDivisionCollection(
webDriver,
MainPageElementsCollections.thePsychonautApeDivisionNFT,
MainPageElementsCollections.thePsychonautApeDivisionToBeClicked,
MainPageElementsCollections.thePsychonautApeDivisionCollection,
12.5,
5);
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("Нещо се счупи в {0} в {1}!", MainPageElementsCollections.littleLemonFriendsCollectionName, DateTime.Now));
                }


            }
        }
    }
}