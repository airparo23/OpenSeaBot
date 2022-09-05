using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSeaBot.Collections
{
    internal class Ethlizards
    {
        /*public static void EthlizardCollection(WebDriver webDriver, bool isVisible)
        {
            webDriver.Navigate().GoToUrl("https://opensea.io/account");
            webDriver.Navigate().GoToUrl("https://opensea.io/account");

            List<IWebElement> ethlizardNFTelementList = new List<IWebElement>();
            ethlizardNFTelementList.AddRange(webDriver.FindElements(MainPageElements.ethlizardNFT));
            if (ethlizardNFTelementList.Count > 0)
            {
                isVisible = true;
            }
            else
            {
                isVisible = false;
            }

            //ако имаме NFT, влизаме в него и проверяваме дали вече е пуснато за продажба или не
            if (isVisible)
            {
                webDriver.FindElement(MainPageElements.spellfireNftToBeClicked).Click();
                MainPageMethods.WaitForAnElementToShow(webDriver, MainPageElements.sellButton);

                List<IWebElement> sellButtonelementList = new List<IWebElement>();
                sellButtonelementList.AddRange(webDriver.FindElements(MainPageElements.sellButton));
                if (sellButtonelementList.Count > 0)
                {
                    isSellButtonVisible = true;
                }
                else
                {
                    isSellButtonVisible = false;
                }

                //ако не е пуснато за продажба, го пускаме за продажба 

                //също така ако е пуснато за продажба трябва да направя да отива в колекцията и да види дали някой ме е подбил и ако е - да намали цената,
                //за да е най - ниската
                if (isSellButtonVisible)
                {
                    webDriver.FindElement(MainPageElements.collectionLink).Click();
                    MainPageMethods.WaitForAnElementToShow(webDriver, MainPageElements.makeCollectionOfferButton);

                    webDriver.FindElement(MainPageElements.makeCollectionOfferButton).Click();

                    //MainPageMethods.GetFloorPrice(webDriver, floorPrice, pattern, floorNumberValue, floorNumber, mySellNumber, MainPageElements.checkBoxReviewedCollection);
                    Thread.Sleep(3000);

                    bool isUnreviewedCollection;
                    List<IWebElement> isUnreviewedCollectionList = new List<IWebElement>();
                    isUnreviewedCollectionList.AddRange(webDriver.FindElements(MainPageElements.isCollectionReviewed));
                    if (isUnreviewedCollectionList.Count > 0)
                    {
                        isUnreviewedCollection = true;
                    }
                    else
                    {
                        isUnreviewedCollection = false;
                    }
                    if (isUnreviewedCollection)
                    {
                        webDriver.FindElement(MainPageElements.checkBoxReviewedCollection).Click();
                    }

                    Thread.Sleep(3000);
                    floorPrice = webDriver.FindElement(By.XPath("//p[contains(normalize-space(text()), 'Floor price')]")).Text;
                    pattern = @"\d{1,}.\d{1,}";
                    var rg1 = new Regex(pattern);
                    Match floorOriginal1 = Regex.Match(floorPrice, pattern);
                    floorNumberValue = floorOriginal1.Value;
                    floorNumber = double.Parse(floorNumberValue);
                    mySellNumber = floorNumber - 0.01;

                    webDriver.Navigate().GoToUrl("https://opensea.io/account");
                    webDriver.FindElement(MainPageElements.spellfireNftToBeClicked).Click();
                    MainPageMethods.WaitForAnElementToShow(webDriver, MainPageElements.sellButton);
                    webDriver.FindElement(MainPageElements.sellButton).Click();
                    string mySellNumberString = mySellNumber.ToString();
                    webDriver.FindElement(MainPageElements.sellPriceField).SendKeys(mySellNumberString);
                    webDriver.FindElement(MainPageElements.completeListingButton).Click();
                    webDriver.SwitchTo().Window(webDriver.WindowHandles[2]);
                    MainPageMethods.WaitForAnElementToShow(webDriver, MainPageElements.downArrowMetamask);

                    webDriver.FindElement(MainPageElements.downArrowMetamask).Click();
                    MainPageMethods.WaitForAnElementToShow(webDriver, MainPageElements.signMetamaskButton);

                    webDriver.FindElement(MainPageElements.signMetamaskButton).Click();
                    webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
                }
                else
                {
                    // ако е пуснато за продажба

                    webDriver.Navigate().GoToUrl(spellfireCollection);
                    webDriver.FindElement(MainPageElements.makeCollectionOfferButton).Click();

                    //MainPageMethods.GetFloorPrice(webDriver, floorPrice, pattern, floorNumberValue, floorNumber, mySellNumber, MainPageElements.checkBoxReviewedCollection);
                    Thread.Sleep(3000);

                    bool isUnreviewedCollection;
                    List<IWebElement> isUnreviewedCollectionList = new List<IWebElement>();
                    isUnreviewedCollectionList.AddRange(webDriver.FindElements(MainPageElements.isCollectionReviewed));
                    if (isUnreviewedCollectionList.Count > 0)
                    {
                        isUnreviewedCollection = true;
                    }
                    else
                    {
                        isUnreviewedCollection = false;
                    }
                    if (isUnreviewedCollection)
                    {
                        webDriver.FindElement(MainPageElements.checkBoxReviewedCollection).Click();
                    }

                    Thread.Sleep(3000);

                    floorPrice = webDriver.FindElement(By.XPath("//p[contains(normalize-space(text()), 'Floor price')]")).Text;
                    pattern = @"\d{1,}.\d{1,}";
                    var rg = new Regex(pattern);
                    Match floorOriginal = Regex.Match(floorPrice, pattern);
                    floorNumberValue = floorOriginal.Value;
                    floorNumber = double.Parse(floorNumberValue);
                    //запазваме числото, за което го продаваме

                    webDriver.Navigate().GoToUrl("https://opensea.io/account");
                    webDriver.FindElement(MainPageElements.spellfireNftToBeClicked).Click();
                    string mySellNumberWhenAlreadyNftForSale = webDriver.FindElement(By.XPath("//div[@class='sc-1a9c68u-0 jdhmum Price--main TradeStation--price']")).Text;
                    pattern = @"\d{1,}.\d{1,}";
                    var rg2 = new Regex(pattern);
                    Match floorOriginal2 = Regex.Match(mySellNumberWhenAlreadyNftForSale, pattern);
                    mySellNumberWhenAlreadyNftForSaleValue = floorOriginal2.Value;
                    mySellNumberWhenAlreadyNftForSaleNumber = double.Parse(mySellNumberWhenAlreadyNftForSaleValue);

                    if (mySellNumberWhenAlreadyNftForSaleNumber > floorNumber)
                    {
                        double myLowerFloorNumber = floorNumber - 0.01;
                        string myLowerFloorNumberString = myLowerFloorNumber.ToString();
                        webDriver.FindElement(MainPageElements.lowerPriceButton).Click();
                        MainPageMethods.WaitForAnElementToShow(webDriver, MainPageElements.inputFieldLowerPrice);
                        webDriver.FindElement(MainPageElements.inputFieldLowerPrice).SendKeys(myLowerFloorNumberString);
                        webDriver.FindElement(MainPageElements.setNewPriceButton).Click();
                    }

                }
                // от тук трябва да отидем в профил и да търсим следващото НФТ дали го имаме
            }
            else
            {
                //започваме да пускаме оферта, като първо проверяваме колко е числото на Best offer-а

                webDriver.Navigate().GoToUrl(ethlizardCollection);

                MainPageMethods.WaitForAnElementToShow(webDriver, MainPageElements.makeCollectionOfferButton);
                webDriver.FindElement(MainPageElements.makeCollectionOfferButton).Click();
                Thread.Sleep(4000);


                floorPrice = webDriver.FindElement(By.XPath("//p[contains(normalize-space(text()), 'Floor price')]")).Text;
                bestOffer = webDriver.FindElement(By.XPath("//span[text() = 'WETH']/..")).Text;
                pattern = @"\d{1,}.\d{1,}";
                var rg = new Regex(pattern);
                Match floorOriginal = Regex.Match(floorPrice, pattern);
                Match bestOfferOriginal = Regex.Match(bestOffer, pattern);

                floorNumberValue = floorOriginal.Value;
                string bestOfferNumberValue = bestOfferOriginal.Value;

                floorNumber = double.Parse(floorNumberValue);

                double bestOfferNumber = double.Parse(bestOfferNumberValue);
                if (bestOfferNumber > myPreviousOfferNumber) // проверяваме дали best offer-а е по голям от моят последен best offer и ако е - продължавам
                {
                    //проверявам дали Best offer-а е с поне 10% по - ниска от Floor price-а
                    if (bestOfferNumber / floorNumber < 90)
                    {
                        //продължавам с пускането на офертата
                        double myOfferNumber = bestOfferNumber + 0.0002; // < MY OFFER NUMBER ----------------------------------
                        myPreviousOfferNumber = myOfferNumber;
                        string myOfferNumberString = myOfferNumber.ToString();
                        webDriver.FindElement(MainPageElements.amountField).SendKeys(myOfferNumberString);


                        //проверявам дали имаме достатъчно wETH, ако имам - продължавам, ако нямам - сменям ETH за wETH
                        bool isNotEnoughEth;
                        if (webDriver.FindElement(MainPageElements.notEnoughWethMessage).Displayed)
                        {
                            isNotEnoughEth = true;
                        }
                        else
                        {
                            isNotEnoughEth = false;

                        }
                        //ако нямам достатъчно wETH - сменям ETH за wETH
                        if (isNotEnoughEth)
                        {
                            webDriver.FindElement(MainPageElements.addWethButton).Click();
                            double wEthNumberToSwap = myOfferNumber + 0.05;
                            string wEthNumberToSwapString = wEthNumberToSwap.ToString();
                            Thread.Sleep(3000);
                            ReadOnlyCollection<IWebElement> fieldForSwapingWeth = webDriver.FindElements(By.XPath("//input[@class='Input-sc-1e35ws5-0 leKAIy TokenInput__ValueInput-sc-8sl0d3-1 heITGp']"));
                            fieldForSwapingWeth[0].Click();
                            fieldForSwapingWeth[0].SendKeys(Keys.Control + "a");
                            fieldForSwapingWeth[0].SendKeys(Keys.Backspace);

                            fieldForSwapingWeth[0].SendKeys(wEthNumberToSwapString);

                            webDriver.FindElement(MainPageElements.wrapEthButton).Click();
                            webDriver.SwitchTo().Window(webDriver.WindowHandles[2]);
                            MainPageMethods.WaitForAnElementToShow(webDriver, MainPageElements.confirmButtonMetamask);
                            webDriver.FindElement(MainPageElements.confirmButtonMetamask).Click();
                            webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
                            webDriver.Navigate().GoToUrl(ethlizardCollection);

                        }

                        webDriver.FindElement(MainPageElements.makeOfferButton).Click();

                        webDriver.SwitchTo().Window(webDriver.WindowHandles[2]);
                        MainPageMethods.WaitForAnElementToShow(webDriver, MainPageElements.downArrowMetamask);

                        webDriver.FindElement(MainPageElements.downArrowMetamask).Click();
                        MainPageMethods.WaitForAnElementToShow(webDriver, MainPageElements.signMetamaskButton);

                        webDriver.FindElement(MainPageElements.signMetamaskButton).Click();

                        webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);

                    }
                }

            }
        }*/
    }
}
