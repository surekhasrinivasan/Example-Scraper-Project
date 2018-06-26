using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BotTheWeb
{
    class Program
    {
        static void Main(string[] args)
        {
            var Options = new ChromeOptions();
            Options.AddArguments("--disable-gpu");

            var chromeDriver = new ChromeDriver();
            chromeDriver.Navigate().GoToUrl("https://www.google.com");

            chromeDriver.FindElementByXPath("//*[@id=\"lst-ib\"]").Click();
            chromeDriver.Keyboard.SendKeys("Books");
            chromeDriver.Keyboard.SendKeys(Keys.Enter);//browser takes to new page

            chromeDriver.FindElementByXPath("//*[@id=\"hdtb-msb-vis\"]/div[3]/a").Click();
            
            var items = chromeDriver.FindElementsByXPath("//*[@id=\"rso\"]/div[1]/div/div[*]/div/div[2]/div/div[1]/a");//list of books
            Console.WriteLine(items.Count);//count of searched items

            foreach (var item in items)
            {
                Console.WriteLine(item.Text);
            }
        }
    }
}
