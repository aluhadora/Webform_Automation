using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Webform_Automation
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      IWebDriver driver = new ChromeDriver();

      //Notice navigation is slightly different than the Java version
      //This is because 'get' is a keyword in C#
      driver.Navigate().GoToUrl("http://www.google.com/");

      // Find the text input element by its name
      IWebElement query = driver.FindElement(By.Name("q"));

      // Enter something to search for
      query.SendKeys("Cheese");

      // Now submit the form. WebDriver will find the form for us from the element
      query.Submit();

      // Google's search is rendered dynamically with JavaScript.
      // Wait for the page to load, timeout after 10 seconds
      WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
      wait.Until((d) => { return d.Title.ToLower().StartsWith("cheese"); });

      // Should see: "Cheese - Google Search"
      System.Console.WriteLine("Page title is: " + driver.Title);

      //Close the browser
      driver.Quit();
    }
  }
}
