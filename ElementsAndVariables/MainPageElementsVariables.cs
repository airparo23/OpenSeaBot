using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSeaBot.ElementsAndVariables
{
    internal static class MainPageElementsVariables
    {
        public static string floorPrice;
        public static string bestOffer;
        public static string pattern = @"\d{1,}.\d{1,}";
        public static string floorNumberValue;
        public static double floorNumber;
        public static double mySellNumber;
        public static double mySellNumberWhenAlreadyNftForSaleNumber;
        public static bool isVisible;
        public static bool isSellButtonVisible;
        public static double bestOfferNumber;
        public static string myOfferNumberString;
        public static bool isNotEnoughWeth;
        public static string bestOfferNumberValue;
        public static bool isUnreviewedCollection;
        public static double maxOfferNumber;
        public static string sevenDaysAveragePriceString;
        public static string sevenDaysAveragePriceStringAfterRegexValue;
        public static double sevenDaysAveragePriceNumber;
        public static double sevenDaysAveragePriceNumberPercentage;
        public static double maxAvgPrice;
        public static bool isCollectionApproved;
        public static bool isMyOfferOnProfit;
        public static string floorPriceNumberValue;
        public static double nftPriceNumber;
        public static double myMinSellNumber;
    }
}
