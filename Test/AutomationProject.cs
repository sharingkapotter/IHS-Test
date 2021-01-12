using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Test
{
    [TestClass]
    public class AutomationProject
    {
        private static IWebDriver Driver { get; set; }

        public static void OpenBrowser()
        {
            //Create Browser reference
            Driver = new ChromeDriver();

            //Maximize the Browser window
            Driver.Manage().Window.Maximize();

            //Navigate to google page
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
        }

     [TestMethod]

        // Click on the Run button and validate the output text
        public void Test1()
        {
            OpenBrowser();

            //Find the RunButton element
            var runButton = Driver.FindElement(By.Id("run-button"));
            runButton.Click();

            //Assert the output
            var output = Driver.FindElement(By.Id("output"));
            var outputText = output.Text;

            //Asserts the output text with expected result
            Assert.AreEqual(outputText, "Hello World", "Output Text does NOT match to Hello world");

            //Close the browser and it's instance 
            Driver.Close();
            Driver.Quit();

        }

        /*Test 2 (If your first name starts with letter “Q-R-S-T-U”): 
         * Click “Save” button
            Check that “Log In” window appeared
        */
        [TestMethod]
        public void Test2()
        {
            OpenBrowser();

            //Find the SaveButton element
            var saveButton = Driver.FindElement(By.Id("save-button"));
            saveButton.Click();

            Thread.Sleep(3000); // Not a good practice to use thread.sleep in real world test automation, we always avoid and use explicit wait

            //Validate the Modal appears with the login details
            var modal = Driver.FindElement(By.Id("login-modal-label"));
            Assert.IsTrue(modal.Displayed);

            var email = Driver.FindElement(By.Id("Email"));
            Assert.IsTrue(email.Displayed);

            //Close the browser and it's instance 
            Driver.Close();
            Driver.Quit();
        }
    }
}
