using System;
using WebDemo.Controllers;
using NUnit.Framework;

namespace WebDemoTest.Controller
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void DictionaryListAccesablilityTest()
        {
            var action = new HomeController().DictionaryLists();
        }
    }
}
