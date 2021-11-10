using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Prueba
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://app.hustlegotreal.com/Account/Login");

            String email = "testing@hustlegotreal.com";
            String contraseña = "HGR2021";


            driver.FindElement(By.XPath("//input[@id='Email']")).SendKeys(email);
            driver.FindElement(By.XPath("//input[@id='Password']")).SendKeys(contraseña);

            driver.FindElement(By.XPath("/html/body/div/div[4]/div/form/div[5]/button")).Click();

            //System.Threading.Thread.Sleep(2000);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div[2]/div[1]/div[1]/div/div[2]/div/div[1]/p[2]")));

            String dato = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[1]/div[1]/div/div[2]/div/div[1]/p[2]")).Text;

            Console.WriteLine("El dato requerrido es:" + dato);
        }
    }
}
