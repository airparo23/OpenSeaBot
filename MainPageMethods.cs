using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OpenSeaBot
{
    internal static class MainPageMethods
    {
        public static void WaitForAnElementToShow(WebDriver webDriver, By element)
        {
            WebDriverWait w = new WebDriverWait(webDriver, TimeSpan.FromSeconds(120));
            w.Until(ExpectedConditions.ElementExists(element)); // тук след точката трябва да сложа елемента
        }

        public static void ClickTermsOfUseButton(WebDriver webDriver, By terms)
        {
            webDriver.FindElement(terms).Click(); // тук след точката трябва да сложа елемента

        }

        public static void StartMetamask(WebDriver driver, By getStarted, By importWallet, By noThanks)
        {
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
        }

        public static void ClickCollectionOfferButton(WebDriver driver)
        {
            WaitForAnElementToShow(driver, MainPageElements.makeCollectionOfferButton);
            driver.FindElement(MainPageElements.makeCollectionOfferButton).Click();
        }

        public static void IsNftBought(WebDriver webDriver, By Nft)
        {
            GoToCollection(webDriver, MainPageElements.myAccountUrl);
            GoToCollection(webDriver, MainPageElements.myAccountUrl);

            List<IWebElement> ethlizardNFTelementList = new List<IWebElement>();
            ethlizardNFTelementList.AddRange(webDriver.FindElements(Nft));
            if (ethlizardNFTelementList.Count > 0)
            {
                MainPageElements.isVisible = true;
            }
            else
            {
                MainPageElements.isVisible = false;
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
            webDriver.FindElement(MainPageElements.sellButton).Click();
        }

        public static void TypeMySellNumberAndCompleteListing(WebDriver webDriver)
        {
            string mySellNumberString = MainPageElements.mySellNumber.ToString();
            WaitForAnElementToShow(webDriver, MainPageElements.sellPriceField);
            webDriver.FindElement(MainPageElements.sellPriceField).SendKeys(mySellNumberString);
            webDriver.FindElement(MainPageElements.completeListingButton).Click();
            Thread.Sleep(4000);
        }
        public static void ConfirmSellInMetamask(WebDriver webDriver)
        {
            WaitForAnElementToShow(webDriver, MainPageElements.downArrowMetamask);

            webDriver.FindElement(MainPageElements.downArrowMetamask).Click();
            WaitForAnElementToShow(webDriver, MainPageElements.signMetamaskButton);

            webDriver.FindElement(MainPageElements.signMetamaskButton).Click();
        }
        public static void ClickLowerPriceButton(WebDriver webDriver)
        {
            webDriver.FindElement(MainPageElements.lowerPriceButton).Click();
        }

        public static void SetLowerPrice(WebDriver webDriver)
        {
            double myLowerFloorNumber = MainPageElements.floorNumber - 0.01;
            string myLowerFloorNumberString = myLowerFloorNumber.ToString();
            WaitForAnElementToShow(webDriver, MainPageElements.inputFieldLowerPrice);
            webDriver.FindElement(MainPageElements.inputFieldLowerPrice).SendKeys(myLowerFloorNumberString);
            webDriver.FindElement(MainPageElements.setNewPriceButton).Click();
        }

        public static void TypeMyOfferNumber(WebDriver webDriver, string myOfferNumber)
        {
            webDriver.FindElement(MainPageElements.amountField).SendKeys(myOfferNumber);
            var offerPeriodDownArrowList = webDriver.FindElements(MainPageElements.offerPeriodDownArrow);
            offerPeriodDownArrowList[2].Click();
            Thread.Sleep(1000);
            webDriver.FindElement(MainPageElements.offerPeriodTwelveHours).Click();
        }

        public static void ClickMyOfferButton(WebDriver webDriver)
        {
            webDriver.FindElement(MainPageElements.makeOfferButton).Click();
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
                MainPageElements.isSellButtonVisible = true;
            } else
            {
                MainPageElements.isSellButtonVisible = false;
            }


        }

        public static void IsCollectionUnreviewed(WebDriver webDriver)
        {
            List<IWebElement> isUnreviewedCollectionList = new List<IWebElement>();
            isUnreviewedCollectionList.AddRange(webDriver.FindElements(MainPageElements.isCollectionReviewed)); 
            if (isUnreviewedCollectionList.Count > 0)
            {
                MainPageElements.isUnreviewedCollection = true;
            } else
            {
                MainPageElements.isUnreviewedCollection = false;
            }

        }

        public static void SaveFloorNumber(WebDriver webDriver)
        {
            MainPageElements.floorPrice = webDriver.FindElement(By.XPath("//p[contains(normalize-space(text()), 'Floor price')]")).Text;
            MainPageElements.pattern = @"\d{1,}.\d{1,}";
            //var rg1 = new Regex(MainPageElements.pattern);
            Match floorOriginalAfterRegex = Regex.Match(MainPageElements.floorPrice, MainPageElements.pattern);
            MainPageElements.floorNumberValue = floorOriginalAfterRegex.Value;
            MainPageElements.floorNumber = double.Parse(MainPageElements.floorNumberValue);
        }

        public static void CalculateMySellNumber()
        {
            MainPageElements.mySellNumber = MainPageElements.floorNumber - 0.01;
        }

        public static void CalculatemySellNumberWhenAlreadyNftForSale(WebDriver webDriver)
        {
            Thread.Sleep(3000);
            string mySellNumberWhenAlreadyNftForSale = webDriver.FindElement(By.XPath("//div[@class='sc-1a9c68u-0 jdhmum Price--main TradeStation--price']")).Text;
            MainPageElements.pattern = @"\d{1,}.\d{1,}";
            //var rg2 = new Regex(MainPageElements.pattern);
            Match floorOriginalAfterRegex = Regex.Match(mySellNumberWhenAlreadyNftForSale, MainPageElements.pattern); 
            MainPageElements.mySellNumberWhenAlreadyNftForSaleValue = floorOriginalAfterRegex.Value;
            MainPageElements.mySellNumberWhenAlreadyNftForSaleNumber = double.Parse(MainPageElements.mySellNumberWhenAlreadyNftForSaleValue);
        }

        public static void SaveBestOfferNumber(WebDriver webDriver)
        {
            MainPageElements.bestOffer = webDriver.FindElement(By.XPath("//span[text() = 'WETH']/..")).Text;
            MainPageElements.pattern = @"\d{1,}.\d{1,}";
            //var rg = new Regex(MainPageElements.pattern);
            Match bestOfferOriginal = Regex.Match(MainPageElements.bestOffer, MainPageElements.pattern); 
            MainPageElements.bestOfferNumberValue = bestOfferOriginal.Value;
            MainPageElements.bestOfferNumber = double.Parse(MainPageElements.bestOfferNumberValue);
        }

        public static void CalculateMyOfferNumber(WebDriver webDriver, double fees, double myProfit)
        {

            MainPageElements.myOfferNumber = MainPageElements.bestOfferNumber + 0.0002;
            CalculateMyMaxBestOffer(webDriver, fees, myProfit);
            if (MainPageElements.myOfferNumber > MainPageElements.maxOfferNumber)
            {
                MainPageElements.myOfferNumber = MainPageElements.maxOfferNumber;
            }
            MainPageElements.myPreviousOfferNumber = MainPageElements.myOfferNumber; // това го запазвам, за да мога да го ползвам след следващият интервал, за да направя проверка с него. не съм
            MainPageElements.myOfferNumberString = MainPageElements.myOfferNumber.ToString(); // сигурен дали ще работи, тъй като трябва да се направи интервала първо. проверката е малко по - нагоре
                                                                                              // от този метод
        }

        public static void CalculateMyMaxBestOffer(WebDriver webDriver, double fees, double myProfit)
        {
            double feesPlusMyProfitPercentage = fees + myProfit;
            double feesPlusMyProfitNumber = feesPlusMyProfitPercentage / 100;
            double feesAndProfit = MainPageElements.floorNumber * feesPlusMyProfitNumber;
            MainPageElements.maxOfferNumber = MainPageElements.floorNumber - feesAndProfit;


        }

        public static void CheckIfWethIsEnough(WebDriver webDriver)
        {
            if (webDriver.FindElement(MainPageElements.notEnoughWethMessage).Displayed) 
            {
                MainPageElements.isNotEnoughWeth = true;
            }
            else
            {
                MainPageElements.isNotEnoughWeth = false;

            }
        }

        public static void CheckBoxIfUnreviewedCollection(WebDriver webDriver)
        {
            if (MainPageElements.isUnreviewedCollection)
            {
                webDriver.FindElement(MainPageElements.checkBoxReviewedCollection).Click();
            }
        }

        public static void SwapWethForEthIfNeeded(WebDriver webDriver)
        {
            if (MainPageElements.isNotEnoughWeth)
            {                
                webDriver.FindElement(MainPageElements.addWethButton).Click();
                double wEthNumberToSwap = MainPageElements.myOfferNumber + 0.05;
                string wEthNumberToSwapString = wEthNumberToSwap.ToString();
                Thread.Sleep(3000);
                var fieldForSwapingWeth = webDriver.FindElements(By.XPath("//input[@class='Input-sc-1e35ws5-0 leKAIy TokenInput__ValueInput-sc-8sl0d3-1 heITGp']"));
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
                webDriver.Navigate().GoToUrl(MainPageElements.ethlizardCollection);
                
            }
        }

        public static void SetLowerPriceForSaleIfNeeded(WebDriver webDriver)
        {
            if (MainPageElements.mySellNumberWhenAlreadyNftForSaleNumber > MainPageElements.floorNumber)
            {
                ClickLowerPriceButton(webDriver);
                Thread.Sleep(3000);
                SetLowerPrice(webDriver);
            }
        }

        public static void SaveSevenDayAverageSellNumber(WebDriver webDriver, double PercentageOverAvgPrice)
        {
            if(MainPageElements.timerAvgPrice >= 100)
            {
                webDriver.FindElement(MainPageElements.activity).Click();
                Thread.Sleep(2000);
                webDriver.FindElement(MainPageElements.arrowDownTimePeriod).Click();
                webDriver.FindElement(MainPageElements.lastSevenDaysPeriod).Click();
                Thread.Sleep(2000);
                SaveSevenDaysAveragePrice(webDriver);
                double PercentageOverAvgPriceInNumber = PercentageOverAvgPrice / 100;
                double Percentage = MainPageElements.sevenDaysAveragePriceNumber * PercentageOverAvgPriceInNumber;
                MainPageElements.maxAvgPrice = MainPageElements.sevenDaysAveragePriceNumber + Percentage;
                webDriver.FindElement(MainPageElements.items).Click();
                MainPageElements.timerAvgPrice = 0;
            }
            
        }

        public static void SaveSevenDaysAveragePrice(WebDriver webDriver)
        {
            var saveSevenDaysAveragePriceList = webDriver.FindElements(MainPageElements.SevenDaysAveragePrice);
            MainPageElements.sevenDaysAveragePriceString = saveSevenDaysAveragePriceList[0].Text;
            MainPageElements.pattern = @"\d{1,}.\d{1,}";
            Match SevenDaysAveragePriceStringAfterRegex = Regex.Match(MainPageElements.sevenDaysAveragePriceString, MainPageElements.pattern);
            MainPageElements.sevenDaysAveragePriceStringAfterRegexValue = SevenDaysAveragePriceStringAfterRegex.Value;
            MainPageElements.sevenDaysAveragePriceNumber = double.Parse(MainPageElements.sevenDaysAveragePriceStringAfterRegexValue);
        }

        public static void TimerAvgPrice()
        {
            //ако колекциите се въртят през 5 мин - MainPageElements.TimerAvgPrice == 100, ако се въртят през 10 мин - MainPageElements.TimerAvgPrice == 50
            MainPageElements.timerAvgPrice = MainPageElements.timerAvgPrice + 1;
        }

        public static void BuyFloorIfCheap(WebDriver webDriver, string collection, double fees, double profit)
        {
            ClickCollectionOfferButton(webDriver);
            Thread.Sleep(4000);
            SaveFloorNumber(webDriver);
            webDriver.FindElement(MainPageElements.closeWindowElement).Click();
            WaitForAnElementToShow(webDriver, MainPageElements.activity);
            webDriver.FindElement(MainPageElements.activity).Click();
            Thread.Sleep(2000);
            webDriver.FindElement(MainPageElements.arrowDownTimePeriod).Click();
            webDriver.FindElement(MainPageElements.lastSevenDaysPeriod).Click();
            Thread.Sleep(2000);
            SaveSevenDaysAveragePrice(webDriver);
            webDriver.FindElement(MainPageElements.items).Click();
            double feesPlusProfit = fees + profit;
            if((MainPageElements.floorNumber / MainPageElements.sevenDaysAveragePriceNumber) * 100 < 100 - feesPlusProfit) 
            {
                var floorNftsList = webDriver.FindElements(By.XPath(String.Format(MainPageElements.floorNftsLocator, MainPageElements.floorNumber)));
                Thread.Sleep(6000);
                floorNftsList[1].Click();
                WaitForAnElementToShow(webDriver, MainPageElements.buyNowButton);
                webDriver.FindElement(MainPageElements.buyNowButton).Click();
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
