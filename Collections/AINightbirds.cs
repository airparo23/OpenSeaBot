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
    internal static class AINightbirds
    {
        public static void AINightbirdsCollection(
           WebDriver webDriver,
           By Nft,
           By NftToBeClicked,
           string NftCollection,
           double fees,
           double profit)
        {
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
                    Thread.Sleep(2000);
                    MainPageMethods.SaveFloorNumber(webDriver);
                    var collectionType = new Offer.Offer { Type = Offer.OfferType.AINightbirds };

                    MainPageMethods.CalculateMySellNumber(fees, profit, collectionType, webDriver);
                    MainPageMethods.GoToCollection(webDriver, MainPageElements.myAccountUrl);
                    MainPageMethods.GoIntoNft(webDriver, NftToBeClicked);
                    MainPageMethods.ClickSellButton(webDriver);
                    MainPageMethods.TypeMySellNumberAndCompleteListing(webDriver);
                }
                else
                {
                    // ако е пуснато за продажба
                    MainPageMethods.GetMySellNumberWhenAlreadyNftForSale(webDriver);
                    MainPageMethods.GoToCollection(webDriver, NftCollection);
                    Thread.Sleep(2000);
                    MainPageMethods.SaveFloorNumber(webDriver);
                    var collectionType = new Offer.Offer { Type = Offer.OfferType.AINightbirds };
                    MainPageMethods.SetLowerPriceForSaleIfNeeded(webDriver, fees, profit, collectionType, NftToBeClicked);
                }
                // от тук трябва да отидем в профил и да търсим следващото НФТ дали го имаме
            }
            else
            {
                //започваме да пускаме оферта, като първо проверяваме колко е числото на Best offer-а
                MainPageMethods.GoToCollection(webDriver, NftCollection);
                Thread.Sleep(2000);
                MainPageMethods.SaveFloorNumber(webDriver);
                MainPageMethods.ClickCollectionOfferButton(webDriver);
                MainPageMethods.IsCollectionUnreviewed(webDriver);
                MainPageMethods.CheckBoxIfUnreviewedCollection(webDriver);
                MainPageMethods.SaveBestOfferNumber(webDriver);
                if (MainPageElementsVariables.bestOfferNumber != MainPageElementsCollections.initialValueAINightbirds) // проверяваме дали best offer-а е по голям от моят последен best offer и ако е - продължавам
                {
                    //проверявам дали Best offer-а е с поне 12.5% по - ниска от Floor price-а 
                    if ((MainPageElementsVariables.bestOfferNumber / MainPageElementsVariables.floorNumber) * 100 < 100 - (fees + profit))
                    {
                        //продължавам с пускането на офертата
                        MainPageElementsCollections.initialValueAINightbirds = MainPageMethods.CalculateMyOfferNumber(fees, profit + 2, MainPageElementsCollections.initialValueAINightbirds);
                        if (MainPageElementsVariables.isMyOfferOnProfit == true)
                        {
                            var offer = new Offer.Offer { Value = MainPageElementsCollections.initialValueAINightbirds, Type = Offer.OfferType.AINightbirds };
                            MainPageMethods.SaveMyOfferNumberInFile(offer);
                            MainPageMethods.TypeMyOfferNumber(webDriver, MainPageElementsVariables.myOfferNumberString);
                            MainPageMethods.IsWethEnough(webDriver);
                            MainPageMethods.SwapWethForEthIfNeeded(webDriver, NftCollection, MainPageElementsCollections.initialValueAINightbirds);
                            MainPageMethods.ClickMyOfferButton(webDriver);
                            MainPageMethods.SignTransactionWithMetamask(webDriver);
                        }
                    }
                }
            }
        }
    }
}
