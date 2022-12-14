using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace OpenSeaBot.ElementsAndVariables
{

    internal static class MainPageElements
    {
        public static string myAccountUrl = "https://opensea.io/account";
        public static string extensionPath = "C:/Users/aspar/AppData/Local/Google/Chrome/User Data/Default/Extensions/nkbihfbeogaeaoehlefnkodbefgpgknn/10.17.0_0.crx";
        public static By makeCollectionOfferButton = By.XPath("//span[text()='Make collection offer']");
        public static By getStarted = By.XPath("//button[text()='Get Started']");
        public static By importWallet = By.XPath("//button[text()='Import wallet']");
        public static By noThanks = By.XPath("//button[text()='No Thanks']");
        public static By word1 = By.XPath("//input[@id='import-srp__srp-word-0']");
        public static By word2 = By.XPath("//input[@id='import-srp__srp-word-1']");
        public static By word3 = By.XPath("//input[@id='import-srp__srp-word-2']");
        public static By word4 = By.XPath("//input[@id='import-srp__srp-word-3']");
        public static By word5 = By.XPath("//input[@id='import-srp__srp-word-4']");
        public static By word6 = By.XPath("//input[@id='import-srp__srp-word-5']");
        public static By word7 = By.XPath("//input[@id='import-srp__srp-word-6']");
        public static By word8 = By.XPath("//input[@id='import-srp__srp-word-7']");
        public static By word9 = By.XPath("//input[@id='import-srp__srp-word-8']");
        public static By word10 = By.XPath("//input[@id='import-srp__srp-word-9']");
        public static By word11 = By.XPath("//input[@id='import-srp__srp-word-10']");
        public static By word12 = By.XPath("//input[@id='import-srp__srp-word-11']");
        public static By password = By.XPath("//input[@id='password']");
        public static By passwordConfirm = By.XPath("//input[@id='confirm-password']");
        public static By termsOfUse = By.XPath("//input[@id='create-new-vault__terms-checkbox']");
        public static By import = By.XPath("//button[text()='Import']");
        public static By allDone = By.XPath("//button[text()='All Done']");
        public static By metamaskButton = By.XPath("//span[text()='MetaMask']");
        public static By nextMetamask = By.XPath("//button[text()='Next']");
        public static By connectMetamask = By.XPath("//button[text()='Connect']");
        public static By amountField = By.XPath("//input[@name='pricePerUnit']");
        public static By makeOfferButton = By.XPath("//button[text()='Make offer']");
        public static By confirmMetamaskButton = By.XPath("//button[text()='Confirm']");
        public static By signMetamaskButton = By.XPath("//button[text()='Sign']");
        public static By downArrowMetamask = By.XPath("//i[@title='Scroll down']");
        public static By sellButton = By.XPath("//a[text()='Sell']");
        public static By collectionLink = By.XPath("//a[@class='sc-1pie21o-0 elyzfO CollectionLink--link']");
        public static By sellPriceField = By.XPath("//input[@id='price']");
        public static By completeListingButton = By.XPath("//button[text()='Complete listing']");
        public static By notEnoughWethMessage = By.CssSelector("div[aria-modal=true] span[role=status]");
        public static By addWethButton = By.XPath("//button[text()='Add WETH']");
        public static By wrapEthButton = By.XPath("//div[text()='Wrap ETH']");
        public static By confirmButtonMetamask = By.XPath("//button[@class='button btn--rounded btn-primary page-container__footer-button']");
        public static By lowerPriceButton = By.XPath("//button[text()='Lower price']");
        public static By inputFieldLowerPrice = By.XPath("//input[@id='newAmount']");
        public static By setNewPriceButton = By.XPath("//button[text()='Set new price']");
        public static By isCollectionReviewed = By.XPath("//label[contains(., 'I understand that OpenSea has not reviewed this collection and blockchain transactions are irreversible.')]");
        public static By checkBoxReviewedCollection = By.CssSelector("span[type='checkbox'] input[id='review-confirmation']");
        public static By offerPeriodDownArrow = By.CssSelector("div[style='width: 162px;']");
        public static By offerPeriodCustom = By.CssSelector(".tippy-content li:last-child");
        public static By activity = By.XPath("//span[text()='Activity']");
        public static By lastSevenDaysPeriod = By.CssSelector("div[data-tippy-root] li:first-of-type button");
        public static By arrowDownTimePeriod = By.CssSelector(".fresnel-container.fresnel-greaterThanOrEqual-lg div[cursor='pointer']");
        public static By SevenDaysAveragePrice = By.CssSelector(".PriceHistory--interface > div p:first-of-type");
        public static By items = By.XPath("//span[text()='Items']");
        public static By closeWindowElement = By.XPath("//i[text()='close']");
        public static string floorNftsLocator = $"//div[text()='{{0}}']";
        public static By addToCartButton = By.XPath("//button[text()='Add to cart']");
        public static By completePurchaseButton = By.XPath("//button[text()='Complete purchase']");
        public static By floorPriceAllNfts = By.CssSelector("div[class*='Price--main']:not([color])>div");
        public static By floorPriceInNft = By.CssSelector("div[class*='Price--main TradeStation--price'] div[class*='Price--amount']");
        public static By approveCollectionElement = By.XPath("//h4[text()='Approve collection']");
        public static By goToCollectionFromNft = By.CssSelector("a[class*='Collection']");
        public static By nftPriceString = By.CssSelector("div[class='TradeStation--price-container'] div[class*='Price--amount']");
        public static By oneMonthButton = By.XPath("//div[contains(text(), '1 month')]");
        public static By oneMonthDateRangeMenu = By.CssSelector("i[value='keyboard_arrow_down'], [aria-label='Show more']");
        public static By oneMonthDateRangeButton = By.CssSelector("li:first-of-type>button");
        public static By floorPrice = By.CssSelector("a[data-testid='collection-stats-floor-price']>div>span>div");
        public static By bestOfferPrice = By.CssSelector("a[data-testid='collection-stats-best-offer']>div>span>div");
       

    }
}
