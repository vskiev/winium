#    Winium for automating Desktop Applications
###  Winium is a Automation framework for Windows Applications. It is a open source tool from 2GIS.

### Why Winium?
   * You have Selenium WebDriver for testing of web apps, Appium for testing of iOS and Android apps. And now you have Selenium-based tools for testing of Windows apps too.

   * You can write tests with your favorite dev tools using any WebDriver-compatible language such as Java, Objective-C, JavaScript with Node.js (in promise, callback or generator flavors), PHP, Python, Ruby, C#, Clojure, or Perl with the Selenium WebDriver API and language-specific client libraries.

### Winium supports:
  * #### WinForms
  * #### WPF
For Windows Phone 8.1 test automation tool see Windows Phone Driver. For Windows Phone 8 Silverlight test automation tool see Windows Phone Driver.

## How it works
Winium.Desktop.Driver implements Selenium Remote WebDriver and listens for JsonWireProtocol commands. It is responsible for automation of app under test using Winium.Cruciatus.

## [Supported Commands](https://github.com/2gis/Winium.Desktop/wiki/Supported-Commands)
<details><summary>commands</summary>

##### Winium.Desktop implements subset of [JSON Wire Protocol](https://code.google.com/p/selenium/wiki/JsonWireProtocol#Introduction)


| Command   	|      Query        	                                |
|----------	    |                                         :-------------|
| NewSession 	|  POST /session                                        |  
| FindElement 	|  POST /session/:sessionId/element                     |
| FindChildElement 	    |  POST /session/:sessionId/element/:id/element |
| ClickElement  | POST /session/:sessionId/element/:id/click            |
| SendKeysToElement |	POST /session/:sessionId/element/:id/value
| GetElementText	| GET /session/:sessionId/element/:id/text
| GetElementAttribute |	GET /session/:sessionId/element/:id/attribute/:name
| Quit	| DELETE /session/:sessionId
| ClearElement |	POST /session/:sessionId/element/:id/clear
| Close	DELETE | /session/:sessionId/window
| ElementEquals	| GET /session/:sessionId/element/:id/equals/:other
| ExecuteScript	| POST /session/:sessionId/execute
| FindChildElements |	POST /session/:sessionId/element/:id/elements
| FindElements	| POST /session/:sessionId/elements
| GetActiveElement |	POST /session/:sessionId/element/active
| GetElementSize | 	GET /session/:sessionId/element/:id/size
| ImplicitlyWait |	POST /session/:sessionId/timeouts/implicit_wait
| IsElementDisplayed |	GET /session/:sessionId/element/:id/displayed
| IsElementEnabled | GET /session/:sessionId/element/:id/enabled
| IsElementSelected	| GET /session/:sessionId/element/:id/selected
| MouseClick	| POST /session/:sessionId/click
| MouseDoubleClick	| POST /session/:sessionId/doubleclick
| MouseMoveTo | 	POST /session/:sessionId/moveto
| Screenshot	| GET /session/:sessionId/screenshot
| SendKeysToActiveElement	| POST /session/:sessionId/keys
| Status | 	GET /status
| SubmitElement |	POST /session/:sessionId/element/:id/submit
</p>
</details>


