using System;
using System.Collections.Generic;
using OpenQA.Selenium.Remote;
using System.Threading;
using OpenQA.Selenium;



namespace BrowserEfficiencyTest
{
    internal class TwitterFeed : Scenario
    {
        public TwitterFeed()
        {
            Name = "TwitterFeed";
            DefaultDuration = 60;
        }


        public override void Run(RemoteWebDriver driver, string browser, CredentialManager credentialManager, ResponsivenessTimer timer)
        {
            driver.NavigateToUrl("http://www.twitter.com/login");
            driver.Wait(5);
            string oldUrl = driver.Url;

            UserInfo credentials = credentialManager.GetCredentials("twitter.com");
            if (credentials == null)
            {
                throw new Exception("Credentials for twitter.com not found!");
            }

            var username = driver.FindElementByName("session[username_or_email]");

            if (username == null)
            {

                throw new Exception("Username not found!");
            }

            //log in
            Console.WriteLine(username);
            driver.TypeIntoField(credentials.Username);
            driver.TypeIntoField(Keys.Tab);
            driver.Wait(1);
            driver.TypeIntoField(credentials.Password + Keys.Enter);
            driver.Wait(5);
            if (driver.Url == oldUrl)
            {
                throw new Exception("Couldn't logged in");
            }

            //scroll the feed
            driver.ScrollPage(5);
            driver.Wait(5);
            driver.ScrollPage(5);
            driver.Wait(5);
            driver.ScrollPage(5);
        }
    }
}
