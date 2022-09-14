using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSeaBot.Collections
{
    internal static class Spellfire
    {
       public static void SpellfireCollection(WebDriver webDriver)
        {
            try
            {
                MainPageMethods.IsNftBought(webDriver, MainPageElements.ethlizardNFT);
                MainPageMethods.TimerAvgPrice();
                //ако имаме NFT, влизаме в него и проверяваме дали вече е пуснато за продажба или не
                if (MainPageElements.isVisible)
                {
                    MainPageMethods.GoIntoNft(webDriver, MainPageElements.spellfireNftToBeClicked);

                    MainPageMethods.IsNftAlreadyForSale(webDriver, MainPageElements.isSellButtonVisible);
                    //ако не е пуснато за продажба, го пускаме за продажба 
                    if (MainPageElements.isSellButtonVisible)
                    {
                        MainPageMethods.ClickCollectionLink(webDriver);
                        MainPageMethods.BuyFloorIfCheap(webDriver, MainPageElements.spellfireCollection, 7.5, 8);
                        MainPageMethods.GoToCollection(webDriver, MainPageElements.spellfireCollection);
                        MainPageMethods.ClickCollectionOfferButton(webDriver);
                        Thread.Sleep(3000);
                        MainPageMethods.IsCollectionUnreviewed(webDriver);
                        MainPageMethods.CheckBoxIfUnreviewedCollection(webDriver);
                        Thread.Sleep(3000);
                        MainPageMethods.SaveFloorNumber(webDriver);
                        MainPageMethods.CalculateMySellNumber();
                        MainPageMethods.GoToCollection(webDriver, MainPageElements.myAccountUrl);
                        MainPageMethods.GoIntoNft(webDriver, MainPageElements.spellfireNftToBeClicked);
                        MainPageMethods.ClickSellButton(webDriver);
                        MainPageMethods.TypeMySellNumberAndCompleteListing(webDriver);
                        webDriver.SwitchTo().Window(webDriver.WindowHandles[2]);
                        MainPageMethods.ConfirmSellInMetamask(webDriver);
                        webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
                    }
                    else
                    {
                        // ако е пуснато за продажба
                        MainPageMethods.GoToCollection(webDriver, MainPageElements.spellfireCollection);
                        MainPageMethods.BuyFloorIfCheap(webDriver, MainPageElements.spellfireCollection, 7.5, 8);
                        MainPageMethods.GoToCollection(webDriver, MainPageElements.spellfireCollection);
                        MainPageMethods.ClickCollectionOfferButton(webDriver);
                        Thread.Sleep(3000);
                        MainPageMethods.IsCollectionUnreviewed(webDriver);
                        MainPageMethods.CheckBoxIfUnreviewedCollection(webDriver);
                        Thread.Sleep(3000);
                        MainPageMethods.SaveFloorNumber(webDriver);
                        MainPageMethods.GoToCollection(webDriver, MainPageElements.myAccountUrl);
                        MainPageMethods.GoIntoNft(webDriver, MainPageElements.spellfireNftToBeClicked);
                        MainPageMethods.CalculatemySellNumberWhenAlreadyNftForSale(webDriver);
                        MainPageMethods.SetLowerPriceForSaleIfNeeded(webDriver);
                    }
                    // от тук трябва да отидем в профил и да търсим следващото НФТ дали го имаме
                }
                else
                {
                    //започваме да пускаме оферта, като първо проверяваме колко е числото на Best offer-а
                    MainPageMethods.GoToCollection(webDriver, MainPageElements.ethlizardCollection);
                    MainPageMethods.BuyFloorIfCheap(webDriver, MainPageElements.ethlizardCollection, 7.5, 8);
                    MainPageMethods.GoToCollection(webDriver, MainPageElements.ethlizardCollection);
                    MainPageMethods.SaveSevenDayAverageSellNumber(webDriver, 8);
                    MainPageMethods.ClickCollectionOfferButton(webDriver);
                    Thread.Sleep(4000);
                    MainPageMethods.SaveFloorNumber(webDriver);
                    MainPageMethods.SaveBestOfferNumber(webDriver);

                    if (MainPageElements.bestOfferNumber > MainPageElements.myPreviousOfferNumber) // проверяваме дали best offer-а е по голям от моят последен best offer и ако е - продължавам
                    {
                        //проверявам дали Best offer-а е с поне 15% по - ниска от Floor price-а
                        if ((MainPageElements.bestOfferNumber / MainPageElements.floorNumber) * 100 < 85 && MainPageElements.maxAvgPrice > MainPageElements.floorNumber)
                        {
                            //продължавам с пускането на офертата
                            MainPageMethods.CalculateMyOfferNumber(webDriver, 10, 10);
                            MainPageMethods.TypeMyOfferNumber(webDriver, MainPageElements.myOfferNumberString);
                            MainPageMethods.CheckIfWethIsEnough(webDriver);
                            MainPageMethods.SwapWethForEthIfNeeded(webDriver); //тук някъде да променя затварянето на прозореца
                            MainPageMethods.ClickMyOfferButton(webDriver);
                            MainPageMethods.SignTransactionWithMetamask(webDriver);
                        }
                    }

                }

            }
            catch { Console.WriteLine("Нещо се счупи!"); }

        }
    }
}
