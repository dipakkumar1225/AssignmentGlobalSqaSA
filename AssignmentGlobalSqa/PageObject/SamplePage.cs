using AssignmentGlobalSqa.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AssignmentGlobalSqa.PageObject
{
    class SamplePage
    {
        private IWebDriver webDriver;
        public SamplePage()
        {
            webDriver = Hooks1.webDriver;
        }

        IWebElement webElementChooseFile => webDriver.FindElement(By.CssSelector("input[type=file]"));
        IWebElement webElementName => webDriver.FindElement(By.Id("g2599-name"));
        IWebElement webElementEmail => webDriver.FindElement(By.Id("g2599-email"));
        IWebElement webElementWebsite => webDriver.FindElement(By.Id("g2599-website"));
        IWebElement webElementExperience => webDriver.FindElement(By.Id("g2599-experienceinyears"));
        IList<IWebElement> webElementExpertise => webDriver.FindElements(By.Name("g2599-expertise[]"));
        IList<IWebElement> webElementEducation => webDriver.FindElements(By.Name("g2599-education"));
        IWebElement webElementComment => webDriver.FindElement(By.Id("contact-form-comment-g2599-comment"));
        IWebElement webElementSubmit => webDriver.FindElement(By.CssSelector("button.pushbutton-wide"));
        IWebElement webElementMessageSend => webDriver.FindElement(By.Id("contact-form-2599"));
        IWebElement webElementClickOnGoBack => webDriver.FindElement(By.CssSelector("#contact-form-2599 > h3 > a"));

        [Obsolete]
        public void ClickOnMenuSamplePage()
        {
            webDriver.Navigate().GoToUrl("https://www.globalsqa.com/samplepagetest/");
        }

        public void SelectFile(String filePath)
        {
            webElementChooseFile.SendKeys((String.IsNullOrEmpty(filePath) ? @"D:\1.txt" : @filePath));
        }

        public void EnterName(String strName)
        {
            webElementName.Clear();
            webElementName.SendKeys((String.IsNullOrEmpty(strName) ? Faker.Name.FullName() : strName));
        }

        public String GetEntredEmailAddress()
        {
            return webElementName.GetAttribute("value");
        }

        public void EnterEmail(String strEmail)
        {
            webElementEmail.Clear();
            webElementEmail.SendKeys((String.IsNullOrEmpty(strEmail) ? Faker.Internet.Email() : strEmail));
        }

        public void EnterWebSite(String strWebsite)
        {
            webElementWebsite.Clear();
            webElementWebsite.SendKeys((String.IsNullOrEmpty(strWebsite) ? Faker.Internet.Email() : strWebsite));
        }

        public void SelectExperienceFromDropDown(String strDropDown)
        {
            SelectElement select = new SelectElement(webElementExperience);
            IList<IWebElement> optionlist = select.Options;

            int optionsize = optionlist.Count;
            Random random = new Random();
            int randomIndex = random.Next(optionsize);
            select.SelectByIndex(randomIndex);
            if (String.IsNullOrEmpty(strDropDown))
            {
                select.SelectByIndex(randomIndex);
            }
            else
            {
                select.SelectByText(strDropDown);
            }
        }
        public void ChooseExpertise(String expertise)
        {
            IList<String> er = new List<String>();

            foreach (IWebElement item in webElementExpertise)
            {
                if (!String.IsNullOrEmpty(expertise))
                {
                    var s = expertise.Split(",");

                    for (int i = 0; i < s.Length; i++)
                    {
                        if (item.GetAttribute("value").Equals(s[i]))
                        {
                            item.Click();
                        }
                    }
                }
                else
                {
                    item.Click();
                }
            }
        }

        public void SelectEducation(String strEducation)
        {
            int iSize = webElementEducation.Count;


            for (int i = 0; i < iSize; i++)
            {
                String Value = webElementEducation.ElementAt(i).GetAttribute("value");

                if (!String.IsNullOrEmpty(strEducation))
                {
                    if (Value.Equals(strEducation))
                    {
                        webElementEducation.ElementAt(i).Click();
                        break;
                    }
                }
                else
                {
                    if (Value.Equals("Graduate"))
                    {
                        webElementEducation.ElementAt(i).Click();
                        break;
                    }
                }
            }
        }

        public void EnterComment(String comment)
        {
            webElementComment.Clear();

            if (!String.IsNullOrEmpty(comment))
            {
                webElementComment.SendKeys(comment);
            }
            else
            {
                webElementComment.SendKeys("This assigment is done in Selenium C#. Library used in this project are as follows. " +
                "\n 1.NUnit " +
                "\n 2.NUnit3TestAdapter " +
                "\n 3. Microsoft.NET.Test.Sdk " +
                "\n 4. Selenium.Support " +
                "\n 5. Selenium.WebDriver " +
                "\n 6. SpecFlow " +
                "\n 7. SpecFlow.Tools.MsBuild.Generation" +
                "\n 8. WebDriverManager" +
                "\n 9. Faker.Net");
            }
        }

        public void ClickOnSubmit()
        {
            webElementSubmit.Click();
        }

        [Obsolete]
        public Boolean IsSuccessfullySubmitted()
        {
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.Id("contact-form-2599")));
            return webElementMessageSend.Displayed;
        }

        public void NavigateBackToForm()
        {
            if (!IsVisibleInViewport(webElementClickOnGoBack))
            {
                IJavaScriptExecutor jse = (IJavaScriptExecutor)webDriver;
                jse.ExecuteScript("window.scrollTo({ top: 0, behavior: 'smooth' });");
            }
            Thread.Sleep(5000);
            webElementClickOnGoBack.Click();
        }

        public Boolean IsVisibleInViewport(IWebElement element)
        {
            return (Boolean)((IJavaScriptExecutor)webDriver).ExecuteScript(
                "var elem = arguments[0],                 " +
                "  box = elem.getBoundingClientRect(),    " +
                "  cx = box.left + box.width / 2,         " +
                "  cy = box.top + box.height / 2,         " +
                "  e = document.elementFromPoint(cx, cy); " +
                "for (; e; e = e.parentElement) {         " +
                "  if (e === elem)                        " +
                "    return true;                         " +
                "}                                        " +
                "return false;                            "
                , element);
        }

        public void checkMandatoryField()
        {
            ClickOnSubmit();

        }
    }
}
