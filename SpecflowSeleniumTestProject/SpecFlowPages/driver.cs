using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace SpecFlowPages
{
    public class Driver
    {
        
        public static IWebDriver Instance { get; set; }
        
      
        public static string BaseAddress
        {
            get { return Constantsutils.Url;}

        }
        public static void Initialize()
        {
            Instance = new ChromeDriver("C:\\Users\\Shahbaz.Mahmood\\Downloads\\chromedriver_win32new");
           
            TurnOnWait();
            Instance.Manage().Window.Maximize();
            
        }

        
        public static void Navigate()
        {
            Instance.Navigate().GoToUrl(BaseAddress);
          

        }
        public static void Close()
        {

            Instance.Close();
           
        }

        private static void TurnOnWait()
        {
            
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
           
        }
        public static Func<IWebDriver, IWebElement> ElementIsClickable(By locator)
        {
            return driver =>
            {
                var element = driver.FindElement(locator);
                return (element != null && element.Displayed && element.Enabled) ? element : null;
            };
        }

    }

}
