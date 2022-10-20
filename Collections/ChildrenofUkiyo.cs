using OpenQA.Selenium;
using OpenSeaBot.ElementsAndVariables;
using OpenSeaBot.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSeaBot.Collections
{
    internal static class ChildrenofUkiyo
    {
        public static void ChildrenofUkiyoCollection(
           WebDriver webDriver,
           By Nft,
           By NftToBeClicked,
           string NftCollection,
           double fees,
           double profit)
        {
            MainPageMethods.GoToCollection(webDriver, MainPageElements.myAccountUrl);
            MainPageMethods.GoToCollection(webDriver, MainPageElements.myAccountUrl);
            MainPageMethods.IsNftBought(webDriver, Nft);
            //ако имаме NFT, влизаме в него и проверяваме дали вече е пуснато за продажба или не
            if (MainPageElementsVariables.isVisible)
            {
                MainPageMethods.GoIntoNft(webDriver, NftToBeClicked);

                MainPageMethods.IsNftAlreadyForSale(webDriver, MainPageElementsVariables.isSellButtonVisible);
                //ако не е пуснато за продажба, го пускаме за продажба 
                if (MainPageElementsVariables.isSellButtonVisible)
                {
                    
                    MainPageMethods.GoToCollection(webDriver, NftCollection);
                    /*MainPageMethods.ClickCollectionOfferButton(webDriver);
                    Thread.Sleep(3000);
                    MainPageMethods.IsCollectionUnreviewed(webDriver);
                    MainPageMethods.CheckBoxIfUnreviewedCollection(webDriver);*/
                    Thread.Sleep(3000);
                    MainPageMethods.SaveFloorNumber(webDriver, NftCollection);
                    var collectionType = new Offer.Offer { Type = Offer.OfferType.ChildrenofUkiyo };

                    MainPageMethods.CalculateMySellNumber(fees, profit, collectionType, webDriver);
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
                    /*MainPageMethods.ClickCollectionOfferButton(webDriver);
                    Thread.Sleep(3000);
                    MainPageMethods.IsCollectionUnreviewed(webDriver);
                    MainPageMethods.CheckBoxIfUnreviewedCollection(webDriver);*/
                    Thread.Sleep(3000);
                    MainPageMethods.SaveFloorNumber(webDriver, NftCollection);
                    MainPageMethods.GoToCollection(webDriver, MainPageElements.myAccountUrl);
                    MainPageMethods.GoIntoNft(webDriver, NftToBeClicked);
                    MainPageMethods.CalculatemySellNumberWhenAlreadyNftForSale(webDriver);
                    MainPageMethods.SetLowerPriceForSaleIfNeeded(webDriver);
                }
                // от тук трябва да отидем в профил и да търсим следващото НФТ дали го имаме
            }
            else
            {
                if(MainPageElementsCollections.isChildrenofUkiyoProfitable == true)
                {
                    //започваме да пускаме оферта, като първо проверяваме колко е числото на Best offer-а
                    MainPageMethods.GoToCollection(webDriver, NftCollection);
                    MainPageMethods.SaveFloorNumber(webDriver, NftCollection);
                    MainPageMethods.SaveSevenDayAverageSellNumber(webDriver, profit);
                    MainPageMethods.ClickCollectionOfferButton(webDriver);
                    MainPageMethods.IsCollectionUnreviewed(webDriver);
                    MainPageMethods.CheckBoxIfUnreviewedCollection(webDriver);
                    MainPageMethods.SaveBestOfferNumber(webDriver);
                    if (MainPageElementsVariables.bestOfferNumber > MainPageElementsCollections.initialValuechildrenofUkiyo) // проверяваме дали best offer-а е по голям от моят последен best offer и ако е - продължавам
                    {
                        //проверявам дали Best offer-а е с поне 12.5% по - ниска от Floor price-а 
                        if ((MainPageElementsVariables.bestOfferNumber / MainPageElementsVariables.floorNumber) * 100 < 87.5 &&
                        MainPageElementsVariables.maxAvgPrice > MainPageElementsVariables.floorNumber)
                        {
                            //продължавам с пускането на офертата
                            MainPageElementsCollections.initialValuechildrenofUkiyo = MainPageMethods.CalculateMyOfferNumber(fees, profit + 2, MainPageElementsCollections.initialValuechildrenofUkiyo);
                            if (MainPageElementsVariables.isMyOfferOnProfit == true)
                            {
                                var offer = new Offer.Offer { Value = MainPageElementsCollections.initialValuechildrenofUkiyo, Type = Offer.OfferType.ChildrenofUkiyo };
                                MainPageMethods.SaveMyOfferNumberInFile(offer);
                                MainPageMethods.TypeMyOfferNumber(webDriver, MainPageElementsVariables.myOfferNumberString);
                                MainPageMethods.CheckIfWethIsEnough(webDriver);
                                MainPageMethods.SwapWethForEthIfNeeded(webDriver, NftCollection, MainPageElementsCollections.initialValuechildrenofUkiyo);
                                MainPageMethods.ClickMyOfferButton(webDriver);
                                MainPageMethods.SignTransactionWithMetamask(webDriver);
                            }

                        }
                        else
                        {
                            MainPageElementsCollections.isChildrenofUkiyoProfitable = false;
                        }
                    }
                
                } else
                {
                    MainPageElementsCollections.isChildrenofUkiyoProfitableCounter++;
                    if(MainPageElementsCollections.isChildrenofUkiyoProfitableCounter >= 300)
                    {
                        MainPageElementsCollections.isChildrenofUkiyoProfitable = true;
                        MainPageElementsCollections.isChildrenofUkiyoProfitableCounter = 0;
                    }
                }
            }
        }
    }
}