### Prerequisites for remote host machine
  * [Microsoft Windows 10 or Windows server 2016 (standart edition version 1604)](https://www.microsoft.com/en-us/windows) 
  * [Microsoft .NET Framework 4.5.1](https://www.microsoft.com/en-us/download/details.aspx?id=40779) 
  * [Winium Desktop Driver](https://github.com/2gis/Winium.Desktop/releases)


### Prerequisites for developer station
  * [Microsoft windows 10](https://www.microsoft.com/en-us/windows)
  * [Microsoft .NET Framework 4.5.1](https://www.microsoft.com/en-us/download/details.aspx?id=40779)
  * [Windows 10 SDK (Tools: inspect and VisualUIAVerifyNative)](https://developer.microsoft.com/en-us/windows/downloads/windows-10-sdk)
  * [Winium Desktop Driver](https://github.com/2gis/Winium.Desktop/releases)



## Installing
### python scenarion for developer station:

1. install you favorite IDE for python (for example [pyCharm](https://www.jetbrains.com/pycharm/)) or use any availible text editor in your system.
2. create script with code for testing or use example from repository.
3. install [python 3.6.3](https://www.python.org/downloads/) depending from you operation system
4. install selenium in python enviroment with any availible way (example: pip)
5. run winium.descktop.driver.exe (should run console application which is listening on port 9999)
6. run you script.  

<details><summary>example</summary>
<p>

```python 
from selenium import webdriver

driver = webdriver.Remote(
    command_executor='http://localhost:9999',
    desired_capabilities={
        "debugConnectToRunningApp": 'false',
        "app": r"C:/windows/system32/calc.exe"
    })

window = driver.find_element_by_class_name('CalcFrame')
view_menu_item = window.find_element_by_id('MenuBar').find_element_by_name('View')

view_menu_item.click()
view_menu_item.find_element_by_name('Scientific').click()

view_menu_item.click()
view_menu_item.find_element_by_name('History').click()

window.find_element_by_id('132').click()
window.find_element_by_id('93').click()
window.find_element_by_id('134').click()
window.find_element_by_id('97').click()
window.find_element_by_id('138').click()
window.find_element_by_id('121').click()

driver.close()
```
</p>
</details>

### C# scenarion for developer station:
 1. install visual studion 2017 any edition 
 2. install [Microsoft .NET Framework 4.5.1](https://www.microsoft.com/en-us/download/details.aspx?id=40779)
 3. create console project for C#
 4. install requared components to project via NuGet: Selenium.WebDriver, Winium.WebDriver, Winium.Elements.Desktop
 5. write your code or get example from repository or take example from [winium repository](https://github.com/2gis/Winium.Desktop/wiki/Magic-Samples)
 6. run winium.descktop.driver.exe
 7. compile and run your code
 8. enjoy magick
 
<details><summary>example</summary>
<p>

```CS
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
```
</p>
</details>

### Tools for automation
1. [Inspect](https://docs.microsoft.com/en-us/windows/desktop/winauto/inspect-objects) from Microsoft Windows SDK for Lowlevel application investigation 
2. [Visual UI Automation Verify](https://docs.microsoft.com/en-us/windows/desktop/winauto/visual-ui-automation-verify) from Microsoft Windows SDK for inspection visual components  

### Using tools
#### Inspecting application for locating elements inside

1. run inspect and run application calc like exemple, both application should running at same time on desktop. Select MSAA in padding and move mouse to separate appliction frame on the right panel of inspect we should see class="CalcFrame". This is our application class name for automation.

2. run Visual UI Automation Verify select on menu bar "View"--> "Highligthting" --> "Rectangle", on menu bar select "Mode" --> "Focus Tracking". And now move mouse to our test application and put in on desired component. 

3. [Finding Elements](https://github.com/2gis/Winium.Desktop/wiki/Finding-Elements) described in official reference. 
 


### Quick references:
[Windows 10 SDK](https://developer.microsoft.com/en-us/windows/downloads/windows-10-sdk),  
[Microsoft .NET Framework 4.5.1](https://www.microsoft.com/en-us/download/details.aspx?id=40779),
[Winium for Desktop](https://github.com/2gis/Winium.Desktop),
[Winium Desktop Driver](https://github.com/2gis/Winium.Desktop/releases),
[Inspect](https://docs.microsoft.com/en-us/windows/desktop/winauto/inspect-objects),
[Visual UI Automation Verify](https://docs.microsoft.com/en-us/windows/desktop/winauto/visual-ui-automation-verify)

### Additional resources:
[Presentations](https://github.com/2gis/Winium/wiki/Presentations),
[Supported Commands](https://github.com/2gis/Winium.Desktop/wiki/Supported-Commands),
[Command Execute Script](https://github.com/2gis/Winium.Desktop/wiki/Command-Execute-Script),
[Command Line Options](https://github.com/2gis/Winium.Desktop/wiki/Command-Line-Options),
[Capabilities](https://github.com/2gis/Winium.Desktop/wiki/Capabilities)
