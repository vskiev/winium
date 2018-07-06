using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Winium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
       static RemoteWebDriver windriver=null;
        private IWebDriver _driver;

        private static void click(String elementName)
        {
            IWebElement element = null;
            for (int i = 1; i <= 10; i++)
            {
                try
                {
                    element = windriver.FindElementByName(elementName);
                    break;
                }
                catch (Exception e)
                {
                    Thread.Sleep(1000);
                }
            }

            for (int i = 1; i <= 10; i++)
            {
                Exception ex = null;
                try
                {
                    if (element.Enabled == true)
                    {
                        element.Click();
                        break;
                    }
                }
                catch (Exception e1)
                {
                    Thread.Sleep(1000);
                    ex = e1;
                }

            }
        }


        public void TakeScreenShot(RemoteWebDriver remoteDriver, String fileName, String path)
        {
            remoteDriver.GetScreenshot().SaveAsFile(@path+fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            //TODO need to add some checks
        }

        
        static void Main(string[] args)
        {
           
            DesiredCapabilities desired = new DesiredCapabilities();
           // DesktopOptions options = new DesktopOptions();
           
            desired.SetCapability("app", @"C:\Windows\notepad.exe");
            RemoteWebDriver windriver = new RemoteWebDriver(new Uri("http://localhost:9999"), desired);
           
            //sleeping for 1 sec, need to wait untill application start
            //should be impruved for more slower application solution provided in click method.
            Thread.Sleep(1000);

            //click("Edit");
            windriver.FindElementByName("Edit").Click();
            //take screenshot
            windriver.GetScreenshot().SaveAsFile(@"C:\Users\Administrator\Pictures\editClick.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
           

            windriver.FindElementByName("Edit").SendKeys("hello world");
            //take screenshot
            windriver.GetScreenshot().SaveAsFile(@"C:\Users\Administrator\Pictures\hello_world.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
            

            windriver.FindElementByName("Close").Click();
            windriver.GetScreenshot().SaveAsFile(@"C:\Users\Administrator\Pictures\closeButton.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);

         
            windriver.FindElementById("CommandButton_7").Click();
            windriver.GetScreenshot().SaveAsFile(@"C:\Users\Administrator\Pictures\dontSave.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);


        }

       
    }
}
