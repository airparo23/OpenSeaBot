using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSeaBot.OfferNumber
{
    public class CollectionArguments
    {
        public WebDriver WebDriver { get; set; }
        public By Nft { get; set; }
        public By NftToBeClicked { get; set; }
        public String NftCollection { get; set; }
        public double Fees { get; set; }
        public double Profit { get; set; }


        public static void CollectionObjects(object[] args)
        {
            CollectionArguments collectionArgumentsVividLimited = new CollectionArguments();
            //collectionArgumentsVividLimited.WebDriver = ??
            collectionArgumentsVividLimited.Nft = By.XPath("//div[text()='VividLimited']");
            collectionArgumentsVividLimited.NftToBeClicked = By.XPath("//div[contains(normalize-space(text()), 'VIVID #')]");
            collectionArgumentsVividLimited.NftCollection = "https://opensea.io/collection/vividlimited";
            collectionArgumentsVividLimited.Fees = 7.5;
            collectionArgumentsVividLimited.Profit = 5;
        }

        
    }


}
