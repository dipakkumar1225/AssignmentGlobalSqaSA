using AssignmentGlobalSqa.PageObject;
using NUnit.Framework;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace AssignmentGlobalSqa.StepDefinations
{
    [Binding]
    public class SamplePageTestSteps
    {
        SamplePage samplePage;
        public SamplePageTestSteps()
        {
            samplePage = new SamplePage();
        }

        [Given(@"Access Sample Page Test from menu")]
        [Obsolete]
        public void GivenAccessSamplePageTestFromMenu()
        {
            samplePage.ClickOnMenuSamplePage();
        }

        [When(@"Choose File")]
        public void WhenChooseFile(Table table)
        {
            if (table.Rows.Count() != 0)
            {
                foreach (TableRow row in table.Rows)
                {
                    samplePage.SelectFile(row[0]);
                }
            }
            else
            {
                samplePage.SelectFile("");
            }
        }

        [When(@"Enter Name")]
        public void WhenEnterName(Table table)
        {
            if (table.Rows.Count() != 0)
            {
                foreach (TableRow row in table.Rows)
                {
                    samplePage.EnterName(row[0]);
                }
            }
            else
            {
                samplePage.EnterName("");
            }
        }

        [When(@"Enter Email")]
        public void WhenEnterEmail(Table table)
        {
            if (table.Rows.Count() != 0)
            {
                foreach (TableRow row in table.Rows)
                {
                    samplePage.EnterEmail(row[0]);
                }
            }
            else
            {
                samplePage.EnterEmail("");

            }
        }

        [When(@"Enter WebSite")]
        public void WhenEnterWebSite(Table table)
        {
            if (table.Rows.Count() != 0)
            {
                foreach (TableRow row in table.Rows)
                {
                    samplePage.EnterWebSite(row[0]);
                }
            }
            else
            {
                samplePage.EnterWebSite("");
            }
        }


        [When(@"Select Experience")]
        public void WhenSelectExperience(Table table)
        {
            if (table.Rows.Count() != 0)
            {
                foreach (TableRow row in table.Rows)
                {
                    samplePage.SelectExperienceFromDropDown(row[0]);
                }
            }
            else
            {
                samplePage.SelectExperienceFromDropDown("");
            }
        }

        [When(@"Choose Expertise")]
        public void WhenChooseExpertise(Table table)
        {
            if (table.Rows.Count() != 0)
            {
                foreach (TableRow row in table.Rows)
                {
                    samplePage.ChooseExpertise(row[0]);
                }
            }
            else
            {
                samplePage.ChooseExpertise("");
            }
        }

        [When(@"Select Education")]
        public void WhenSelectEducation(Table table)
        {
            if (table.Rows.Count() != 0)
            {
                foreach (TableRow row in table.Rows)
                {
                    samplePage.SelectEducation(row[0]);
                }
            }
            else
            {
                samplePage.SelectEducation("");
            }
        }

        [When(@"Enter Comment")]
        public void WhenEnterComment(Table table)
        {
            if (table.Rows.Count() != 0)
            {
                foreach (TableRow row in table.Rows)
                {
                    samplePage.EnterComment(row[0]);
                }
            }
            else
            {
                samplePage.EnterComment("");
            }
        }

        [When(@"Click on Submit")]
        public void WhenClickOnSubmit()
        {
            samplePage.ClickOnSubmit();
          
        }

        [Then(@"Navigate to message sent")]
        [Obsolete]
        public void ThenNavigateToMessageSent()
        {

            Assert.IsTrue(samplePage.IsSuccessfullySubmitted());
        }

        [Then(@"Click on Link GO BACK")]
        public void ThenClickOnLinkGOBACK()
        {
            samplePage.NavigateBackToForm();
        }

        [When(@"Do Not Enter Name")]
        public void WhenDoNotEnterName()
        {
            samplePage.EnterName("");
        }

    }
}
