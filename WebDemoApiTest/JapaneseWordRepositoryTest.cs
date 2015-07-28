using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using WebDemoApi.Interfaces;
using System.Data.Entity;
using WebDemoApi.Models;
using WebDemoApi.DataAccessLayer;

namespace WebDemoApiTest
{
    [TestFixture]
    public class JapaneseWordRepositoryTest
    {


        [Test]
        public void ShouldThrowWithInValidEntryId()
        {


        }

        [Test]
        public void WhenCreatingWordsSaveShouldBeCalledOnce()
        {
            
            var mockContext = new Mock<WebDemoApi.DataAccessLayer.WebDemoEntities>(); 
            var mockJapaneseWordRepository = new Mock<IJapaneseWordRepository>();

           
        }

        [Test]
        public void WhenUpdatingWordSaveShouldBeCalledOnce()
        {

        }
    }


}
