using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
 

namespace OpenSeaBot
{
    public class Main
    {

        [SetUp]
        public void Setup()
        {

            
        }

        [Test]
        public void Test1()
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

            //започваме да проверяваме NFT-тата от различните колекции, които следим, едно по едно дали ги имаме или не
            //от тук започваме да проверяваме дали имаме НФТ от дадена колекция или не, всичко надолу трябва да се изнесе в Collection -> Ethlizards. за всяка нова колекция се ползва същият код
            //като само се сменят имената и линковете на колекцията

            //MainPageMethods.Set(, 3000); - тук трябва да е метода за интервал, който се опитах да направя, но не можах. има го в Methods, последният метод е там. в него се вкарват колекциите, които
            // да се въртят на определено време

            MainPageMethods.IsNftBought(webDriver, MainPageElements.spellfireNFT);

            //ако имаме NFT, влизаме в него и проверяваме дали вече е пуснато за продажба или не

            if (MainPageElements.isVisible) 
            {
                MainPageMethods.GetInNft(webDriver, MainPageElements.spellfireNftToBeClicked);

                MainPageMethods.IsNftAlreadyForSale(webDriver, MainPageElements.isSellButtonVisible);
                //ако не е пуснато за продажба, го пускаме за продажба 
                if (MainPageElements.isSellButtonVisible)
                {
                    MainPageMethods.ClickCollectionLink(webDriver);
                    MainPageMethods.ClickCollectionOfferButton(webDriver);
                    Thread.Sleep(3000);
                    MainPageMethods.IsCollectionUnreviewed(webDriver);
                    MainPageMethods.CheckBoxIfUnreviewedCollection(webDriver);
                    Thread.Sleep(3000);
                    MainPageMethods.GetFloorNumber(webDriver);
                    MainPageMethods.GetMySellNumber();
                    MainPageMethods.GoToCollection(webDriver, MainPageElements.myAccountUrl);
                    MainPageMethods.GetInNft(webDriver, MainPageElements.spellfireNftToBeClicked);
                    MainPageMethods.ClickSellButton(webDriver);
                    MainPageMethods.TypeMySellNumberAndCompleteListing(webDriver);
                    webDriver.SwitchTo().Window(webDriver.WindowHandles[2]);
                    MainPageMethods.ConfirmSellInMetamask(webDriver);
                    webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
                } else
                {
                    // ако е пуснато за продажба
                    MainPageMethods.GoToCollection(webDriver, MainPageElements.spellfireCollection);
                    MainPageMethods.ClickCollectionOfferButton(webDriver);
                    Thread.Sleep(3000);
                    MainPageMethods.IsCollectionUnreviewed(webDriver);
                    MainPageMethods.CheckBoxIfUnreviewedCollection(webDriver);
                    Thread.Sleep(3000);               
                    MainPageMethods.GetFloorNumber(webDriver);
                    MainPageMethods.GoToCollection(webDriver, MainPageElements.myAccountUrl);
                    MainPageMethods.GetInNft(webDriver, MainPageElements.spellfireNftToBeClicked);
                    MainPageMethods.GetmySellNumberWhenAlreadyNftForSale(webDriver);
                    MainPageMethods.SetLowerPriceForSaleIfNeeded(webDriver);
                }
                // от тук трябва да отидем в профил и да търсим следващото НФТ дали го имаме
            }
            else
            {
                //започваме да пускаме оферта, като първо проверяваме колко е числото на Best offer-а
                MainPageMethods.GoToCollection(webDriver, MainPageElements.ethlizardCollection);
                MainPageMethods.ClickCollectionOfferButton(webDriver);
                Thread.Sleep(4000);
                MainPageMethods.GetFloorNumber(webDriver);
                MainPageMethods.GetBestOfferNumber(webDriver);

                if (MainPageElements.bestOfferNumber > MainPageElements.myPreviousOfferNumber) // проверяваме дали best offer-а е по голям от моят последен best offer и ако е - продължавам
                {
                    //проверявам дали Best offer-а е с поне 15% по - ниска от Floor price-а
                    if ((MainPageElements.bestOfferNumber / MainPageElements.floorNumber) * 100 < 85)
                    {
                        //продължавам с пускането на офертата
                        MainPageMethods.CalculateMyOfferNumber(webDriver, 10, 5);
                        MainPageMethods.TypeMyOfferNumber(webDriver, MainPageElements.myOfferNumberString);
                        MainPageMethods.CheckIfWethIsEnough(webDriver);
                        MainPageMethods.SwapWethForEthIfNeeded(webDriver);
                        MainPageMethods.ClickMyOfferButton(webDriver);
                        MainPageMethods.SignTransactionWithMetamask(webDriver);
                    }
                }
                
            }

        }
    }
}