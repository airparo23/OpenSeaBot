using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
 

namespace OpenSeaBot
{
    public class Main
    {

        [SetUp]
        public void Setup()
        {

            
        }

        [Test]
        public void Test1()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            var option = new ChromeOptions();

            option.AddExtension(MainPageElements.extensionPath);
            WebDriver webDriver = new ChromeDriver(chromeDriverService, option); 
            webDriver.Manage().Window.Maximize();
            webDriver.SwitchTo().Window(webDriver.WindowHandles[0]);
            MainPageMethods.StartMetamask(webDriver, MainPageElements.getStarted, MainPageElements.importWallet, MainPageElements.noThanks);

            MainPageMethods.LogInMetamask(MainPageElements.word1, MainPageElements.word2, MainPageElements.word3, MainPageElements.word4, MainPageElements.word5, MainPageElements.word6,
                MainPageElements.word7, MainPageElements.word8, MainPageElements.word9, MainPageElements.word10, MainPageElements.word11, MainPageElements.word12, webDriver);

            webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
            MainPageMethods.ConnectMetamaskToOpenSea(webDriver);
            webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);

            //��������� �� ����������� NFT-���� �� ���������� ��������, ����� ������, ���� �� ���� ���� �� ����� ��� ��
            //�� ��� ��������� �� ����������� ���� ����� ��� �� ������ �������� ��� ��, ������ ������ ������ �� �� ������ � Collection -> Ethlizards. �� ����� ���� �������� �� ������ ������ ���
            //���� ���� �� ������ ������� � ��������� �� ����������

            //MainPageMethods.Set(, 3000); - ��� ������ �� � ������ �� ��������, ����� �� ������ �� �������, �� �� �����. ��� �� � Methods, ���������� ����� � ���. � ���� �� ������� ����������, �����
            // �� �� ������ �� ���������� �����

            //�� ��� �� ����� ���� Try/Catch �� ����� ��������, �� ��� ���� �� ������ ������, �� �� ����� ������, � �� ���������� ��� ���������� ��������
            try { 
            MainPageMethods.IsNftBought(webDriver, MainPageElements.spellfireNFT);
            MainPageMethods.TimerAvgPrice();
            //��� ����� NFT, ������� � ���� � ����������� ���� ���� � ������� �� �������� ��� ��
            if (MainPageElements.isVisible) 
            {
                MainPageMethods.GoIntoNft(webDriver, MainPageElements.spellfireNftToBeClicked);

                MainPageMethods.IsNftAlreadyForSale(webDriver, MainPageElements.isSellButtonVisible);
                //��� �� � ������� �� ��������, �� ������� �� �������� 
                if (MainPageElements.isSellButtonVisible)
                {
                    MainPageMethods.ClickCollectionLink(webDriver);
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
                } else
                {
                    // ��� � ������� �� ��������
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
                // �� ��� ������ �� ������ � ������ � �� ������ ���������� ��� ���� �� �����
            }
            else
            {
                //��������� �� ������� ������, ���� ����� ����������� ����� � ������� �� Best offer-�
                MainPageMethods.GoToCollection(webDriver, MainPageElements.ethlizardCollection);
                MainPageMethods.SaveSevenDayAverageSellNumber(webDriver, 8); 
                MainPageMethods.ClickCollectionOfferButton(webDriver);
                Thread.Sleep(4000);
                MainPageMethods.SaveFloorNumber(webDriver);
                MainPageMethods.SaveBestOfferNumber(webDriver);

                if (MainPageElements.bestOfferNumber > MainPageElements.myPreviousOfferNumber) // ����������� ���� best offer-� � �� ����� �� ���� �������� best offer � ��� � - �����������
                {
                    //���������� ���� Best offer-� � � ���� 15% �� - ����� �� Floor price-�
                    if ((MainPageElements.bestOfferNumber / MainPageElements.floorNumber) * 100 < 85 && MainPageElements.MaxAvgPrice > MainPageElements.floorNumber)
                    {
                        //����������� � ��������� �� ��������
                        MainPageMethods.CalculateMyOfferNumber(webDriver, 10, 10);
                        MainPageMethods.TypeMyOfferNumber(webDriver, MainPageElements.myOfferNumberString);
                        MainPageMethods.CheckIfWethIsEnough(webDriver);
                        MainPageMethods.SwapWethForEthIfNeeded(webDriver);
                        MainPageMethods.ClickMyOfferButton(webDriver);
                        MainPageMethods.SignTransactionWithMetamask(webDriver);
                    }
                }
                
            }

            } catch { Console.WriteLine("���� �� �����!"); }

        }
    }
}