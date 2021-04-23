using AssignmentGlobalSqa.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace AssignmentGlobalSqa.PageObject
{
    class PageDragNDrop
    {
        IWebDriver webDriver;
        public PageDragNDrop()
        {
            webDriver = Hooks1.webDriver;
        }

        #region Elements locators

        IWebElement webElementtestermenu => webDriver.FindElement(By.CssSelector("div#menu>ul>li:nth-of-type(4)"));
        IWebElement webElementtestersubmenu => webElementtestermenu.FindElement(By.CssSelector("div>ul>li:nth-of-type(1)"));
        IWebElement webElementtestersubmenuiTems => webElementtestersubmenu.FindElement(By.CssSelector("div>ul>li:nth-of-type(6)"));

        IWebElement webElementgallery => webDriver.FindElement(By.CssSelector("#gallery > li:nth-child(1) > img"));
        IWebElement webElementtrashy => webDriver.FindElement(By.CssSelector("div#trash"));
        IWebElement webIfrmae => webDriver.FindElement(By.CssSelector("#post-2669 > div.twelve.columns > div > div > div.single_tab_div.resp-tab-content.resp-tab-content-active > p > iframe"));
        #endregion

        public void clickOnMenuDragNDrop()
        {
            webDriver.Navigate().GoToUrl("https://www.globalsqa.com/demo-site/draganddrop/");
        }

        [Obsolete]
        public void dragNDropImagesFromGalleryToTrash()
        {
            webDriver.SwitchTo().Frame(webIfrmae);
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
          
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#gallery > li:nth-child(1) > img")));

            Actions builder = new Actions(webDriver);
            IAction dragAndDrop = builder.ClickAndHold(webElementgallery)
               .MoveToElement(webElementtrashy)
               .Release(webElementtrashy)
               .Build();

            dragAndDrop.Perform();

        }
    }
}
