using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using WebDriverManager.DriverConfigs.Impl;

namespace AssignmentGlobalSqa.Utilities
{
    [Binding]
    public sealed class Hooks1
    {
        public static IWebDriver webDriver;
        public static String BASEURL = "http://www.globalsqa.com/demo-site/";

        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;

        #region initialize web driver only once throughout the lifecycle
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized");
            webDriver = new ChromeDriver(chromeOptions);

            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(@"..\..\Report\Index.html");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

        }
        #endregion

        [BeforeFeature]
        [Obsolete]
        public static void BeforeFeature()
        {
       
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [BeforeScenario]
        [Obsolete]
        public void BeforeScenario()
        {
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }


        [AfterStep]
        [Obsolete]
        public void InsertReportingSteps()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if(stepType == "When")
                                scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if(stepType == "Then")
                                scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if(stepType == "And")
                                scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if(ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                }
                else if(stepType == "When")
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                }
                else if(stepType == "Then") {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                }
                else if(stepType == "And")
                {
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                }
            }
        }

        #region quiting the webdriver
        [AfterTestRun]
        public static void AfterTestRun()
        {
            if (webDriver != null)
            {
                Thread.Sleep(10000);
                webDriver.Quit();
                extent.Flush();
            }
        }
        #endregion
    }
}
