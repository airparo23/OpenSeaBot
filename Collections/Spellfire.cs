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
       public static void SpellfireCollection(WebDriver webDriver, By Nft, By NftToBeClicked, string NftCollection, string CollectionName, double fees, double profit)
        {
            try
            {
                MainPageMethods.IsNftBought(webDriver, Nft);
                MainPageMethods.TimerAvgPrice();
                //ако имаме NFT, влизаме в него и проверяваме дали вече е пуснато за продажба или не
                if (MainPageElements.isVisible)
                {
                    MainPageMethods.GoIntoNft(webDriver, NftToBeClicked);

                    MainPageMethods.IsNftAlreadyForSale(webDriver, MainPageElements.isSellButtonVisible);
                    //ако не е пуснато за продажба, го пускаме за продажба 
                    if (MainPageElements.isSellButtonVisible)
                    {
                        MainPageMethods.ClickCollectionLink(webDriver);
                        MainPageMethods.BuyFloorIfCheap(webDriver, NftCollection, fees, profit);
                        MainPageMethods.GoToCollection(webDriver, NftCollection);
                        MainPageMethods.ClickCollectionOfferButton(webDriver);
                        Thread.Sleep(3000);
                        MainPageMethods.IsCollectionUnreviewed(webDriver);
                        MainPageMethods.CheckBoxIfUnreviewedCollection(webDriver);
                        Thread.Sleep(3000);
                        MainPageMethods.SaveFloorNumber(webDriver);
                        MainPageMethods.CalculateMySellNumber();
                        MainPageMethods.GoToCollection(webDriver, MainPageElements.myAccountUrl);
                        MainPageMethods.GoIntoNft(webDriver, NftToBeClicked);
                        MainPageMethods.ClickSellButton(webDriver);
                        MainPageMethods.TypeMySellNumberAndCompleteListing(webDriver);
                        webDriver.SwitchTo().Window(webDriver.WindowHandles[2]);
                        MainPageMethods.ConfirmSellInMetamask(webDriver);
                        webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
                    }
                    else
                    {
                        // ако е пуснато за продажба
                        MainPageMethods.GoToCollection(webDriver, NftCollection);
                        MainPageMethods.BuyFloorIfCheap(webDriver, NftCollection, fees, profit);
                        MainPageMethods.GoToCollection(webDriver, NftCollection);
                        MainPageMethods.ClickCollectionOfferButton(webDriver);
                        Thread.Sleep(3000);
                        MainPageMethods.IsCollectionUnreviewed(webDriver);
                        MainPageMethods.CheckBoxIfUnreviewedCollection(webDriver);
                        Thread.Sleep(3000);
                        MainPageMethods.SaveFloorNumber(webDriver);
                        MainPageMethods.GoToCollection(webDriver, MainPageElements.myAccountUrl);
                        MainPageMethods.GoIntoNft(webDriver, NftToBeClicked);
                        MainPageMethods.CalculatemySellNumberWhenAlreadyNftForSale(webDriver);
                        MainPageMethods.SetLowerPriceForSaleIfNeeded(webDriver);
                    }
                    // от тук трябва да отидем в профил и да търсим следващото НФТ дали го имаме
                }
                else
                {
                    //започваме да пускаме оферта, като първо проверяваме колко е числото на Best offer-а
                    MainPageMethods.GoToCollection(webDriver, NftCollection);
                    MainPageMethods.BuyFloorIfCheap(webDriver, NftCollection, fees, profit);
                    MainPageMethods.GoToCollection(webDriver, NftCollection);
                    MainPageMethods.SaveSevenDayAverageSellNumber(webDriver, profit);
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
                            MainPageMethods.CalculateMyOfferNumber(webDriver, fees, profit + 2);
                            MainPageMethods.TypeMyOfferNumber(webDriver, MainPageElements.myOfferNumberString);
                            MainPageMethods.CheckIfWethIsEnough(webDriver);
                            MainPageMethods.SwapWethForEthIfNeeded(webDriver); //тук някъде да променя затварянето на прозореца
                            MainPageMethods.ClickMyOfferButton(webDriver);
                            MainPageMethods.SignTransactionWithMetamask(webDriver);
                        }
                    }

                }

            }
            catch {
                MainPageMethods.GoToCollection(webDriver, MainPageElements.myAccountUrl);
                TestContext.Progress.WriteLine("Нещо се счупи в {0} в {1}!", CollectionName, DateTime.Now); }

        }
    }
}
