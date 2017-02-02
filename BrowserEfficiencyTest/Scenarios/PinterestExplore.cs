﻿//--------------------------------------------------------------
//
// Browser Efficiency Test
// Copyright(c) Microsoft Corporation
// All rights reserved.
//
// MIT License
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files(the ""Software""),
// to deal in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and / or sell copies
// of the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions :
//
// The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE AUTHORS
// OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF
// OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
//--------------------------------------------------------------

using System;
using System.Collections.Generic;
using OpenQA.Selenium.Remote;
using System.Threading;
using OpenQA.Selenium;

namespace BrowserEfficiencyTest
{
    internal class PinterestExplore : Scenario
    {
        public PinterestExplore()
        {
            Name = "PinterestExplore";
            DefaultDuration = 60;
        }

        public override void Run(RemoteWebDriver driver, string browser, CredentialManager credentialManager)
        {
            UserInfo credentials = credentialManager.GetCredentials("pinterest.com");

            // Nagivate to the Pintrest explore page
            driver.Navigate().GoToUrl("https://www.pinterest.com/");
            driver.Wait(5);

            // Log in
            driver.TypeIntoField(driver.FindElement(By.Name("id")), credentials.Username);
            driver.Wait(2);
            driver.TypeIntoField(driver.FindElement(By.Name("password")), credentials.Password + Keys.Enter);
            driver.Wait(8);

            // Scroll
            driver.ScrollPage(10);
        }
    }
}
