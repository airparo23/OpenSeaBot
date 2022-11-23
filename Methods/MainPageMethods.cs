using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V106.Browser;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenSeaBot.Collections;
using OpenSeaBot.ElementsAndVariables;
using OpenSeaBot.Offer;
using SeleniumExtras.WaitHelpers;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace OpenSeaBot.Methods
{
    internal static class MainPageMethods
    {
        public static void WaitForAnElementToShow(WebDriver webDriver, By element)
        {
            WebDriverWait w = new WebDriverWait(webDriver, TimeSpan.FromSeconds(120));
            w.Until(ExpectedConditions.ElementExists(element));
        }

        public static void ClickTermsOfUseButton(WebDriver webDriver, By terms)
        {
            webDriver.FindElement(terms).Click();

        }

        public static void StartMetamask(WebDriver driver, By getStarted, By importWallet, By noThanks)
        {
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            WaitForAnElementToShow(driver, getStarted);

            driver.FindElement(getStarted).Click();
            WaitForAnElementToShow(driver, importWallet);

            driver.FindElement(importWallet).Click();
            WaitForAnElementToShow(driver, noThanks);

            driver.FindElement(noThanks).Click();
        }

        public static void LogInMetamask(By word1, By word2, By word3, By word4, By word5, By word6, By word7, By word8,
            By word9, By word10, By word11, By word12, WebDriver webDriver)
        {
            WaitForAnElementToShow(webDriver, MainPageElements.word1);

            string[] pass = { "" };
            By[] passFields = { word1, word2, word3, word4, word5, word6, word7, word8, word9, word10, word11, word12 };
            int i = 0;
            int j = 0;
            for (; i < pass.Length; i++, j++)
            {
                webDriver.FindElement(passFields[i]).SendKeys(pass[j]);
            }

            webDriver.FindElement(MainPageElements.password).SendKeys("opensea23");
            webDriver.FindElement(MainPageElements.passwordConfirm).SendKeys("opensea23");
            ClickTermsOfUseButton(webDriver, MainPageElements.termsOfUse);
            webDriver.FindElement(MainPageElements.import).Click();
            WaitForAnElementToShow(webDriver, MainPageElements.allDone);

            webDriver.FindElement(MainPageElements.allDone).Click();
            webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
        }

        public static void ConnectMetamaskToOpenSea(WebDriver webDriver)
        {
            webDriver.Navigate().GoToUrl("https://opensea.io/collection/ethlizards");


            WaitForAnElementToShow(webDriver, MainPageElements.makeCollectionOfferButton);

            webDriver.FindElement(MainPageElements.makeCollectionOfferButton).Click();
            WaitForAnElementToShow(webDriver, MainPageElements.metamaskButton);
            Thread.Sleep(3000);

            webDriver.FindElement(MainPageElements.metamaskButton).Click();
            Thread.Sleep(3000);

            webDriver.SwitchTo().Window(webDriver.WindowHandles[2]);
            WaitForAnElementToShow(webDriver, MainPageElements.nextMetamask);
            webDriver.FindElement(MainPageElements.nextMetamask).Click();
            WaitForAnElementToShow(webDriver, MainPageElements.connectMetamask);
            webDriver.FindElement(MainPageElements.connectMetamask).Click();
            webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
        }

        public static void ClickCollectionOfferButton(WebDriver driver)
        {
            Thread.Sleep(3000);
            WaitForAnElementToShow(driver, MainPageElements.makeCollectionOfferButton);
            driver.FindElement(MainPageElements.makeCollectionOfferButton).Click();
            Thread.Sleep(4000);
        }

        public static void IsNftBought(WebDriver webDriver, By Nft)
        {

            List<IWebElement> ethlizardNFTelementList = new List<IWebElement>();
            ethlizardNFTelementList.AddRange(webDriver.FindElements(Nft));
            if (ethlizardNFTelementList.Count > 0)
            {
                MainPageElementsVariables.isVisible = true;
            }
            else
            {
                MainPageElementsVariables.isVisible = false;
            }


        }

        public static void GoIntoNft(WebDriver driver, By Nft)
        {
            List<IWebElement> NftsBoughtList = new List<IWebElement>();
            NftsBoughtList.AddRange(driver.FindElements(Nft));
            NftsBoughtList[0].Click();

        }

        public static void ClickCollectionLink(WebDriver driver)
        {
            driver.FindElement(MainPageElements.collectionLink).Click();
        }

        public static void GoToCollection(WebDriver webDriver, string collection)
        {
            webDriver.Navigate().GoToUrl(collection);
        }

        public static void ClickSellButton(WebDriver webDriver)
        {
            WaitForAnElementToShow(webDriver, MainPageElements.sellButton);
            Thread.Sleep(3000);
            webDriver.FindElement(MainPageElements.sellButton).Click();
        }

        public static void TypeMySellNumberAndCompleteListing(WebDriver webDriver)
        {
            //string mySellNumberString = MainPageElementsVariables.mySellNumber.ToString();
            WaitForAnElementToShow(webDriver, MainPageElements.sellPriceField);
            if(MainPageElementsVariables.mySellNumber >= MainPageElementsVariables.myMinSellNumber)
            {
                webDriver.FindElement(MainPageElements.sellPriceField).SendKeys(MainPageElementsVariables.mySellNumber.ToString());
                ChooseOneDayPeriodNftSorSale(webDriver);
                webDriver.FindElement(MainPageElements.completeListingButton).Click();
                Thread.Sleep(5000);
                IsCollectionToBeApprovedOrSigned(webDriver);
                Thread.Sleep(5000);

                if (MainPageElementsVariables.isCollectionApproved == false)
                {
                    TimeSpan start = new TimeSpan(12, 0, 0); //12 o'clock
                    TimeSpan end = new TimeSpan(14, 0, 0); //14 o'clock
                    TimeSpan now = DateTime.Now.TimeOfDay;
                    if ((now > start) && (now < end))
                    {
                        webDriver.SwitchTo().Window(webDriver.WindowHandles[2]);
                        WaitForAnElementToShow(webDriver, MainPageElements.confirmMetamaskButton);
                        webDriver.FindElement(MainPageElements.confirmMetamaskButton).Click();
                        webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
                        Thread.Sleep(6000);
                        webDriver.SwitchTo().Window(webDriver.WindowHandles[2]);
                        webDriver.Close();
                        webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
                    }

                }
                else
                {
                    webDriver.SwitchTo().Window(webDriver.WindowHandles[2]);
                    WaitForAnElementToShow(webDriver, MainPageElements.downArrowMetamask);
                    webDriver.FindElement(MainPageElements.downArrowMetamask).Click();
                    WaitForAnElementToShow(webDriver, MainPageElements.signMetamaskButton);
                    webDriver.FindElement(MainPageElements.signMetamaskButton).Click();
                    webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
                }
            }          
        }

        public static void ChooseOneDayPeriodNftSorSale(WebDriver webDriver)
        {
            webDriver.FindElement(MainPageElements.oneMonthButton).Click();
            Thread.Sleep(1000);
            var oneMonthDateRangeMenuList = webDriver.FindElements(MainPageElements.oneMonthDateRangeMenu);
            oneMonthDateRangeMenuList[1].Click();
            Thread.Sleep(1000);
            webDriver.FindElement(MainPageElements.oneMonthDateRangeButton).Click();
            webDriver.FindElement(By.CssSelector("input[aria-label='Search OpenSea']")).Click();
        }

        public static void IsCollectionToBeApprovedOrSigned(WebDriver webDriver)
        {
            var approveCollectionList = webDriver.FindElements(MainPageElements.approveCollectionElement);
            if (approveCollectionList.Count > 0)
            {
                MainPageElementsVariables.isCollectionApproved = false;
            }
            else
            {
                MainPageElementsVariables.isCollectionApproved = true;
            }
        }


        public static void ClickLowerPriceButton(WebDriver webDriver)
        {
            WaitForAnElementToShow(webDriver, MainPageElements.lowerPriceButton);
            webDriver.FindElement(MainPageElements.lowerPriceButton).Click();
        }

        public static double GetMySellNumber(WebDriver webDriver, double fees, double myProfit, Offer.Offer collectionType)
        {           
            MainPageElementsVariables.mySellNumber = MainPageElementsVariables.floorNumber - 0.0001;
            return MainPageElementsVariables.mySellNumber = Math.Round(MainPageElementsVariables.mySellNumber, 4);
        }

        public static double IfMyMinSellNumberBiggerThanMyLowerFloorNumberGetNewSellNumber(WebDriver webDriver)
        {
            if (MainPageElementsVariables.myMinSellNumber > MainPageElementsVariables.mySellNumber)
            {
                MainPageElementsVariables.mySellNumber = GetMyNewSellNumber(webDriver);
                return MainPageElementsVariables.mySellNumber;
            }
            return MainPageElementsVariables.mySellNumber;
        }

        public static void CalculateMySellNumber(double fees, double myProfit, Offer.Offer collectionType, WebDriver webDriver)
        {
            MainPageElementsVariables.mySellNumber = MainPageElementsVariables.floorNumber - 0.0001;
            //string mySellNumberString = string.Format("{0:0.0000}", MainPageElementsVariables.mySellNumber);
            MainPageElementsVariables.mySellNumber = Math.Round(MainPageElementsVariables.mySellNumber, 4);
            MainPageElementsVariables.myMinSellNumber = CalculateMyMinimumSellNumber(fees, myProfit, collectionType);
            if (MainPageElementsVariables.myMinSellNumber > MainPageElementsVariables.mySellNumber)
            {
                MainPageElementsVariables.mySellNumber = GetMyNewSellNumber(webDriver);

            }
        }

        public static double GetMyNewSellNumber(WebDriver webDriver)
        {
            //Actions action = new Actions(webDriver);
            Thread.Sleep(3000);
            var NftsList = webDriver.FindElements(MainPageElements.floorPriceAllNfts);
            for (int i = 0; i < NftsList.Count; i++)
            {
                /*action.MoveToElement(NftsList[i]).Perform();
                Thread.Sleep(2000);
                var WholeNftPriceList = webDriver.FindElements(By.CssSelector("div[data-tippy-root]"));
                if(WholeNftPriceList.Count > 0)
                {
                    string NftPriceString = webDriver.FindElement(By.CssSelector("div[data-tippy-root]")).Text;
                    MainPageElementsVariables.nftPriceNumber = double.Parse(NftPriceString, CultureInfo.InvariantCulture);                   
                } else
                {*/
                string NftPriceString = NftsList[i].Text;
                Match NftPriceStringRegex = Regex.Match(NftPriceString, MainPageElementsVariables.pattern);
                string NftPriceStringValue = NftPriceStringRegex.Value;
                MainPageElementsVariables.nftPriceNumber = double.Parse(NftPriceStringValue, CultureInfo.InvariantCulture);
                //}
                if (MainPageElementsVariables.myMinSellNumber < MainPageElementsVariables.nftPriceNumber)
                {
                    MainPageElementsVariables.mySellNumber = MainPageElementsVariables.nftPriceNumber - 0.0001;
                    MainPageElementsVariables.mySellNumber = Math.Round(MainPageElementsVariables.mySellNumber, 4);
                    return MainPageElementsVariables.mySellNumber;
                }
            }
            return MainPageElementsVariables.mySellNumber;
        }

        public static void TypeMyOfferNumber(WebDriver webDriver, string myOfferNumber)
        {
            webDriver.FindElement(MainPageElements.amountField).SendKeys(myOfferNumber);
            webDriver.FindElement(MainPageElements.offerPeriodDownArrow).Click();
            Thread.Sleep(3000);
            webDriver.FindElement(MainPageElements.offerPeriodCustom).Click();
        }

        public static void ClickMyOfferButton(WebDriver webDriver)
        {
            webDriver.FindElement(MainPageElements.makeOfferButton).Click();
            Thread.Sleep(10000);
            webDriver.SwitchTo().Window(webDriver.WindowHandles[2]);
        }

        public static void SignTransactionWithMetamask(WebDriver webDriver)
        {
            try
            {
                WaitForAnElementToShow(webDriver, MainPageElements.downArrowMetamask);
                webDriver.FindElement(MainPageElements.downArrowMetamask).Click();

                WaitForAnElementToShow(webDriver, MainPageElements.signMetamaskButton);

                var signMetamaskButtonList = webDriver.FindElements(MainPageElements.signMetamaskButton);
                if (signMetamaskButtonList.Count > 0)
                {
                    webDriver.FindElement(MainPageElements.signMetamaskButton).Click();

                }
                else
                {
                    Thread.Sleep(4000);
                    webDriver.FindElement(MainPageElements.signMetamaskButton).Click();
                }

                webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
            }
            catch
            {
                webDriver.Close();
                webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
            }

        }




        public static void IsNftAlreadyForSale(WebDriver driver, bool isSellButtonVisible)
        {
            Thread.Sleep(4000);
            List<IWebElement> sellButtonelementList = new List<IWebElement>();
            sellButtonelementList.AddRange(driver.FindElements(MainPageElements.sellButton));
            if (sellButtonelementList.Count > 0)
            {
                MainPageElementsVariables.isSellButtonVisible = true;
            }
            else
            {
                MainPageElementsVariables.isSellButtonVisible = false;
            }


        }

        public static void IsNftAlreadyForSaleNew()
        {

        }

        public static void IsCollectionUnreviewed(WebDriver webDriver)
        {
            List<IWebElement> isUnreviewedCollectionList = new List<IWebElement>();
            isUnreviewedCollectionList.AddRange(webDriver.FindElements(MainPageElements.isCollectionReviewed));
            if (isUnreviewedCollectionList.Count > 0)
            {
                MainPageElementsVariables.isUnreviewedCollection = true;
            }
            else
            {
                MainPageElementsVariables.isUnreviewedCollection = false;
            }
        }


        public static void SetLowerPriceForSaleIfNeeded(WebDriver webDriver, double fees, double myProfit, Offer.Offer collectionType, By NftToBeClicked)
        {
            if (MainPageElementsVariables.mySellNumberWhenAlreadyNftForSaleNumber > MainPageElementsVariables.floorNumber)
            {
                MainPageElementsVariables.mySellNumber = GetMySellNumber(webDriver, fees, myProfit, collectionType);
                MainPageElementsVariables.myMinSellNumber = CalculateMyMinimumSellNumber(fees, myProfit, collectionType);
                MainPageElementsVariables.mySellNumber = IfMyMinSellNumberBiggerThanMyLowerFloorNumberGetNewSellNumber(webDriver);
                double myLowerFloorNumberForCompare = MainPageElementsVariables.mySellNumber + 0.0001;
                myLowerFloorNumberForCompare = Math.Round(myLowerFloorNumberForCompare, 4);
                if (MainPageElementsVariables.mySellNumberWhenAlreadyNftForSaleNumber > myLowerFloorNumberForCompare 
                    && MainPageElementsVariables.mySellNumber >= MainPageElementsVariables.myMinSellNumber) 
                {
                    GoToCollection(webDriver, MainPageElements.myAccountUrl);
                    GoIntoNft(webDriver, NftToBeClicked);
                    Thread.Sleep(3000);
                    ClickLowerPriceButton(webDriver);
                    webDriver.FindElement(MainPageElements.inputFieldLowerPrice).SendKeys(MainPageElementsVariables.mySellNumber.ToString());
                    webDriver.FindElement(MainPageElements.setNewPriceButton).Click();
                    Thread.Sleep(10000);
                    webDriver.SwitchTo().Window(webDriver.WindowHandles[2]);

                    try
                    {
                        SignTransactionWithMetamask(webDriver);

                    }
                    catch
                    {
                        webDriver.Close();
                        webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
                    }
                }

            }
        }





        public static void GetMySellNumberWhenAlreadyNftForSale(WebDriver webDriver)
        {
            Thread.Sleep(3000);
            string mySellNumberWhenAlreadyNftForSale = webDriver.FindElement(By.CssSelector("div[class='TradeStation--price-container'] div[class*='Price--amount']")).Text;
            MainPageElementsVariables.pattern = @"\d{1,}.\d{1,}";
            Match floorOriginalAfterRegex = Regex.Match(mySellNumberWhenAlreadyNftForSale, MainPageElementsVariables.pattern);
            MainPageElementsVariables.bestOfferNumberValue = floorOriginalAfterRegex.Value;
            MainPageElementsVariables.mySellNumberWhenAlreadyNftForSaleNumber = double.Parse(MainPageElementsVariables.bestOfferNumberValue, CultureInfo.InvariantCulture);
        }

        public static void SaveBestOfferNumber(WebDriver webDriver)
        {
            Thread.Sleep(5000);
            var bestOfferList = webDriver.FindElements(By.XPath("//div[@overflow='hidden'] //span[@font-size='14px']"));
            MainPageElementsVariables.bestOffer = bestOfferList[3].Text;
            MainPageElementsVariables.pattern = @"\d{1,}.\d{1,}";
            //var rg = new Regex(MainPageElements.pattern);
            Match bestOfferOriginal = Regex.Match(MainPageElementsVariables.bestOffer, MainPageElementsVariables.pattern);
            MainPageElementsVariables.bestOfferNumberValue = bestOfferOriginal.Value;
            MainPageElementsVariables.bestOfferNumber = double.Parse(MainPageElementsVariables.bestOfferNumberValue);
        }

        public static void SaveBestOfferNumberNotUsed(WebDriver webDriver)
        {
            string BestOfferNumberString = webDriver.FindElement(MainPageElements.bestOfferPrice).Text;
            MainPageElementsVariables.bestOfferNumber = double.Parse(MainPageElementsVariables.bestOfferNumberValue);
        }

        public static void SaveFloorNumberOld(WebDriver webDriver)
        {
            var floorPriceList = webDriver.FindElements(By.XPath("//div[@overflow='hidden'] //span[contains(., 'ETH')]"));
            MainPageElementsVariables.floorPrice = floorPriceList[2].Text;
            MainPageElementsVariables.pattern = @"\d{1,}.\d{1,}";
            //var rg = new Regex(MainPageElements.pattern);
            Match floorPriceOriginal = Regex.Match(MainPageElementsVariables.floorPrice, MainPageElementsVariables.pattern);
            MainPageElementsVariables.floorPriceNumberValue = floorPriceOriginal.Value;
            MainPageElementsVariables.floorNumber = double.Parse(MainPageElementsVariables.floorPriceNumberValue, CultureInfo.InvariantCulture);
        }


        public static void SaveFloorNumber(WebDriver webDriver)
        {
            string floorPriceString = webDriver.FindElement(MainPageElements.floorPrice).Text;
            Match floorPriceAfterRegex = Regex.Match(floorPriceString, MainPageElementsVariables.pattern);
            floorPriceString = floorPriceAfterRegex.Value;
            MainPageElementsVariables.floorNumber = double.Parse(floorPriceString, CultureInfo.InvariantCulture);
        }

       

        

        public static double CalculateMyOfferNumber(double fees, double myProfit, double myOfferNumber)
        {

            myOfferNumber = MainPageElementsVariables.bestOfferNumber + 0.0001;
            string myOfferNumberString = String.Format("{0:0.0000}", myOfferNumber);
            myOfferNumber = double.Parse(myOfferNumberString, CultureInfo.InvariantCulture);
            CalculateMyMaxBestOffer(fees, myProfit);
            if (myOfferNumber > MainPageElementsVariables.maxOfferNumber)
            {
                MainPageElementsVariables.isMyOfferOnProfit = false;
            }
            else
            {
                MainPageElementsVariables.isMyOfferOnProfit = true;
            }
            MainPageElementsVariables.myOfferNumberString = myOfferNumber.ToString();

            return myOfferNumber;
        }

        public static void SaveInFile(string filePath)
        {
            
        }

        public static void SaveMyOfferNumberInFile(Offer.Offer myOffer)
        {
            switch (myOffer.Type)
            {
                case OfferType.VividLimited:
                    string VividLimitedName = @"K:/OpenSea_Bot_Files/VividLimited.txt";
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(VividLimitedName))
                        {
                            writer.Write(myOffer.Value.ToString());
                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write(exp.Message);
                    }
                    break;
                case OfferType.TheLobstars:
                    string TheLobstarsFile = "K:/OpenSea_Bot_Files/TheLobstars.txt";
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(TheLobstarsFile))
                        {
                            writer.Write(myOffer.Value.ToString());
                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write(exp.Message);
                    }

                    break;
                case OfferType.MutantGrandpaCountryClub:
                    string MutantGrandpaCountryClubFile = "K:/OpenSea_Bot_Files/MutantGrandpaCountryClub.txt";
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(MutantGrandpaCountryClubFile))
                        {
                            writer.Write(myOffer.Value.ToString());
                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write(exp.Message);
                    }
                    break;
                case OfferType.RetroArcadeCollection:
                    string RetroArcadeCollectionFile = "K:/OpenSea_Bot_Files/RetroArcadeCollection.txt";
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(RetroArcadeCollectionFile))
                        {
                            writer.Write(myOffer.Value.ToString());
                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write(exp.Message);
                    }
                    break;
                case OfferType.RubberDuckBathParty:
                    string RubberDuckBathPartyName = @"K:/OpenSea_Bot_Files/RubberDuckBathParty.txt";
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(RubberDuckBathPartyName))
                        {
                            writer.Write(myOffer.Value.ToString());
                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write(exp.Message);
                    }
                    break;
                case OfferType.AntonymGENESIS:
                    string AntonymGENESISFile = "K:/OpenSea_Bot_Files/AntonymGENESIS.txt";
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(AntonymGENESISFile))
                        {
                            writer.Write(myOffer.Value.ToString());
                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write(exp.Message);
                    }
                    break;
                case OfferType.AINightbirds:
                    string AINightbirdsFile = "K:/OpenSea_Bot_Files/AINightbirds.txt";
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(AINightbirdsFile))
                        {
                            writer.Write(myOffer.Value.ToString());
                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write(exp.Message);
                    }
                    break;
                case OfferType.ChildrenofUkiyo:
                    string ChildrenofUkiyoFile = "K:/OpenSea_Bot_Files/ChildrenofUkiyo.txt";
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(ChildrenofUkiyoFile))
                        {
                            writer.Write(myOffer.Value.ToString());
                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write(exp.Message);
                    }
                    break;
                case OfferType.FlowerLolitaCollections:
                    string FlowerLolitaCollectionsFile = "K:/OpenSea_Bot_Files/FlowerLolitaCollections.txt";
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(FlowerLolitaCollectionsFile))
                        {
                            writer.Write(myOffer.Value.ToString());
                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write(exp.Message);
                    }
                    break;
                case OfferType.TheMekabots:
                    string TheMekabotsFile = "K:/OpenSea_Bot_Files/TheMekabots.txt";
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(TheMekabotsFile))
                        {
                            writer.Write(myOffer.Value.ToString());
                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write(exp.Message);
                    }
                    break;
                case OfferType.GirliesNFT:
                    string GirliesNFTFile = "K:/OpenSea_Bot_Files/GirliesNFT.txt";
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(GirliesNFTFile))
                        {
                            writer.Write(myOffer.Value.ToString());
                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write(exp.Message);
                    }
                    break;
                case OfferType.JapaneseBornApeSociety:
                    string JapaneseBornApeSocietyFile = "K:/OpenSea_Bot_Files/JapaneseBornApeSociety.txt";
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(JapaneseBornApeSocietyFile))
                        {
                            writer.Write(myOffer.Value.ToString());
                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write(exp.Message);
                    }
                    break;
                case OfferType.ChainsNFT:
                    string ChainsNFTFile = "K:/OpenSea_Bot_Files/ChainsNFT.txt";
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(ChainsNFTFile))
                        {
                            writer.Write(myOffer.Value.ToString());
                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write(exp.Message);
                    }
                    break;
                case OfferType.TheWhitelistioAces:
                    string TheWhitelistioAcesFile = "K:/OpenSea_Bot_Files/TheWhitelistioAces.txt";
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(TheWhitelistioAcesFile))
                        {
                            writer.Write(myOffer.Value.ToString());
                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write(exp.Message);
                    }
                    break;
                case OfferType.KarafuruxHYPEBEASTxatmos:
                    string KarafuruxHYPEBEASTxatmosFile = "K:/OpenSea_Bot_Files/KarafuruxHYPEBEASTxatmos.txt";
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(KarafuruxHYPEBEASTxatmosFile))
                        {
                            writer.Write(myOffer.Value.ToString());
                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write(exp.Message);
                    }
                    break;
                case OfferType.CreepzReptileArmoury:
                    string CreepzReptileArmouryFile = "K:/OpenSea_Bot_Files/CreepzReptileArmoury.txt";
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(CreepzReptileArmouryFile))
                        {
                            writer.Write(myOffer.Value.ToString());
                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write(exp.Message);
                    }
                    break;
                case OfferType.CultureCubsOfficial:
                    string CultureCubsOfficialFile = "K:/OpenSea_Bot_Files/CultureCubsOfficial.txt";
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(CultureCubsOfficialFile))
                        {
                            writer.Write(myOffer.Value.ToString());
                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write(exp.Message);
                    }
                    break;
                case OfferType.ILikeYouYoureWeird:
                    string ILikeYouYoureWeirdFile = "K:/OpenSea_Bot_Files/ILikeYouYoureWeird.txt";
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(ILikeYouYoureWeirdFile))
                        {
                            writer.Write(myOffer.Value.ToString());
                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write(exp.Message);
                    }
                    break;
                case OfferType.WulfBoySocialClub:
                    string WulfBoySocialClubFile = "K:/OpenSea_Bot_Files/WulfBoySocialClub.txt";
                        try
                        {
                            using (StreamWriter writer = new StreamWriter(WulfBoySocialClubFile))
                            {
                                writer.Write(myOffer.Value.ToString());
                            }
                        }
                        catch (Exception exp)
                        {
                            Console.Write(exp.Message);
                        }
                    break;
                case OfferType.ThePsychonautApeDivision:
                    string ThePsychonautApeDivisionFile = "K:/OpenSea_Bot_Files/ThePsychonautApeDivision.txt";
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(ThePsychonautApeDivisionFile))
                        {
                            writer.Write(myOffer.Value.ToString());
                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write(exp.Message);
                    }
                    break;
                case OfferType.LittleLemonFriends:
                    string LittleLemonFriendsFile = "K:/OpenSea_Bot_Files/LittleLemonFriends.txt";
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(LittleLemonFriendsFile))
                        {
                            writer.Write(myOffer.Value.ToString());
                        }
                    }
                    catch (Exception exp)
                    {
                        Console.Write(exp.Message);
                    }
                    break;

            }
        }


        public static void CalculateMyMaxBestOffer(double fees, double myProfit)
        {
            double feesPlusMyProfitPercentage = fees + myProfit;
            double feesPlusMyProfitNumber = feesPlusMyProfitPercentage / 100;
            double feesAndProfit = MainPageElementsVariables.floorNumber * feesPlusMyProfitNumber;
            feesAndProfit = Math.Round(feesAndProfit, 4);
            MainPageElementsVariables.maxOfferNumber = MainPageElementsVariables.floorNumber - feesAndProfit;
        }
        public static double CalculateMyMinimumSellNumber(double fees, double myProfit, Offer.Offer collectionType)
        {
            double feesPlusMyProfitPercentage = fees + myProfit;
            double feesPlusMyProfitNumber = feesPlusMyProfitPercentage / 100;
            string myOfferNumberString;
            switch (collectionType.Type)
            {
                case OfferType.VividLimited:
                    myOfferNumberString = File.ReadLines("K:/OpenSea_Bot_Files/VividLimited.txt").Last();
                    break;
                case OfferType.TheLobstars:
                    myOfferNumberString = File.ReadLines("K:/OpenSea_Bot_Files/TheLobstars.txt").Last();
                    break;
                case OfferType.MutantGrandpaCountryClub:
                    myOfferNumberString = File.ReadLines("K:/OpenSea_Bot_Files/MutantGrandpaCountryClub.txt").Last();
                    break;
                case OfferType.RubberDuckBathParty:
                    myOfferNumberString = File.ReadLines("K:/OpenSea_Bot_Files/RubberDuckBathParty.txt").Last();
                    break;
                case OfferType.RetroArcadeCollection:
                    myOfferNumberString = File.ReadLines("K:/OpenSea_Bot_Files/RetroArcadeCollection.txt").Last();
                    break;
                case OfferType.AntonymGENESIS:
                    myOfferNumberString = File.ReadLines("K:/OpenSea_Bot_Files/AntonymGENESIS.txt").Last();
                    break;
                case OfferType.AINightbirds:
                    myOfferNumberString = File.ReadLines("K:/OpenSea_Bot_Files/AINightbirds.txt").Last();
                    break;
                case OfferType.ChildrenofUkiyo:
                    myOfferNumberString = File.ReadLines("K:/OpenSea_Bot_Files/ChildrenofUkiyo.txt").Last();
                    break;
                case OfferType.FlowerLolitaCollections:
                    myOfferNumberString = File.ReadLines("K:/OpenSea_Bot_Files/FlowerLolitaCollections.txt").Last();
                    break;
                case OfferType.TheMekabots:
                    myOfferNumberString = File.ReadLines("K:/OpenSea_Bot_Files/TheMekabots.txt").Last();
                    break;
                case OfferType.GirliesNFT:
                    myOfferNumberString = File.ReadLines("K:/OpenSea_Bot_Files/GirliesNFT.txt").Last();
                    break;
                case OfferType.JapaneseBornApeSociety:
                    myOfferNumberString = File.ReadLines("K:/OpenSea_Bot_Files/JapaneseBornApeSociety.txt").Last();
                    break;
                case OfferType.ChainsNFT:
                    myOfferNumberString = File.ReadLines("K:/OpenSea_Bot_Files/ChainsNFT.txt").Last();
                    break;
                case OfferType.TheWhitelistioAces:
                    myOfferNumberString = File.ReadLines("K:/OpenSea_Bot_Files/TheWhitelistioAces.txt").Last();
                    break;
                case OfferType.KarafuruxHYPEBEASTxatmos:
                    myOfferNumberString = File.ReadLines("K:/OpenSea_Bot_Files/KarafuruxHYPEBEASTxatmos.txt").Last();
                    break;
                case OfferType.CreepzReptileArmoury:
                    myOfferNumberString = File.ReadLines("K:/OpenSea_Bot_Files/CreepzReptileArmoury.txt").Last();
                    break;
                case OfferType.CultureCubsOfficial:
                    myOfferNumberString = File.ReadLines("K:/OpenSea_Bot_Files/CultureCubsOfficial.txt").Last();
                    break;
                case OfferType.ILikeYouYoureWeird:
                    myOfferNumberString = File.ReadLines("K:/OpenSea_Bot_Files/ILikeYouYoureWeird.txt").Last();
                    break;
                case OfferType.WulfBoySocialClub:
                    myOfferNumberString = File.ReadLines("K:/OpenSea_Bot_Files/WulfBoySocialClub.txt").Last();
                    break;
                case OfferType.ThePsychonautApeDivision:
                    myOfferNumberString = File.ReadLines("K:/OpenSea_Bot_Files/ThePsychonautApeDivision.txt").Last();
                    break;
                case OfferType.LittleLemonFriends:
                    myOfferNumberString = File.ReadLines("K:/OpenSea_Bot_Files/LittleLemonFriends.txt").Last();
                    break;
                default:
                    myOfferNumberString = "0";
                    break;
            }
            double myOfferNumber = double.Parse(myOfferNumberString, CultureInfo.InvariantCulture);
            double percentage = myOfferNumber * feesPlusMyProfitNumber;
            double myMinSellNumber = myOfferNumber + percentage;
            return myMinSellNumber;
        }



        public static void IsWethEnough(WebDriver webDriver)
        {
            var notEnoughWethMessageList = webDriver.FindElements(MainPageElements.notEnoughWethMessage);
            if (notEnoughWethMessageList.Count > 0)
            {
                MainPageElementsVariables.isNotEnoughWeth = true;
            }
            else
            {
                MainPageElementsVariables.isNotEnoughWeth = false;
            }
        }

        public static void CheckBoxIfUnreviewedCollection(WebDriver webDriver)
        {
            if (MainPageElementsVariables.isUnreviewedCollection)
            {
                webDriver.FindElement(MainPageElements.checkBoxReviewedCollection).Click();
            }
            Thread.Sleep(3000);
        }

        public static void SwapWethForEthIfNeeded(WebDriver webDriver, string NftCollection, double myOfferNumber)
        {
            if (MainPageElementsVariables.isNotEnoughWeth)
            {
                webDriver.FindElement(MainPageElements.addWethButton).Click();

                webDriver.SwitchTo().Window(webDriver.WindowHandles[0]);
                string etherBalanceFromMmString = webDriver.FindElement(By.CssSelector("div[class='currency-display-component eth-overview__primary-balance']>span[class='currency-display-component__text']")).Text;
                webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
                double etherBalanceFromMmNumber = double.Parse(etherBalanceFromMmString);
                double etherBalanceFromMmToSwap = etherBalanceFromMmNumber - 0.004;
                etherBalanceFromMmToSwap = Math.Round(etherBalanceFromMmToSwap, 4);
                if(etherBalanceFromMmToSwap < 0.01)
                {
                    etherBalanceFromMmToSwap = 5;
                }
                Thread.Sleep(3000);
                var fieldForSwapingWeth = webDriver.FindElements(By.CssSelector("input[class*='Input-sc']"));
                fieldForSwapingWeth[0].Click();
                fieldForSwapingWeth[0].SendKeys(Keys.Control + "a");
                fieldForSwapingWeth[0].SendKeys(Keys.Backspace);
                fieldForSwapingWeth[0].SendKeys(etherBalanceFromMmToSwap.ToString());
                webDriver.FindElement(MainPageElements.wrapEthButton).Click();
                Thread.Sleep(7000);
                webDriver.SwitchTo().Window(webDriver.WindowHandles[2]);
                try
                {
                    WaitForAnElementToShow(webDriver, MainPageElements.confirmButtonMetamask);
                    var confirmButtonMetamasklist = webDriver.FindElements(MainPageElements.confirmButtonMetamask);
                    if (confirmButtonMetamasklist.Count > 0)
                    {
                        webDriver.FindElement(MainPageElements.confirmButtonMetamask).Click();

                    }
                    else
                    {
                        Thread.Sleep(4000);
                        webDriver.FindElement(MainPageElements.confirmButtonMetamask).Click();
                    }
                    webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
                    Thread.Sleep(4000);
                    webDriver.Navigate().GoToUrl(NftCollection);
                }
                catch
                {
                    webDriver.Close();
                    webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
                    webDriver.Navigate().GoToUrl(NftCollection);
                }


            }
        }





        public static void SaveSevenDayAverageSellNumber(WebDriver webDriver, double PercentageOverAvgPrice)
        {
            webDriver.FindElement(MainPageElements.activity).Click();
            WaitForAnElementToShow(webDriver, MainPageElements.arrowDownTimePeriod);
            Thread.Sleep(7000);
            webDriver.FindElement(MainPageElements.arrowDownTimePeriod).Click();
            webDriver.FindElement(MainPageElements.lastSevenDaysPeriod).Click();
            Thread.Sleep(2000);
            SaveSevenDaysAveragePrice(webDriver);
            double PercentageOverAvgPriceInNumber = PercentageOverAvgPrice / 100;
            double Percentage = MainPageElementsVariables.sevenDaysAveragePriceNumber * PercentageOverAvgPriceInNumber;
            MainPageElementsVariables.maxAvgPrice = MainPageElementsVariables.sevenDaysAveragePriceNumber + Percentage;
            GoToItemsCollection(webDriver);
        }

        public static void GoToItemsCollection(WebDriver webDriver)
        {
            var itemsList = webDriver.FindElements(MainPageElements.items);
            itemsList[1].Click();
        }



        public static void SaveSevenDaysAveragePrice(WebDriver webDriver)
        {
            var saveSevenDaysAveragePriceList = webDriver.FindElements(MainPageElements.SevenDaysAveragePrice);
            MainPageElementsVariables.sevenDaysAveragePriceString = saveSevenDaysAveragePriceList[0].Text;
            MainPageElementsVariables.pattern = @"\d{1,}.\d{1,}";
            Match SevenDaysAveragePriceStringAfterRegex = Regex.Match(MainPageElementsVariables.sevenDaysAveragePriceString, MainPageElementsVariables.pattern);
            MainPageElementsVariables.sevenDaysAveragePriceStringAfterRegexValue = SevenDaysAveragePriceStringAfterRegex.Value;
            MainPageElementsVariables.sevenDaysAveragePriceNumber = double.Parse(MainPageElementsVariables.sevenDaysAveragePriceStringAfterRegexValue, CultureInfo.InvariantCulture);
        }


        public static void BuyFloorIfCheap(WebDriver webDriver, string collection, double fees, double profit)
        {

            double feesPlusProfit = fees + profit;

            var floorNumbersList = webDriver.FindElements(MainPageElements.floorPriceAllNfts);
            string floorPriceString = floorNumbersList[0].Text;
            string secondFloorPriceString = floorNumbersList[1].Text;
            double floorPrice = double.Parse(floorPriceString, CultureInfo.InvariantCulture);
            double secondFloorPrice = double.Parse(secondFloorPriceString, CultureInfo.InvariantCulture);
            double differenceSecondAndFirstFloorPrice = secondFloorPrice - floorPrice;
            double secondFloorPriceDevidedHundred = secondFloorPrice / 100;
            double secondFloorPriceMinusFeesAndProfitPercentage = secondFloorPrice * secondFloorPriceDevidedHundred;
            Thread.Sleep(2000);

            if (differenceSecondAndFirstFloorPrice > secondFloorPriceMinusFeesAndProfitPercentage)
            {
                Thread.Sleep(2000);
                floorNumbersList[0].Click();
                WaitForAnElementToShow(webDriver, MainPageElements.addToCartButton);
                webDriver.FindElement(MainPageElements.addToCartButton).Click();
                WaitForAnElementToShow(webDriver, MainPageElements.completePurchaseButton);
                webDriver.FindElement(MainPageElements.completePurchaseButton).Click();
                Thread.Sleep(6000);
                webDriver.SwitchTo().Window(webDriver.WindowHandles[2]);
                webDriver.FindElement(MainPageElements.confirmMetamaskButton).Click();
                webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
            }

        }







    }
}
