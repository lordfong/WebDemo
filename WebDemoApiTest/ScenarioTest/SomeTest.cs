using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAutomation;
using NUnit;
using NUnit.Framework;

namespace WebDemoApiTest.ScenarioTest
{
    [TestFixture]
   public class SomeTest : FluentTest
    {

        public SomeTest()
        {
            SeleniumWebDriver.Bootstrap(
                SeleniumWebDriver.Browser.Chrome
            );
        }

        [Test]
        public void Test1()
        {
            I.Open("http://google.com/");
            // get busy testing!
        }
    }
}
