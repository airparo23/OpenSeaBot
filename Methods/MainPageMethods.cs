using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenSeaBot.ElementsAndVariables;
using OpenSeaBot.Offer;
using SeleniumExtras.WaitHelpers;
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

            string[] pass = {  };
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
            /*string mySellNumberString = MainPageElementsVariables.mySellNumber.ToString();
            WaitForAnElementToShow(webDriver, MainPageElements.sellPriceField);
            webDriver.FindElement(MainPageElements.sellPriceField).SendKeys(mySellNumberString);
            webDriver.FindElement(MainPageElements.completeListingButton).Click();
            Thread.Sleep(4000);*/
        }
        public static void ConfirmSellInMetamask(WebDriver webDriver)
        {
            /*WaitForAnElementToShow(webDriver, MainPageElements.downArrowMetamask);

            webDriver.FindElement(MainPageElements.downArrowMetamask).Click();
            WaitForAnElementToShow(webDriver, MainPageElements.signMetamaskButton);

            webDriver.FindElement(MainPageElements.signMetamaskButton).Click();*/
            Thread.Sleep(3000);
            webDriver.FindElement(MainPageElements.confirmMetamaskButton).Click();
            webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
            ApproveCollectionIfNeeded(webDriver);


        }

        public static void CheckIfCollectionIsToBeApproved(WebDriver webDriver)
        {
            var approveCollectionMessageList = webDriver.FindElements(MainPageElements.approveCollection);
            if (approveCollectionMessageList.Count > 0)
            {
                MainPageElementsVariables.isCollectionApproved = false;
            }
            else
            {
                MainPageElementsVariables.isCollectionApproved = true;
            }
        }

        public static void ApproveCollectionIfNeeded(WebDriver webDriver)
        {
            CheckIfCollectionIsToBeApproved(webDriver);
            if (MainPageElementsVariables.isCollectionApproved == false)
            {
                Thread.Sleep(15000);
                webDriver.SwitchTo().Window(webDriver.WindowHandles[2]);
                WaitForAnElementToShow(webDriver, MainPageElements.downArrowMetamask);
                webDriver.FindElement(MainPageElements.downArrowMetamask).Click();
                WaitForAnElementToShow(webDriver, MainPageElements.signMetamaskButton);
                webDriver.FindElement(MainPageElements.signMetamaskButton).Click();
            }
        }
        public static void ClickLowerPriceButton(WebDriver webDriver)
        {
            webDriver.FindElement(MainPageElements.lowerPriceButton).Click();
        }

        public static void SetLowerPrice(WebDriver webDriver)
        {
            double myLowerFloorNumber = MainPageElementsVariables.floorNumber - 0.0001;
            string myLowerFloorNumberString = string.Format("{0:0.0000}", myLowerFloorNumber);
            WaitForAnElementToShow(webDriver, MainPageElements.inputFieldLowerPrice);
            webDriver.FindElement(MainPageElements.inputFieldLowerPrice).SendKeys(myLowerFloorNumberString);
            webDriver.FindElement(MainPageElements.setNewPriceButton).Click();
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
            Thread.Sleep(20000);
            webDriver.SwitchTo().Window(webDriver.WindowHandles[2]);
        }

        public static void SignTransactionWithMetamask(WebDriver webDriver)
        {
            WaitForAnElementToShow(webDriver, MainPageElements.downArrowMetamask);

            webDriver.FindElement(MainPageElements.downArrowMetamask).Click();
            WaitForAnElementToShow(webDriver, MainPageElements.signMetamaskButton);

            webDriver.FindElement(MainPageElements.signMetamaskButton).Click();

            webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
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

        public static void SaveFloorNumber(WebDriver webDriver, string nftCollection)
        {
            var floorNumbersList = webDriver.FindElements(MainPageElements.floorPriceAllNfts);
            floorNumbersList[0].Click();
            WaitForAnElementToShow(webDriver, MainPageElements.floorPriceInNft);

            MainPageElementsVariables.floorPrice = webDriver.FindElement(MainPageElements.floorPriceInNft).Text;
            MainPageElementsVariables.floorNumber = double.Parse(MainPageElementsVariables.floorPrice);
            GoToCollection(webDriver, nftCollection);
        }



        public static void CalculateMySellNumber(double fees, double myProfit, Offer.Offer collectionType, WebDriver webDriver)
        {
            MainPageElementsVariables.mySellNumber = MainPageElementsVariables.floorNumber - 0.0001;
            string mySellNumberString = string.Format("{0:0.0000}", MainPageElementsVariables.mySellNumber);
            MainPageElementsVariables.mySellNumber = double.Parse(mySellNumberString);
            double myMinSellNumber = CalculateMyMinimumSellNumber(fees, myProfit, collectionType); 
            if(myMinSellNumber > MainPageElementsVariables.mySellNumber)
            {
                var floorNumbersList = webDriver.FindElements(MainPageElements.floorPriceAllNfts);
                for(int i = 0; i < floorNumbersList.Count; i++)
                {
                    string floorNumberString = floorNumbersList[i].Text;
                    double floorNumber = double.Parse(floorNumberString);
                    if(floorNumber - 0.0001 > myMinSellNumber)
                    {
                        MainPageElementsVariables.mySellNumber = floorNumber - 0.001;
                        return;
                    }
                }
                //взимам първият флоор, изваждам 0.0001 от него и ако числото е по - малко от myMinSellNumber, взимам вторият флоор, вадя от него 0.0001
                //и ако числото е по малко от myMinSellNumber, взимам 3тият флоор. И така докато не намеря флоор, който е по - голям от myMinSellNumber.
                //Тогава MainPageElementsVariables.mySellNumber = на това число минус 0.0001.
                //С лист и for loop да го направя да проверява.
            }
        }

        

        public static void CalculatemySellNumberWhenAlreadyNftForSale(WebDriver webDriver)
        {
            Thread.Sleep(3000);
            string mySellNumberWhenAlreadyNftForSale = webDriver.FindElement(By.CssSelector("div[class='TradeStation--price-container'] div[class*='Price--amount']")).Text;
            /*MainPageElements.pattern = @"\d{1,}.\d{1,}";
            Match floorOriginalAfterRegex = Regex.Match(mySellNumberWhenAlreadyNftForSale, MainPageElements.pattern); 
            MainPageElements.mySellNumberWhenAlreadyNftForSaleValue = floorOriginalAfterRegex.Value;*/
            MainPageElementsVariables.mySellNumberWhenAlreadyNftForSaleNumber = double.Parse(mySellNumberWhenAlreadyNftForSale);
        }

        public static void SaveBestOfferNumber(WebDriver webDriver)
        {
            MainPageElementsVariables.bestOffer = webDriver.FindElement(By.XPath("//span[text() = 'WETH']/..")).Text;
            MainPageElementsVariables.pattern = @"\d{1,}.\d{1,}";
            //var rg = new Regex(MainPageElements.pattern);
            Match bestOfferOriginal = Regex.Match(MainPageElementsVariables.bestOffer, MainPageElementsVariables.pattern);
            MainPageElementsVariables.bestOfferNumberValue = bestOfferOriginal.Value;
            MainPageElementsVariables.bestOfferNumber = double.Parse(MainPageElementsVariables.bestOfferNumberValue);
        }

        public static double CalculateMyOfferNumber(double fees, double myProfit, double myOfferNumber)
        {
            
            myOfferNumber = MainPageElementsVariables.bestOfferNumber + 0.0002;
            string myOfferNumberString = String.Format("{0:0.0000}", myOfferNumber);
            myOfferNumber = double.Parse(myOfferNumberString);
            CalculateMyMaxBestOffer(fees, myProfit);
            if (myOfferNumber > MainPageElementsVariables.maxOfferNumber)
            {
                MainPageElementsVariables.isMyOfferOnProfit = false;
            } else
            {
                MainPageElementsVariables.isMyOfferOnProfit = true;
            }        
            MainPageElementsVariables.myOfferNumberString = myOfferNumber.ToString();

            return myOfferNumber;
        }

        public static void SaveMyOfferNumberInFile(Offer.Offer myOffer)
        {
            switch(myOffer.Type)
            {
                case OfferType.VividLimited: 
                    string VividLimitedFile = "K:/OpenSea_Bot_Files/VividLimited.txt";
                    using (StreamWriter sw = File.AppendText(VividLimitedFile))
                    {
                        sw.WriteLine(myOffer.Value.ToString());
                    }
                    break;
                case OfferType.TheLobstars:
                    string TheLobstarsFile = "K:/OpenSea_Bot_Files/TheLobstars.txt";
                    using (StreamWriter sw = File.AppendText(TheLobstarsFile))
                    {
                        sw.WriteLine(myOffer.Value.ToString());
                    }
                    break;
                case OfferType.MutantGrandpaCountryClub:
                    string MutantGrandpaCountryClubFile = "K:/OpenSea_Bot_Files/MutantGrandpaCountryClub.txt";
                    using (StreamWriter sw = File.AppendText(MutantGrandpaCountryClubFile))
                    {
                        sw.WriteLine(myOffer.Value.ToString());
                    }
                    break;
                case OfferType.RetroArcadeCollection:
                    string RetroArcadeCollectionFile = "K:/OpenSea_Bot_Files/RetroArcadeCollection.txt";
                    using (StreamWriter sw = File.AppendText(RetroArcadeCollectionFile))
                    {
                        sw.WriteLine(myOffer.Value.ToString());
                    }
                    break;
                case OfferType.RubberDuckBathParty:
                    string RubberDuckBathPartyFile = "K:/OpenSea_Bot_Files/RubberDuckBathParty.txt";
                    using (StreamWriter sw = File.AppendText(RubberDuckBathPartyFile))
                    {
                        sw.WriteLine(myOffer.Value.ToString());
                    }
                    break;
                case OfferType.AntonymGENESIS:
                    string AntonymGENESISFile = "K:/OpenSea_Bot_Files/AntonymGENESIS.txt";
                    using (StreamWriter sw = File.AppendText(AntonymGENESISFile))
                    {
                        sw.WriteLine(myOffer.Value.ToString());
                    }
                    break;
                case OfferType.AINightbirds:
                    string AINightbirdsFile = "K:/OpenSea_Bot_Files/AINightbirds.txt";
                    using (StreamWriter sw = File.AppendText(AINightbirdsFile))
                    {
                        sw.WriteLine(myOffer.Value.ToString());
                    }
                    break;
                case OfferType.ChildrenofUkiyo:
                    string ChildrenofUkiyoFile = "K:/OpenSea_Bot_Files/ChildrenofUkiyo.txt";
                    using (StreamWriter sw = File.AppendText(ChildrenofUkiyoFile))
                    {
                        sw.WriteLine(myOffer.Value.ToString());
                    }
                    break;
                case OfferType.FlowerLolitaCollections:
                    string FlowerLolitaCollectionsFile = "K:/OpenSea_Bot_Files/FlowerLolitaCollections.txt";
                    using (StreamWriter sw = File.AppendText(FlowerLolitaCollectionsFile))
                    {
                        sw.WriteLine(myOffer.Value.ToString());
                    }
                    break;
                case OfferType.TheMekabots:
                    string TheMekabotsFile = "K:/OpenSea_Bot_Files/TheMekabots.txt";
                    using (StreamWriter sw = File.AppendText(TheMekabotsFile))
                    {
                        sw.WriteLine(myOffer.Value.ToString());
                    }
                    break;
                case OfferType.GirliesNFT:
                    string GirliesNFTFile = "K:/OpenSea_Bot_Files/GirliesNFT.txt";
                    using (StreamWriter sw = File.AppendText(GirliesNFTFile))
                    {
                        sw.WriteLine(myOffer.Value.ToString());
                    }
                    break;
                case OfferType.JapaneseBornApeSociety:
                    string JapaneseBornApeSocietyFile = "K:/OpenSea_Bot_Files/JapaneseBornApeSociety.txt";
                    using (StreamWriter sw = File.AppendText(JapaneseBornApeSocietyFile))
                    {
                        sw.WriteLine(myOffer.Value.ToString());
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
        public static double CalculateMyMinimumSellNumber(double fees, double myProfit, Offer.Offer collectionType) // тук съм започнал 
        {
            double feesPlusMyProfitPercentage = fees + myProfit;
            double feesPlusMyProfitNumber = feesPlusMyProfitPercentage / 100;
            string myOfferNumberString;
            //string myOfferNumber = File.ReadAllText("K:/OpenSea_Bot_Files/VividLimited.txt");
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
                default:
                    myOfferNumberString = "0";
                    break;
            }
            double myOfferNumber = double.Parse(myOfferNumberString);
            double percentage = myOfferNumber * feesPlusMyProfitNumber;
            double myMinSellNumber = myOfferNumber + percentage;
            return myMinSellNumber;
        }

        

        public static void CheckIfWethIsEnough(WebDriver webDriver)
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
                double wEthNumberToSwap = myOfferNumber + 0.0008;
                string wEthNumberToSwapString = String.Format("{0:0.0000}", wEthNumberToSwap);
                Thread.Sleep(3000);
                var fieldForSwapingWeth = webDriver.FindElements(By.CssSelector("input[class*='Input-sc']"));
                fieldForSwapingWeth[0].Click();
                fieldForSwapingWeth[0].SendKeys(Keys.Control + "a");
                fieldForSwapingWeth[0].SendKeys(Keys.Backspace);
                fieldForSwapingWeth[0].SendKeys(wEthNumberToSwapString);
                webDriver.FindElement(MainPageElements.wrapEthButton).Click();
                Thread.Sleep(3000);
                webDriver.SwitchTo().Window(webDriver.WindowHandles[2]);
                WaitForAnElementToShow(webDriver, MainPageElements.confirmButtonMetamask);
                webDriver.FindElement(MainPageElements.confirmButtonMetamask).Click();
                webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
                Thread.Sleep(4000);
                webDriver.Navigate().GoToUrl(NftCollection);

            }
        }

        public static void SetLowerPriceForSaleIfNeeded(WebDriver webDriver)
        {
            if (MainPageElementsVariables.mySellNumberWhenAlreadyNftForSaleNumber > MainPageElementsVariables.floorNumber)
            {
                ClickLowerPriceButton(webDriver);
                Thread.Sleep(3000);
                SetLowerPrice(webDriver);
                Thread.Sleep(5000);
                webDriver.SwitchTo().Window(webDriver.WindowHandles[2]);
                SignTransactionWithMetamask(webDriver);
            }
        }

        public static void SaveSevenDayAverageSellNumber(WebDriver webDriver, double PercentageOverAvgPrice)
        {
            webDriver.FindElement(MainPageElements.activity).Click();
            WaitForAnElementToShow(webDriver, MainPageElements.arrowDownTimePeriod);
            Thread.Sleep(4000);
            webDriver.FindElement(MainPageElements.arrowDownTimePeriod).Click();
            webDriver.FindElement(MainPageElements.lastSevenDaysPeriod).Click();
            Thread.Sleep(2000);
            SaveSevenDaysAveragePrice(webDriver);
            double PercentageOverAvgPriceInNumber = PercentageOverAvgPrice / 100;
            double Percentage = MainPageElementsVariables.sevenDaysAveragePriceNumber * PercentageOverAvgPriceInNumber;
            MainPageElementsVariables.maxAvgPrice = MainPageElementsVariables.sevenDaysAveragePriceNumber + Percentage;
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
            MainPageElementsVariables.sevenDaysAveragePriceNumber = double.Parse(MainPageElementsVariables.sevenDaysAveragePriceStringAfterRegexValue);
        }


        public static void BuyFloorIfCheap(WebDriver webDriver, string collection, double fees, double profit)
        {            
            
            double feesPlusProfit = fees + profit;
            
            var floorNumbersList = webDriver.FindElements(MainPageElements.floorPriceAllNfts);
            string floorPriceString = floorNumbersList[0].Text;
            string secondFloorPriceString = floorNumbersList[1].Text;
            double floorPrice = double.Parse(floorPriceString);
            double secondFloorPrice = double.Parse(secondFloorPriceString);
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
